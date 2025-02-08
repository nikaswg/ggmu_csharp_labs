using System;
using System.Collections.Generic;
using System.IO;

namespace EPL
{
    public class EventManager
    {
        private List<Event> events; // Список мероприятий
        private const string FilePath = "events.txt"; // Путь к файлу

        public EventManager(int capacity)
        {
            events = new List<Event>(capacity);
            LoadEvents(); // Загружаем мероприятия из файла

            // Проверяем, есть ли события, и добавляем начальные, если нет
            if (events.Count == 0)
            {
                AddInitialEvents();
            }
        }

        private void AddInitialEvents()
        {
            var initialEvents = new List<Event>
            {
                new Event("Первое мероприятие", DateTime.Now, new Event.AdditionalInfo("Конференц-зал", "Описание первого мероприятия")),
                new Event("Второе мероприятие", DateTime.Now.AddDays(1), new Event.AdditionalInfo("Аудитория", "Описание второго мероприятия")),
                new Event("Третье мероприятие", DateTime.Now.AddDays(2), new Event.AdditionalInfo("Офис", "Описание третьего мероприятия")),
                new Event("Чайная конференция", DateTime.Now.AddDays(-5), new Event.AdditionalInfo("Аудитория", "обычная конференция")),
                new Event("Чайная конференция", DateTime.Now.AddDays(-3), new Event.AdditionalInfo("Аудитория", "обычная конференция")),
                new Event("Чайная конференция", DateTime.Now.AddDays(-1), new Event.AdditionalInfo("Аудитория", "обычная конференция")),
                new Event("Четвертое мероприятие", DateTime.Now.AddDays(3), new Event.AdditionalInfo("Конференц-зал", "Описание четвертого мероприятия")),
                new Event("Пятое мероприятие", DateTime.Now.AddDays(3), new Event.AdditionalInfo("Конференц-зал", "Описание пятого мероприятия")),
                new Event("Шестое мероприятие", DateTime.Now.AddDays(3), new Event.AdditionalInfo("Конференц-зал", "Описание шестого мероприятия")),
                new Event("Седьмое мероприятие", DateTime.Now.AddDays(3), new Event.AdditionalInfo("Конференц-зал", "Описание седьмого мероприятия")),
                new Event("Восьмое мероприятие", DateTime.Now.AddDays(3), new Event.AdditionalInfo("Аудитория", "Описание восьмого мероприятия")),
                new Event("Девятое мероприятие", DateTime.Now.AddDays(3), new Event.AdditionalInfo("Аудитория", "Описание девятого мероприятия")),
                new Event("Десятое мероприятие", DateTime.Now.AddDays(3), new Event.AdditionalInfo("Аудитория", "Описание десятого мероприятия")),
            };

            foreach (var initialEvent in initialEvents)
            {
                AddEvent(initialEvent); // Добавляем начальные мероприятия
            }
        }

        public void AddEvent(Event newEvent)
        {
            events.Add(newEvent); // Добавляем новое мероприятие
            SaveEvents(); // Сохраняем изменения в файл
        }

        public List<Event> GetEvents()
        {
            return events; // Возвращаем список мероприятий
        }

        public void RemoveEvent(Event eventToRemove)
        {
            events.Remove(eventToRemove); // Удаляем мероприятие
            SaveEvents(); // Сохраняем изменения в файл
        }

        public void EditEvent(Event eventToEdit, string newTitle, DateTime newDate, string newLocation, string newDescription)
        {
            if (eventToEdit != null)
            {
                eventToEdit.Title = newTitle;
                eventToEdit.Date = newDate;
                eventToEdit.Info.Location = newLocation;
                eventToEdit.Info.Description = newDescription;
                SaveEvents(); // Сохраняем изменения после редактирования
            }
        }

        public void SaveEvents()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var eventItem in events)
                {
                    string line = $"{eventItem.Title};{eventItem.Date};{eventItem.Info.Location};{eventItem.Info.Description}";
                    writer.WriteLine(line); // Записываем мероприятие в файл
                }
            }
        }

        public void LoadEvents()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(';');
                        if (parts.Length == 4 && DateTime.TryParse(parts[1], out DateTime date))
                        {
                            // Создаем экземпляр AdditionalInfo
                            var additionalInfo = new Event.AdditionalInfo(parts[2], parts[3]);
                            // Создаем событие
                            Event loadedEvent = new Event(parts[0], date, additionalInfo);
                            events.Add(loadedEvent); // Добавляем загруженное мероприятие
                        }
                    }
                }
            }
        }
    }
}