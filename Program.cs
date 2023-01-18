using System;
using System.Windows.Forms;

namespace AudioVideoPlayer {
	internal static class Program {
		[STAThread]
		static void Main() {
			#region Инициализация
			Console.Title = "Audio-Video Player: Debug console";
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainWindow window = new MainWindow();
			FileQueue queue = new FileQueue();
			AudioPlayer Audio = new AudioPlayer();
			VideoPlayer Video = new VideoPlayer(window.VideoPlayer);
			History history = new History();
			window.HistoryList.Items.Clear();
			window.QueueList.Items.Clear();
			#endregion

			#region Загрузка истории
			DialogResult initUserResult;
			bool notifyWhenOK = false;
			while (true) {
				initUserResult = history.TryLoadHistory();
				if (initUserResult == DialogResult.Abort) return;
				else if (initUserResult == DialogResult.Retry)
					notifyWhenOK = true;
				else {
					if (notifyWhenOK)
						MessageBox.Show(
							"Файл успешно загружен",
							"История",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information
						);
					break;
				};
			};
			Console.WriteLine($"[Main] Загрузка истории завершена. Доступность для использования: {history.Available}");
			if (history.Available)
				foreach (Item item in history.Queue.Queue)
					window.HistoryList.Items.Add(item.ShortName);
			#endregion

			#region Контексное меню, меню сверху
			// Функция позволяет выделить все объекты, или снять все выделение с них
			void SetSelectedList(CheckedListBox list, bool selected) {
				Console.WriteLine($"[Main] Изменение выделения списка {list.Name} на: {selected}");
				for (int i = 0; i < list.Items.Count; i++)
					list.SetItemChecked(i, selected);
			};
			queue.Update(window.QueueList);
			window.MoveUpSelected.Click += (obj, args) => {
				Console.WriteLine("[Main] Сдвиг очереди вверх");
				queue.MoveSelectedUp(window.QueueList);
			};
			window.MoveDownSelected.Click += (obj, args) => {
				Console.WriteLine("[Main] Сдвиг очереди вниз");
				queue.MoveSelectedDown(window.QueueList);
			};

			window.QueueDeselectSelected.Click += (obj, args) => SetSelectedList(window.QueueList, false);
			window.QueueSelectAll.Click += (obj, args) => SetSelectedList(window.QueueList, true);
			window.HistoryDeselectSelected.Click += (obj, args) => SetSelectedList(window.HistoryList, false);
			window.HistorySelectAll.Click += (obj, args) => SetSelectedList(window.HistoryList, true);

			window.LoadFilesButton.Click += (obj, args) => {
				Console.WriteLine("[Main] Открытие окна выбора файл(ов)");
				window.OpenFile.ShowDialog();
			};
			window.ClearQueueButton.Click += (obj, args) => {
				Console.WriteLine("[Main] Очистка очереди");
				queue.Clear();
				queue.Update(window.QueueList);
			};
			window.ClearHistoryButton.Click += (obj, args) => {
				Console.WriteLine("[Main] Очистка истории");
				history.Clear();
				history.Queue.Update(window.HistoryList);
			};
			#endregion

			#region Откртие файлов
			window.OpenFile.FileOk += (obj, args) => {
				Console.WriteLine("[Main] Обработка выбранных файлов");
				foreach (String file in window.OpenFile.FileNames) {
					bool isAudio = FileQueue.IsVaildName(file, Format.Audio);
					bool isVideo = FileQueue.IsVaildName(file, Format.Video);
					if (isAudio || isVideo) {
						Console.WriteLine($"[Main] Файл {file} добавлен в очередь");
						queue.AddItem(new Item {
							FullName = file,
							ShortName = file.Substring(file.LastIndexOf('\\') + 1)
						});
						history.Write(file);
						history.Queue.Update(window.HistoryList);
					} else {
						Console.WriteLine($"[Main] Неверный формат файла {file}");
						continue;
					};

					if (!Video.IsPlaying && !Audio.IsPlaying) {
						Console.WriteLine("[Main] Медиа не активно. Запуск следующего файла");
						HandleNextFile(false);
					};
				};
				queue.Update(window.QueueList);
			};
			window.LoadToQueueSelected.Click += (obj, args) => {
				Console.WriteLine("[Main] Загрузка выбранных элементов в очередь из истории");
				foreach (String item in window.HistoryList.CheckedItems) {
					int index = history.Queue.Queue.FindIndex(
						(record) => record.ShortName == item
					);
					if (index == -1) continue;
					queue.AddItem(history.Queue.Queue[index]);
				};
				if (!Audio.IsPlaying && !Video.IsPlaying) HandleNextFile(false);
				queue.Update(window.QueueList);
			};
			#endregion

			#region Контроль окончания проигрывания
			// Включает следующий файл, если он есть в очереди
			void HandleNextFile(bool isActive) {
				if (isActive || Video.IsPlaying || Audio.IsPlaying) return;
				Console.WriteLine("[Main] Запрос включить следующий файл");
				LoadResult result = Audio.TryPlayNext(queue);
				if (result == LoadResult.QueueEmpty) {
					window.CurrentPlay.Text = "/ Ничего /";
					return;
				};
				if (result == LoadResult.WrongFormat)
					result = Video.TryPlayNext(queue);

				// Перехват ошибки, когда файл больше не существует по загадочным обстоятельствам
				bool skipMsg = false;
				while (result == LoadResult.Error) {
					if (!skipMsg)
						skipMsg = MessageBox.Show(
							$"Файл {queue.ReadNow().FullName} больше недоступен и был удален из очереди\nПродолжать показывать это окно в случае повторения ошибки?",
							"Очередь",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Error
						) == DialogResult.No;
					queue.RemoveItem(queue.ReadNow().ShortName);
					result = Audio.TryPlayNext(queue);
					if (result == LoadResult.WrongFormat)
						result = Video.TryPlayNext(queue);
				};

				queue.Update(window.QueueList);
				if (result == LoadResult.QueueEmpty) {
					window.CurrentPlay.Text = "/ Ничего /";
					return;
				};
				if (result == LoadResult.Success) {
					window.CurrentPlay.Text = queue.ReadNow().ShortName;
					Console.WriteLine($"[Main] Медиа запущенно");
				};
				window.PlayButton.Text = "Пауза";
			};

			// Восстанавливает и включает раннее воспроизводимый файл в очереди
			void HandlePrevFile() {
				Console.WriteLine("[Main] Запрос включить предыдущий файл");
				Item prev;
				bool videoWasActvie = Video.IsPlaying;
				bool audioWasActive = Audio.IsPlaying;
				bool audioStarted = true;
				if (!(Audio.IsPlaying || Video.IsPlaying))
					prev = queue.ReadNow();
				else {
					if (queue.ReadPrevious().FullName == null) {
						Console.WriteLine("[Main] Отказано: это самый первый файл в очереди");
						return;
					};
					prev = queue.TakePrevious();
				};
				LoadResult result = Audio.TryPlayNow(prev.FullName);
				if (result == LoadResult.WrongFormat) {
					result = Video.TryPlayNow(prev.FullName);
					audioStarted = false;
				}

				// Перехват ошибки, когда файл больше не существует по загадочным обстоятельствам
				bool skipMsg = false;
				while (result == LoadResult.Error) {
					if (!skipMsg)
						skipMsg = MessageBox.Show(
							$"Файл {queue.ReadNow().FullName} больше недоступен и был удален из очереди\nПродолжать показывать это окно в случае повторения ошибки?",
							"Очередь",
							MessageBoxButtons.YesNo,
							MessageBoxIcon.Error
						) == DialogResult.No;
					queue.RemoveItem(queue.ReadNow().ShortName);
					if (queue.ReadPrevious().FullName == null) {
						MessageBox.Show(
							$"Достигнуто начало очереди",
							"Очередь",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error
						);
						queue.TakeNext();
						break;
					}
					prev = queue.ReadNow();
					result = Audio.TryPlayNow(prev.FullName);
					audioStarted = true;
					if (result == LoadResult.WrongFormat) {
						result = Video.TryPlayNow(prev.FullName);
						audioStarted = false;
					};
				};

				if (result == LoadResult.Success) {
					if (audioStarted && videoWasActvie) Video.Stop();
					else if (!audioStarted && audioWasActive) Audio.Stop();
					window.CurrentPlay.Text = queue.ReadNow().ShortName;
					Console.WriteLine("[Main] Медиа запущенно");
				}
				queue.Update(window.QueueList);
				window.PlayButton.Text = "Пауза";
			};
			Audio.PlayerStateChanged += HandleNextFile;
			Video.PlayerStateChanged += HandleNextFile;
			#endregion

			#region Управление аудио
			window.PlayButton.Click += (obj, args) => {
				if (!Audio.IsPlaying) return;
				if (window.PlayButton.Text == "Пауза") {
					Console.WriteLine("[Main] Приостановка аудио");
					window.PlayButton.Text = "Воспроизвести";
					Audio.Player.Pause();
					return;
				}
				Console.WriteLine("[Main] Возобновление аудио");
				window.PlayButton.Text = "Пауза";
				Audio.Player.Play();
			};
			window.FrontRewindButton.Click += (obj, args) => {
				if (!Audio.IsPlaying) return;
				if (Audio.Player.Position.TotalSeconds + 5 > Audio.Duration)
					HandleNextFile(false);
				else
					Audio.Player.Position = Audio.Player.Position.Add(new TimeSpan(0, 0, 5));
			};
			window.BackRewindButton.Click += (obj, args) => {
				if (!Audio.IsPlaying) return;
				if (Audio.Player.Position.TotalSeconds - 5 < 0)
					Audio.Player.Position = new TimeSpan(0);
				else
					Audio.Player.Position = Audio.Player.Position.Subtract(new TimeSpan(0, 0, 5));
			};
			window.VolumeInput.TextChanged += (obj, args) => {
				ushort input;
				bool successParse = ushort.TryParse(window.VolumeInput.Text, out input);
				if (window.VolumeInput.Text.Length == 0) return;
				if (!successParse || input > 100) {
					// Из-за попытки представления числа в форме, возможено переполнение стека, т.к. у формы как то не вяжется Undo() и знак минуса
					if (window.VolumeInput.Text[0] == '-')
						window.VolumeInput.Text = window.VolumeInput.Text.Remove(0, 1);
					else
						window.VolumeInput.Undo();
					return;
				}
				Audio.Player.Volume = input / 100.0;
			};
			#endregion

			#region Управление очередью
			window.NextButton.Click += (obj, args) => {
				// Слушатель события остановки сам обработает следующий файл
				if (Audio.IsPlaying) Audio.Stop();
				else Video.Stop();
			};
			window.PreviousButton.Click += (obj, args) => HandlePrevFile();
			#endregion

			Application.Run(window);
		}
	}
}
