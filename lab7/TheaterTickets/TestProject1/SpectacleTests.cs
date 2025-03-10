using System;
using NUnit.Framework;
using TheaterTickets.Core;

namespace TheaterTickets.Tests
{
    public class SpectacleTests
    {
        [Test]
        public void SellTickets_ShouldReduceAvailableTickets()
        {
            // Arrange
            var spectacle = new Spectacle("Гамлет", DateTime.Today, 100, 150, 30);

            // Act
            var result = spectacle.SellTickets(TicketType.Parter, 10);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(spectacle.TicketStats[TicketType.Parter], Is.EqualTo("90/10")); // Осталось 90 билетов, продано 10
        }

        [Test]
        public void SellTickets_ShouldNotSellIfNotEnoughTickets()
        {
            // Arrange
            var spectacle = new Spectacle("Гамлет", DateTime.Today, 100, 150, 30);

            // Act
            var result = spectacle.SellTickets(TicketType.Parter, 110);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(spectacle.TicketStats[TicketType.Parter], Is.EqualTo("100/0")); // Осталось 100 билетов, продано 0
        }
    }
}