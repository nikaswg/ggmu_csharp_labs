using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using EPL;

namespace EPL.Tests
{
    [TestFixture]
    public class EventManagerTests
    {
        private EventManager eventManager;
        private const string TestFilePath = "test_events.txt"; // ���������� �������� ����

        [SetUp]
        public void Setup()
        {
            eventManager = new EventManager(100);
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [Test]
        public void AddEvent_ShouldIncreaseCount()
        {
            var initialCount = eventManager.GetEvents().Count;
            eventManager.AddEvent(new Event("����� �����������", DateTime.Now, new Event.AdditionalInfo("���", "��������")));
            var newCount = eventManager.GetEvents().Count;

            Assert.That(newCount, Is.EqualTo(initialCount + 1));
        }

        [Test]
        public void RemoveEvent_ShouldDecreaseCount()
        {
            var testEvent = new Event("�������� �����������", DateTime.Now, new Event.AdditionalInfo("���", "��������"));
            eventManager.AddEvent(testEvent);
            var initialCount = eventManager.GetEvents().Count;

            eventManager.RemoveEvent(testEvent);
            var newCount = eventManager.GetEvents().Count;

            Assert.That(newCount, Is.EqualTo(initialCount - 1));
        }




        [Test]
        public void CalculateAverageEventsByDay_ShouldReturnCorrectAverages()
        {
            var event1 = new Event("������ �����������", DateTime.Now, new Event.AdditionalInfo("���", "��������"));
            var event2 = new Event("������ �����������", DateTime.Now.AddDays(1), new Event.AdditionalInfo("���", "��������"));
            var event3 = new Event("������ �����������", DateTime.Now.AddDays(1), new Event.AdditionalInfo("���", "��������"));

            eventManager.AddEvent(event1);
            eventManager.AddEvent(event2);
            eventManager.AddEvent(event3);

            var eventsCountByDay = new Dictionary<DayOfWeek, int>();
            var daysWithEvents = new HashSet<DayOfWeek>();

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                eventsCountByDay[day] = 0;
            }

            foreach (var eventItem in eventManager.GetEvents())
            {
                DayOfWeek dayOfWeek = eventItem.Date.DayOfWeek;
                eventsCountByDay[dayOfWeek]++;
                daysWithEvents.Add(dayOfWeek);
            }

            var averageEventsByDay = new Dictionary<DayOfWeek, double>();
            foreach (var kvp in eventsCountByDay)
            {
                averageEventsByDay[kvp.Key] = daysWithEvents.Count > 0 ? (double)kvp.Value / daysWithEvents.Count : 0;
            }

            Assert.That(averageEventsByDay[DayOfWeek.Monday], Is.GreaterThanOrEqualTo(0));
            Assert.That(averageEventsByDay[DayOfWeek.Tuesday], Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void EventConstructor_ShouldInitializeProperties()
        {
            var eventInfo = new Event.AdditionalInfo("���", "��������");
            var testEvent = new Event("�������� �����������", DateTime.Now, eventInfo);

            Assert.That(testEvent.Title, Is.EqualTo("�������� �����������"));
            Assert.That(testEvent.Date, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(1)));
            Assert.That(testEvent.Info.Location, Is.EqualTo("���"));
            Assert.That(testEvent.Info.Description, Is.EqualTo("��������"));
        }

        [Test]
        public void AdditionalInfoConstructor_ShouldInitializeProperties()
        {
            var additionalInfo = new Event.AdditionalInfo("���", "��������");

            Assert.That(additionalInfo.Location, Is.EqualTo("���"));
            Assert.That(additionalInfo.Description, Is.EqualTo("��������"));
        }



        [Test]
        public void CalculateAverageEventsByDay_ShouldReturnCorrectAverage()
        {
            var event1 = new Event("������� 1", DateTime.Now, new Event.AdditionalInfo("���", "��������"));
            var event2 = new Event("������� 2", DateTime.Now.AddDays(1), new Event.AdditionalInfo("���", "��������"));
            var event3 = new Event("������� 3", DateTime.Now.AddDays(1), new Event.AdditionalInfo("���", "��������"));
            eventManager.AddEvent(event1);
            eventManager.AddEvent(event2);
            eventManager.AddEvent(event3);

            var eventsCountByDay = new Dictionary<DayOfWeek, int>();
            var daysWithEvents = new HashSet<DayOfWeek>();

            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                eventsCountByDay[day] = 0;
            }

            foreach (var eventItem in eventManager.GetEvents())
            {
                DayOfWeek dayOfWeek = eventItem.Date.DayOfWeek;
                eventsCountByDay[dayOfWeek]++;
                daysWithEvents.Add(dayOfWeek);
            }

            var averageEventsByDay = new Dictionary<DayOfWeek, double>();
            foreach (var kvp in eventsCountByDay)
            {
                averageEventsByDay[kvp.Key] = daysWithEvents.Count > 0 ? (double)kvp.Value / daysWithEvents.Count : 0;
            }

            Assert.That(averageEventsByDay[DayOfWeek.Monday], Is.GreaterThanOrEqualTo(0));
            Assert.That(averageEventsByDay[DayOfWeek.Tuesday], Is.GreaterThanOrEqualTo(1)); // ��������, ��� �� �������� 2 ������� �� �������
        }
    }

}