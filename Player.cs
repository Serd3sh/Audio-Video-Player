// Описание: реализует управление аудио и видео плеерами
using AxWMPLib;
using System;
using System.IO;
using System.Text;
using System.Windows.Media;

namespace AudioVideoPlayer {
	// Результат попытки загрузки файла в плеер
	internal enum LoadResult {
		Success,    // Успешно загружен в плеер
		Error,      // Возникла ошибка и файл загрузить не удалось 
		QueueEmpty, // Очередь пуста
		WrongFormat // Плеер не поддерживает данный формат файла
	}

	// Базовый класс любого плеера
	internal class BasePlayer {
		public bool IsPlaying; // Загружено ли какое либо медиа в данный плеер

		// Событие, запускаемое при изменении переменной IsPlaying
		public delegate void PlayerStateChangedHandler(bool isStarted);
		public event PlayerStateChangedHandler PlayerStateChanged;

		// Изменение переменной IsPlaying и вызов события
		protected void SetState(bool state) {
			IsPlaying = state;
			PlayerStateChanged?.Invoke(state);
		}

		public BasePlayer() {
			IsPlaying = false;
		}
	}
	internal class AudioPlayer : BasePlayer {
		public MediaPlayer Player; // Сам плеер
		public double Duration; // Общая протяженность включенного файла

		public AudioPlayer() {
			Player = new MediaPlayer();
			Duration = 0.0;
			PlayerStateChanged += (active) =>
				Console.WriteLine($"[AudioPlayer] Аудио {( active ? "запущено" : "завершено" )}");
			Player.MediaEnded += (obj, args) => Stop();
			Player.MediaFailed += (obj, args) => Stop();
			Player.MediaOpened += (obj, args) => {
				if (!Player.NaturalDuration.HasTimeSpan) {
					Duration = 0.0;
					return;
				};
				Duration = Player.NaturalDuration.TimeSpan.TotalSeconds;
			};
		}

		// Попытка сразу загрузить файл в плеер
		private LoadResult FormatAndPlay(String path) {
			if (!File.Exists(path)) {
				Console.WriteLine($"[AudioPlayer] Ошибка загрузки аудио: файл больше не существует");
				return LoadResult.Error;
			}
			StringBuilder uri = new StringBuilder("file://");
			uri.Append(path.Replace('\\', '/'));
			Player.Stop();
			Player.Open(new Uri(uri.ToString()));
			Player.Play();
			SetState(true);
			return LoadResult.Success;
		}

		// Попытка извлечь следующий элемент из очереди Queue и воспроизвести его
		public LoadResult TryPlayNext(FileQueue Queue) {
			if (Queue.ReadNext().FullName == null)
				return LoadResult.QueueEmpty;
			if (FileQueue.IsVaildName(Queue.ReadNext().FullName, Format.Audio)) {
				Item next = Queue.TakeNext();
				return FormatAndPlay(next.FullName);
			};
			return LoadResult.WrongFormat;
		}

		// Попытка сразу воспроизвести файл path 
		public LoadResult TryPlayNow(String path) {
			return FileQueue.IsVaildName(path, Format.Audio) ? FormatAndPlay(path) : LoadResult.WrongFormat;
		}

		// Остановка восрпоизведения плеера
		public void Stop() {
			Player.Stop();
			SetState(false);
		}
	};
	internal class VideoPlayer : BasePlayer {
		public AxWindowsMediaPlayer Player; // Сам плеер

		public VideoPlayer(AxWindowsMediaPlayer Player) {
			this.Player = Player;
			PlayerStateChanged += (active) => 
				Console.WriteLine($"[VideoPlayer] Видео {( active ? "запущено" : "завершено" )}");
			Player.PlayStateChange += (obj, args) => {
				if (args.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
					Stop();
			};
			Player.ErrorEvent += (obj, args) => {
				Console.WriteLine($"[VideoPlayer] Возникла непредвиденная ошибка");
				Stop();
			};
			Player.StatusChange += (obj, args) => {
				if (Player.status == "Готово") Player.Ctlcontrols.play();
			};
		}

		// Попытка сразу загрузить файл в плеер
		private LoadResult FormatAndPlay(String path) {
			if (!File.Exists(path)) {
				Console.WriteLine($"[VideoPlayer] Ошибка загрузки видео: файл больше не существует");
				return LoadResult.Error;
			}
			if (!Player.Ctlenabled) Player.Ctlenabled = true;
			Player.Ctlcontrols.stop();
			Player.URL = path;
			Player.Ctlcontrols.play();
			SetState(true);
			return LoadResult.Success;
		}

		// Попытка извлечь следующий элемент из очереди Queue и воспроизвести его
		public LoadResult TryPlayNext(FileQueue Queue) {
			if (Queue.ReadNext().FullName == null)
				return LoadResult.QueueEmpty;
			if (FileQueue.IsVaildName(Queue.ReadNext().FullName, Format.Video)) {
				Item next = Queue.TakeNext();
				return FormatAndPlay(next.FullName);
			};
			return LoadResult.WrongFormat;
		}

		// Попытка сразу воспроизвести файл path 
		public LoadResult TryPlayNow(String path) {
			if (FileQueue.IsVaildName(path, Format.Video))
				return FormatAndPlay(path);
			return LoadResult.WrongFormat;
		}

		// Остановка воспроизведение медиа
		public void Stop() {
			Player.Ctlcontrols.stop();
			Player.Ctlenabled = false;
			SetState(false);
		}
	};
}
