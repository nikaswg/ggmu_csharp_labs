using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using TheaterTickets.Core;
using System.Collections.Generic;
using System.ComponentModel;

namespace TheaterTickets
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Spectacle> _spectacles;
        private ObservableCollection<Customer> _customers;

        public MainWindow()
        {
            InitializeComponent();

            // Инициализация данных
            _spectacles = new ObservableCollection<Spectacle>
            {
                new Spectacle("Гамлет", DateTime.Today.AddDays(7), 100, 150, 30),
                new Spectacle("Ромео и Джульетта", DateTime.Today.AddDays(14), 80, 120, 25),
                new Spectacle("Что-то", DateTime.Today.AddYears(-3), 100, 150, 30)
            };

            _customers = new ObservableCollection<Customer>();

            cmbSpectacle.ItemsSource = _spectacles;
            dgSpectacles.ItemsSource = _spectacles;
            dgCustomers.ItemsSource = _customers;

            txtCustomer.GotFocus += (s, e) =>
            {
                if (txtCustomer.Text == "Введите имя")
                    txtCustomer.Text = "";
            };

            txtCustomer.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtCustomer.Text))
                    txtCustomer.Text = "Введите имя";
            };
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            var spectacle = cmbSpectacle.SelectedItem as Spectacle;
            if (spectacle == null) return;

            TicketType type;
            switch (cmbType.SelectedIndex)
            {
                case 0: type = TicketType.Parter; break;
                case 1: type = TicketType.Balcony; break;
                case 2: type = TicketType.Lodge; break;
                default: type = TicketType.Parter; break;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 1)
            {
                MessageBox.Show("Некорректное количество!");
                return;
            }

            if (!spectacle.SellTickets(type, quantity))
            {
                MessageBox.Show("Недостаточно билетов!");
                return;
            }

            var customerName = txtCustomer.Text.Trim();
            if (customerName == "Введите имя") customerName = "Гость";

            var customer = _customers.FirstOrDefault(c => c.Name == customerName);
            if (customer == null)
            {
                customer = new Customer(customerName);
                _customers.Add(customer);
            }

            var discount = customer.GetDiscount();
            var purchase = new Purchase(spectacle, type, quantity, discount, DateTime.Now);
            customer.AddPurchase(purchase);
            dgCustomers.Items.Refresh();
        }

        private void ShowDetails_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.DataContext is Customer customer)
            {
                var yearStart = new DateTime(DateTime.Now.Year, 1, 1);

                // Общая детализация
                var allDetails = customer.Purchases
                    .SelectMany(p => p.Value)
                    .GroupBy(p => p.Spectacle.Name)
                    .Select(g => $"{g.Key}: {g.Sum(p => p.Quantity)} билетов");

                // Покупки за год
                var yearDetails = customer.PurchasesThisYear
                    .GroupBy(p => p.Spectacle.Name)
                    .Select(g => $"{g.Key}: {g.Sum(p => p.Quantity)} билетов");

                var message = $"Общая детализация:\n{string.Join("\n", allDetails)}\n\n" +
                              $"Покупки за {DateTime.Now.Year} год:\n{string.Join("\n", yearDetails)}";

                MessageBox.Show(message, $"Детализация {customer.Name}");
            }
        }
    }

    public class Customer : INotifyPropertyChanged
    {
        public string Name { get; }
        public Dictionary<Spectacle, List<Purchase>> Purchases { get; }

        public int TotalTickets => Purchases.Values.SelectMany(p => p).Sum(p => p.Quantity);
        public bool IsRegular => TotalTickets >= 10;
        public string DiscountDisplay => $"{GetDiscount() * 100}%";

        public List<Purchase> PurchasesThisYear
        {
            get
            {
                var yearStart = new DateTime(DateTime.Now.Year, 1, 1);
                return Purchases
                    .SelectMany(p => p.Value)
                    .Where(p => p.PurchaseDate >= yearStart)
                    .ToList();
            }
        }

        public Customer(string name)
        {
            Name = name;
            Purchases = new Dictionary<Spectacle, List<Purchase>>();
        }

        public void AddPurchase(Purchase purchase)
        {
            if (!Purchases.ContainsKey(purchase.Spectacle))
                Purchases[purchase.Spectacle] = new List<Purchase>();

            Purchases[purchase.Spectacle].Add(purchase);
            OnPropertyChanged(nameof(TotalTickets));
            OnPropertyChanged(nameof(IsRegular));
            OnPropertyChanged(nameof(DiscountDisplay));
            OnPropertyChanged(nameof(PurchasesThisYear));
        }

        public decimal GetDiscount()
        {
            if (TotalTickets >= 30) return 0.15m;
            if (TotalTickets >= 10) return 0.10m;
            return 0m;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class Purchase
    {
        public Spectacle Spectacle { get; }
        public TicketType Type { get; }
        public int Quantity { get; }
        public decimal TotalPrice { get; }
        public decimal FinalPrice { get; }
        public DateTime PurchaseDate { get; }

        public Purchase(Spectacle spectacle, TicketType type, int quantity, decimal discount, DateTime purchaseDate)
        {
            Spectacle = spectacle;
            Type = type;
            Quantity = quantity;
            PurchaseDate = purchaseDate;

            switch (type)
            {
                case TicketType.Parter: TotalPrice = 5 * quantity; break;
                case TicketType.Balcony: TotalPrice = 3 * quantity; break;
                case TicketType.Lodge: TotalPrice = 10 * quantity; break;
                default: TotalPrice = 0; break;
            }

            FinalPrice = TotalPrice * (1 - discount);
        }
    }
}