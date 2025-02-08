using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EPL;

namespace EPApp
{
    public partial class Form1 : Form
    {
        private EventManager eventManager;

        public Form1()
        {
            InitializeComponent();
            eventManager = new EventManager(100); // Максимум 100 мероприятий

            // Заполнение ComboBox для режимов
            comboBoxMode.Items.AddRange(new string[]
            {
                "Добавление",
                "Редактирование",
                "Просмотр",
                "Просмотр всех мероприятий на заданный день",
                "Вывод дат проведения указанного мероприятия после заданной даты",
                "Подсчет среднего количества мероприятий по каждому дню недели"
            });
            comboBoxMode.SelectedIndexChanged += comboBoxMode_SelectedIndexChanged;

            // Скрываем элементы управления на старте
            HideAllControls();
        }

        private void HideAllControls()
        {
            buttonViewEvents.Visible = false;
            textBoxTitle.Visible = false;
            dateTimePicker.Visible = false;
            textBoxLocation.Visible = false;
            textBoxDescription.Visible = false;
            buttonAddEvent.Visible = false;
            buttonEditEvent.Visible = false;
            listBoxEvents.Visible = false;
            comboBoxEvents.Visible = false; // Скрываем ComboBox для выбора мероприятия
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            baton.Visible = false;
            baton1.Visible = false;
            baton3.Visible = false;
        }

        private void ShowControls(bool isEditing)
        {
            if (isEditing)
            {
                comboBoxEvents.Visible = true;
                comboBoxEvents.SelectedIndexChanged += comboBoxEvents_SelectedIndexChanged; // Подключаем обработчик
                UpdateComboBoxEvents(); // Заполняем ComboBox с событиями
            }
            else
            {
                textBoxTitle.Visible = true;
                dateTimePicker.Visible = true;
                textBoxLocation.Visible = true;
                textBoxDescription.Visible = true;
                buttonAddEvent.Visible = true;
            }

            listBoxEvents.Visible = true;
            buttonEditEvent.Visible = isEditing;
        }

        private void UpdateComboBoxEvents()
        {
            comboBoxEvents.Items.Clear();
            foreach (var eventItem in eventManager.GetEvents())
            {
                comboBoxEvents.Items.Add($"{eventItem.Title} - {eventItem.Date.ToShortDateString()}");
            }
        }

        private void ShowInputControls()
        {
            textBoxTitle.Visible = true;
            dateTimePicker.Visible = true;
            textBoxLocation.Visible = true;
            textBoxDescription.Visible = true;
            buttonAddEvent.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            listBoxEvents.Visible = false;
            buttonViewEvents.Visible = false;
        }

        private void ShowEditControls()
        {
            buttonViewEvents.Visible = false;
            listBoxEvents.Visible = true;
            buttonEditEvent.Visible = true;
            comboBoxEvents.Visible = true;
            listBoxEvents.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBoxTitle.Visible = true;
            dateTimePicker.Visible = true;
            textBoxLocation.Visible = true;
            textBoxDescription.Visible = true;
            UpdateComboBoxEvents(); // Заполняем ComboBox с событиями при редактировании
        }

        private void ShowViewControls()
        {
            listBoxEvents.Visible = true;
            buttonViewEvents.Visible = true;
        }

        private void ShowDefineDateControls()
        {
            buttonViewEvents.Visible = false;
            textBoxTitle.Visible = false;
            dateTimePicker.Visible = true;
            textBoxLocation.Visible = false;
            textBoxDescription.Visible = false;
            buttonAddEvent.Visible = false;
            buttonEditEvent.Visible = false;
            listBoxEvents.Visible = true;
            comboBoxEvents.Visible = false; // Скрываем ComboBox для выбора мероприятия
            label1.Visible = false;
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            baton.Visible = true;
            baton1.Visible = false;
        }

        private void ShowDateBeforeControls()
        {
            buttonViewEvents.Visible = false;
            textBoxTitle.Visible = true;
            dateTimePicker.Visible = true;
            textBoxLocation.Visible = false;
            textBoxDescription.Visible = false;
            buttonAddEvent.Visible = false;
            buttonEditEvent.Visible = false;
            listBoxEvents.Visible = true;
            comboBoxEvents.Visible = false; // Скрываем ComboBox для выбора мероприятия
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            baton.Visible = false;
            baton1.Visible = true;
        }

