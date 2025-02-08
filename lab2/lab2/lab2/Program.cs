using System;
using PolynomialLibrary;
using PolynomialLibrary.Exceptions;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var p1 = new Polynomial(3, 3, 4);
                var p2 = new Polynomial(5, 1);

                var sum = p1 + p2;
                Console.WriteLine($"Сумма: {sum}");

                var product = p1 * p2;
                Console.WriteLine($"Произведение: {product}");
            }
            catch (PolynomialException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}