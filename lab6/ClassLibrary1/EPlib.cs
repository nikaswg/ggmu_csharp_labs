using System;

namespace EPL
{
    public class Event
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public AdditionalInfo Info { get; set; }

        public Event(string title, DateTime date, AdditionalInfo info)
        {
            Title = title;
            Date = date;
            Info = info;
        }

        public class AdditionalInfo
        {
            public string Location { get; set; }
            public string Description { get; set; }

            public AdditionalInfo(string location, string description)
            {
                Location = location;
                Description = description;
            }
        }
    }
}