        private void ShowAVGofWeekDays()
        {
            buttonViewEvents.Visible = false;
            textBoxTitle.Visible = false;
            dateTimePicker.Visible = false;
            textBoxLocation.Visible = false;
            textBoxDescription.Visible = false;
            buttonAddEvent.Visible = false;
            buttonEditEvent.Visible = false;
            listBoxEvents.Visible = true;
            comboBoxEvents.Visible = false; // Скрываем ComboBox для выбора мероприятия
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            baton.Visible = false;
            baton1.Visible = false;
            baton3.Visible = true; 
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllControls();
            switch (comboBoxMode.SelectedItem.ToString())
            {
                case "Добавление":
                    CleanList();
                    ShowInputControls();
                    break;
                case "Редактирование":
                    CleanList();
                    ShowEditControls();
                    break;
                case "Просмотр":
                    CleanList();
                    ShowViewControls();
                    break;
                case "Просмотр всех мероприятий на заданный день":
                    CleanList();
                    ShowDefineDateControls();
                    break;
                case "Вывод дат проведения указанного мероприятия после заданной даты":
                    CleanList();
                    ShowDateBeforeControls();
                    break;
                case "Подсчет среднего количества мероприятий по каждому дню недели":
                    CleanList();
                    ShowAVGofWeekDays();
                    break;
            }
        }

        private void CleanList()
        { listBoxEvents.Items.Clear(); }

        private void ClearInputFields()
        {
            textBoxTitle.Clear();
            textBoxLocation.Clear();
            textBoxDescription.Clear();
            dateTimePicker.Value = DateTime.Now; // Возвращаем к текущей дате
        }

        private void UpdateEventList()
        {
            listBoxEvents.Items.Clear();
            foreach (var eventItem in eventManager.GetEvents())
            {
                listBoxEvents.Items.Add($"{eventItem.Title} - {eventItem.Date.ToShortDateString()} - {eventItem.Info.Location} - {eventItem.Info.Description}");
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEvents.SelectedItem != null)
            {
                string selectedEvent = listBoxEvents.SelectedItem.ToString();
                string[] eventDetails = selectedEvent.Split(new[] { " - " }, StringSplitOptions.None);
                string title = eventDetails[0];
                DateTime eventDate = DateTime.Parse(eventDetails[1]);
                string location = eventDetails[2];
                string description = eventDetails[3];

                var selectedEventItem = eventManager.GetEvents().FirstOrDefault(eventItem => eventItem.Title == title && eventItem.Date.Date == eventDate.Date);

                if (selectedEventItem != null)
                {
                    textBoxTitle.Text = selectedEventItem.Title;
                    dateTimePicker.Value = selectedEventItem.Date;
                    textBoxLocation.Text = selectedEventItem.Info.Location;
                    textBoxDescription.Text = selectedEventItem.Info.Description;
                }
            }
        }

        private void buttonViewEvents_Click(object sender, EventArgs e)
        {
            UpdateEventList();
        }

        private void buttonAddEvent_Click_1(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text;
            DateTime date = dateTimePicker.Value;
            string location = textBoxLocation.Text;
            string description = textBoxDescription.Text;

            var additionalInfo = new Event.AdditionalInfo(location, description);
            Event newEvent = new Event(title, date, additionalInfo);
            eventManager.AddEvent(newEvent);
            UpdateEventList();
            ClearInputFields(); // Очищаем поля после добавления
        }

