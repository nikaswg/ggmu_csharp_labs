using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TheaterTickets.Core
{
    public class Spectacle : INotifyPropertyChanged
    {
        private Dictionary<TicketType, (int Available, int Sold)> _tickets;

        public string Name { get; }
        public DateTime Date { get; }

        public Spectacle(string name, DateTime date, int parter, int balcony, int lodge)
        {
            Name = name;
            Date = date;
            _tickets = new Dictionary<TicketType, (int, int)>
            {
                [TicketType.Parter] = (parter, 0),
                [TicketType.Balcony] = (balcony, 0),
                [TicketType.Lodge] = (lodge, 0)
            };
        }

        public bool SellTickets(TicketType type, int quantity)
        {
            if (_tickets[type].Available < quantity) return false;

            _tickets[type] = (_tickets[type].Available - quantity, _tickets[type].Sold + quantity);
            OnPropertyChanged(nameof(TicketStats));
            return true;
        }

        public Dictionary<TicketType, string> TicketStats
        {
            get
            {
                var stats = new Dictionary<TicketType, string>();
                stats[TicketType.Parter] = $"{_tickets[TicketType.Parter].Available}/{_tickets[TicketType.Parter].Sold}";
                stats[TicketType.Balcony] = $"{_tickets[TicketType.Balcony].Available}/{_tickets[TicketType.Balcony].Sold}";
                stats[TicketType.Lodge] = $"{_tickets[TicketType.Lodge].Available}/{_tickets[TicketType.Lodge].Sold}";
                return stats;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public enum TicketType { Parter, Balcony, Lodge }
}