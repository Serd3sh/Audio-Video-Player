// Описание: загрузка и управление внутренней очередью и файлом с историей
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AudioVideoPlayer {
	internal class History {
		public bool Available; // Доступность истории для чтения и записи
		public FileQueue Queue; // Внутренняя очередь, с которой синхронизируется список в форме

		// Потоки для записи и чтения файла
		private StreamWriter Writer;
		private StreamReader Reader;
		private Stream BaseStream;

		public History() {
			Queue = new FileQueue();
			Writer = null;
			Reader = null;
			BaseStream = null;
		}

		// Очистка истории с пересозданием файла
		public void Clear() {
			try {
				File.Delete("History.txt");
			} catch (Exception ex) {
				Console.WriteLine($"[Histroy] Не удалось удалить файл History.txt\n{ex}");
			}
			Queue.Clear(true);
			try {
				using (BaseStream = File.Open("History.txt", FileMode.CreateNew, FileAccess.ReadWrite))
					Console.WriteLine("[History] Файл истории пересоздан");
			} catch (Exception ex) {
				Available = false;
				Console.WriteLine($"[Histroy] Не удалось создать файл History.txt\n=== Начало исключения ===\n{ex}\n=== Конец исключения ===");
			}
		}

		// Попытка загрузить историю из файла или создать файл
		public DialogResult TryLoadHistory() {
			try {
				if (!File.Exists("History.txt")) {
					using (BaseStream = File.Open("History.txt", FileMode.CreateNew, FileAccess.ReadWrite))
						Console.WriteLine("[History] Файл истории не найден, создан и открыт в режиме записи");
				} else {
					if (Reader == null) {
						Console.WriteLine("[History] Чтение данных из файла");
						// Для формирования списка файлов, которых  подключить не удалось
						StringBuilder missingFiles = new StringBuilder();
						StringBuilder unvaildFiles = new StringBuilder();
						using (BaseStream = File.Open("History.txt", FileMode.Open, FileAccess.Read)) {
							Reader = new StreamReader(BaseStream);
							while (!Reader.EndOfStream) {
								String dir = Reader.ReadLine();
								if (!File.Exists(dir)) {
									missingFiles.AppendLine(dir);
									continue;
								}
								if (!FileQueue.IsVaildName(dir, Format.Audio) && !FileQueue.IsVaildName(dir, Format.Video)) {
									unvaildFiles.AppendLine(dir);
									continue;
								}
								Queue.AddItem(new Item {
									FullName = dir,
									ShortName = dir.Substring(dir.LastIndexOf('\\') + 1)
								}, true);
							}
						}
						if (missingFiles.Length > 0) {
							Console.WriteLine("[History] Некоторые файлы отстутствуют");
							MessageBox.Show(
								$"Эти файлы не загружены в историю, т.к. они не существуют или к ним нет доступа: \n{missingFiles}",
								"История",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning
							);
						}
						if (unvaildFiles.Length > 0) {
							Console.WriteLine("[History] В файле присутствуют неподдерживаемые форматы");
							MessageBox.Show(
								$"Эти файлы в истории имеют неподдерживаемый формат: \n{unvaildFiles}\n\nОни были проигнорированны",
								"История",
								MessageBoxButtons.OK,
								MessageBoxIcon.Warning
							);
						}
					}
					Console.WriteLine("[History] Проверка открытия файла в режиме записи");
					using (BaseStream = File.Open("History.txt", FileMode.Open, FileAccess.Write))
						Console.WriteLine("[History] OK");
				}
			} catch (Exception ex) {
				Available = false;
				Console.WriteLine($"[History] Непредвиденное исключение\n=== Начало исключения ==\n{ex}\n=== Конец исключения ===");
				return MessageBox.Show(
					$"Невозможно создать/изменить файл с историей: {Directory.GetCurrentDirectory()}\\History.txt. \n\nНажмтие Повтор, чтобы попробовать повторить загрузка, Прервать чтобы выйти или Пропустить чтобы продолжить использование программы без возможности использования истории.\n\nПодробности: {ex.Message}",
					"История",
					MessageBoxButtons.AbortRetryIgnore,
					MessageBoxIcon.Error
				);
			};
			Available = true;
			return DialogResult.OK;
		}

		// Запись в историю 
		public void Write(String data) {
			if (!Available) return;
			try {
				// Проверка, есть ли эта запись в истории. Если да - просто выходим
				using (BaseStream = File.Open("History.txt", FileMode.Open, FileAccess.Read)) {
					Reader = new StreamReader(BaseStream);
					while (!Reader.EndOfStream)
						if (Reader.ReadLine() == data) return;
				}
				// Запись в историю
				using (BaseStream = File.Open("History.txt", FileMode.Append, FileAccess.Write, FileShare.Read)) {
					Writer = new StreamWriter(BaseStream);
					Console.WriteLine($"[History] Запись в файл: {data}");
					Writer.WriteLine(data);
					Writer.Close();
					Item record = new Item();
					record.FullName = data;
					record.ShortName = data.Substring(data.LastIndexOf('\\') + 1);
					Queue.AddItem(record, true);
				}
			} catch (Exception ex) {
				Console.WriteLine($"[History] Не удалось добавить данные в историю\n=== Начало исключения ===\n{ex}\n=== Конец исключения ===");
			}
		}
	}
}