        private void comboBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEvents.SelectedItem != null)
            {
                string selectedEvent = comboBoxEvents.SelectedItem.ToString();
                string[] eventDetails = selectedEvent.Split(new[] { " - " }, StringSplitOptions.None);
                string title = eventDetails[0];
                DateTime eventDate = DateTime.Parse(eventDetails[1]);

                var selectedEventItem = eventManager.GetEvents()
                    .FirstOrDefault(eventItem => eventItem.Title == title && eventItem.Date.Date == eventDate.Date);

                if (selectedEventItem != null)
                {
                    textBoxTitle.Text = selectedEventItem.Title;
                    dateTimePicker.Value = selectedEventItem.Date;
                    textBoxLocation.Text = selectedEventItem.Info.Location;
                    textBoxDescription.Text = selectedEventItem.Info.Description;
                }
            }
        }

        private void buttonEditEvent_Click(object sender, EventArgs e)
        {
            if (comboBoxEvents.SelectedItem != null)
            {
                string selectedEvent = comboBoxEvents.SelectedItem.ToString();
                string[] eventDetails = selectedEvent.Split(new[] { " - " }, StringSplitOptions.None);
                string title = eventDetails[0];
                DateTime eventDate = DateTime.Parse(eventDetails[1]);

                var selectedEventItem = eventManager.GetEvents()
                    .FirstOrDefault(eventItem => eventItem.Title == title && eventItem.Date.Date == eventDate.Date);

                if (selectedEventItem != null)
                {
                    string newTitle = textBoxTitle.Text;
                    DateTime newDate = dateTimePicker.Value;
                    string newLocation = textBoxLocation.Text;
                    string newDescription = textBoxDescription.Text;

                    eventManager.EditEvent(selectedEventItem, newTitle, newDate, newLocation, newDescription);

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void baton_Click(object sender, EventArgs e)
        {
            ShowDefineDateControls();
            DateTime selectedDate = dateTimePicker.Value;
            var eventsOnSelectedDate = eventManager.GetEvents()
                .Where(eventItem => eventItem.Date.Date == selectedDate.Date) // Изменено на eventItem
                .ToList();

            listBoxEvents.Items.Clear();
            foreach (var eventItem in eventsOnSelectedDate)
            {
                listBoxEvents.Items.Add($"{eventItem.Title} - {eventItem.Date.ToShortDateString()} - {eventItem.Info.Location} - {eventItem.Info.Description}");
            }

            if (eventsOnSelectedDate.Count == 0)
            {
                MessageBox.Show("Нет мероприятий на выбранную дату.");
            }
        }

        private void baton1_Click(object sender, EventArgs e)
        {
            string eventName = textBoxTitle.Text;
            DateTime selectedDate = dateTimePicker.Value;

            var eventsAfterDate = eventManager.GetEvents()
                .Where(eventItem => eventItem.Title.Equals(eventName, StringComparison.OrdinalIgnoreCase) && eventItem.Date > selectedDate)
                .ToList();

            listBoxEvents.Items.Clear();
            foreach (var eventItem in eventsAfterDate)
            {
                listBoxEvents.Items.Add($"{eventItem.Date.ToShortDateString()} - {eventItem.Info.Location} - {eventItem.Info.Description}");
            }

            if (eventsAfterDate.Count == 0)
            {
                MessageBox.Show("Нет мероприятий после указанной даты.");
            }
        }

        private void baton3_Click(object sender, EventArgs e)
        {
            var eventsCountByDay = new Dictionary<DayOfWeek, int>();
            var daysWithEvents = new HashSet<DayOfWeek>(); // Для отслеживания дней с мероприятиями

            // Инициализация словаря для дней недели
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                eventsCountByDay[day] = 0;
            }

            // Подсчет мероприятий
            foreach (var eventItem in eventManager.GetEvents())
            {
                DayOfWeek dayOfWeek = eventItem.Date.DayOfWeek;
                eventsCountByDay[dayOfWeek]++;
                daysWithEvents.Add(dayOfWeek); // Добавляем день в множество
            }

            // Подсчет среднего количества мероприятий
            var averageEventsByDay = new Dictionary<DayOfWeek, double>();
            foreach (var kvp in eventsCountByDay)
            {
                // Делим количество мероприятий на количество дней с мероприятиями
                averageEventsByDay[kvp.Key] = daysWithEvents.Count > 0 ? (double)kvp.Value / daysWithEvents.Count : 0;
            }

            // Отображение результатов
            listBoxEvents.Items.Clear();
            foreach (var kvp in averageEventsByDay)
            {
                listBoxEvents.Items.Add($"{kvp.Key}: {kvp.Value:F2} мероприятий в среднем");
            }
        }
            }
        }
 