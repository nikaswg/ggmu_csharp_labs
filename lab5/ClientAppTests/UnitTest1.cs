using NUnit.Framework;
using ClientLibrary;

namespace ClientLibrary.Tests
{
    [TestFixture]
    public class ClientParserTests
    {
        [Test]
        public void ParseClients_MultipleClients_ReturnsCorrectClientData()
        {
            var parser = new ClientParser();
            string inputData = "������ ����, 1234567890, ivanov@example.com, ������\n" +
                               "������ ����, 0987654321, petrov@example.com, �����-���������\n" +
                               "������� �����, 1122334455, sidorov@example.com, �����������";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(3));
            Assert.That(clients[0].FullName, Is.EqualTo("������ ����"));
            Assert.That(clients[1].FullName, Is.EqualTo("������ ����"));
            Assert.That(clients[2].FullName, Is.EqualTo("������� �����"));
        }

        [Test]
        public void ParseClients_EmptyData_ReturnsEmptyList()
        {
            var parser = new ClientParser();
            string inputData = "";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(0));
        }

        [Test]
        public void ParseClients_SingleClient_ReturnsOneClient()
        {
            var parser = new ClientParser();
            string inputData = "������ ����, 1234567890, ivanov@example.com, ������";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(1));
            Assert.That(clients[0].FullName, Is.EqualTo("������ ����"));
        }

        [Test]
        public void ParseClients_InvalidFormat_ReturnsEmptyList()
        {
            var parser = new ClientParser();
            string inputData = "������������ ������";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(0));
        }

        [Test]
        public void ParseClients_ExtraSpaces_ReturnsCorrectClientData()
        {
            var parser = new ClientParser();
            string inputData = " ������ ���� ,  1234567890 ,   ivanov@example.com ,   ������ \n" +
                               " ������ ���� , 0987654321 , petrov@example.com , �����-��������� ";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(2));
            Assert.That(clients[0].FullName, Is.EqualTo("������ ����"));
            Assert.That(clients[1].FullName, Is.EqualTo("������ ����"));
        }

        [Test]
        public void ParseClients_EmptyLine_ReturnsCorrectClientData()
        {
            var parser = new ClientParser();
            string inputData = "������ ����, 1234567890, ivanov@example.com, ������\n\n������ ����, 0987654321, petrov@example.com, �����-���������";

            var clients = parser.ParseClients(inputData);

            Assert.That(clients.Count, Is.EqualTo(2));
            Assert.That(clients[0].FullName, Is.EqualTo("������ ����"));
            Assert.That(clients[1].FullName, Is.EqualTo("������ ����"));
        }
    }
}