// Описание: реализация управления очередью с возможностью восстановления раннее извлеченного элемента
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AudioVideoPlayer {
	// Структура элемента в очереди
	struct Item {
		public String ShortName; // короткое имя, например: file.mp3
		public String FullName; // полное имя, например: C:\MyMdeia\file.mp3
	}
	// Формат для уточнения какой именно файл нужен
	enum Format {
		Audio, Video
	}
	internal class FileQueue {
		public List<Item> Queue; // Внутренняя очередь
		private int CursorIndex; // Индекс "головы" очереди, позволяющий "достать" из очереди раннее используемый элемент 

		// Статические массивы с доступными форматами файлов
		public static String[] VaildAudioFormats = {"wav", "mp3", "midi", "ogg"};
		public static String[] VaildVideoFormats = {"avi", "mpeg", "wmv", "mov", "webm", "mp4"};

		public FileQueue() {
			Queue = new List<Item>();
			CursorIndex = 0;
		}

		// Проверяет, удовлетворяет ли данный файл name формату format
		public static bool IsVaildName(String name, Format format) {
			String fileExt = name.Substring(name.LastIndexOf('.')+1).ToLower();
			if (format == Format.Audio) {
				foreach (String ext in VaildAudioFormats)
					if (fileExt == ext)
						return true;
			} else
				foreach (String ext in VaildVideoFormats)
					if (fileExt == ext)
						return true;
			return false;
		}

		// Поднимает выбранные элементы в списке UiList на 1 позицию вверх, сохраняя относительный порядок
		public void MoveSelectedUp(CheckedListBox UiList) {
			int offset = 0; // Счетчик, отвечающий за относительный порядок
			foreach (String name in UiList.CheckedItems) {
				offset++;
				int index = Queue.FindIndex(obj => obj.ShortName == name);
				if (index > CursorIndex && index >= offset) {
					Item temp = Queue[index];
					Queue[index] = Queue[index - 1];
					Queue[index - 1] = temp;
				}
			}
			Update(UiList);
		}

		// Спускает выбранные элементы в списке UiList на 1 позицию вниз, сохраняя отностительный порядок 
		public void MoveSelectedDown(CheckedListBox UiList) {
			int offset = Queue.Count-1; // Счетчик, отвечающий за относительнный порядок
			for (int i = UiList.CheckedItems.Count - 1; i >= 0; i--) {
				offset--;
				int index = Queue.FindIndex(obj => obj.ShortName == (String)UiList.CheckedItems[i]);
				if (index < Queue.Count - 1 && index <= offset) {
					Item temp = Queue[index];
					Queue[index] = Queue[index + 1];
					Queue[index + 1] = temp;
				}
			}
			Update(UiList);
		}

		// Обновляет список внутри UiList, сохраняя "галочки" на элементах
		public void Update(CheckedListBox UiList) {
			String[] selected = new String[UiList.CheckedItems.Count];
			UiList.CheckedItems.CopyTo(selected, 0);
			UiList.Items.Clear();
			if (Queue.Count - CursorIndex > 0)
				for (int i = CursorIndex; i < Queue.Count; i++)
					UiList.Items.Add(Queue[i].ShortName);
			List<String> visibleList = new List<String>();
			for (int i = CursorIndex; i < Queue.Count; i++)
				visibleList.Add(Queue[i].ShortName);
			foreach (String item in selected) {
				int index = visibleList.FindIndex(obj => obj == item);
				if (index == -1) continue;
				UiList.SetItemChecked(index, true);
			}
		}

		// "Извлекает" следющий в очереди элемент
		public Item TakeNext() {
			if (Queue.Count < CursorIndex) {
				Item empty = new Item();
				empty.ShortName = empty.FullName = null;
				return empty;
			};
			return Queue[CursorIndex++];
		}

		// Добавляет элемент item в очередь. Флаг isHistory определяет, нужно ли учитывать индекс головы
		public bool AddItem(Item item, bool isHistory = false) {
			int index = Queue.FindIndex(obj => obj.ShortName == item.ShortName);
			if (isHistory) {
				if (index != -1) return false;
			} else if (index != -1 && index >= CursorIndex)
				return false; // Элемент найден, и находится в видимой части очереди
			else if (index != -1 && index < CursorIndex) {
				// Элемент найден, и находится за видимой частью очереди
				Queue.RemoveAt(index);
				CursorIndex--;
			}
			Queue.Add(item);
			return true;
		}

		// "Восстанавливает" раннее извлеченный элемент из очереди
		public Item TakePrevious() {
			if (CursorIndex > 1)
				return Queue[--CursorIndex - 1];
			Item empty = new Item();
			empty.ShortName = empty.FullName = null;
			return empty;
		}

		// Читает раннее извлеченный элемент, но не восстанавливает его в очереди
		public Item ReadPrevious() {
			if (CursorIndex > 1)
				return Queue[CursorIndex - 2];
			Item empty = new Item();
			empty.ShortName = empty.FullName = null;
			return empty;
		}

		// Читает следющий элемент, но не извлекает его из очереди
		public Item ReadNext() {
			if (Queue.Count < CursorIndex + 1) {
				Item empty = new Item();
				empty.ShortName = empty.FullName = null;
				return empty;
			}
			return Queue[CursorIndex];
		}

		// Читает только что извлеченный элемент
		public Item ReadNow() {
			return Queue[CursorIndex - 1];
		}

		// Очищает очередь
		public void Clear(bool isHistory = false) {
			if (isHistory) { // Для истории неважна голова
				Queue.Clear();
				CursorIndex = 0;
				return;
			}
			CursorIndex = Queue.Count;
		}

		// Удаляет элемент из очереди по его имени
		public void RemoveItem(String shortName) {
			int index = Queue.FindIndex(obj => obj.ShortName == shortName);
			if (index == -1) return;
			if (index <= CursorIndex)
				CursorIndex--;
			Queue.RemoveAt(index);
		}
	}
}
