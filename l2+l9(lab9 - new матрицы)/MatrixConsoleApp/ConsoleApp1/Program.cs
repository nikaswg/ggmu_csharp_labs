using System;
using MatrixLibrary;

namespace MatrixConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Работа с матрицами ===\n");

            Console.WriteLine("Введите размерность матрицы A (строки столбцы):");
            var sizeA = ReadSize();
            var matrixA = ReadMatrix(sizeA.rows, sizeA.cols, "A");

            Console.WriteLine("\nВведите размерность матрицы B (строки столбцы):");
            var sizeB = ReadSize();
            var matrixB = ReadMatrix(sizeB.rows, sizeB.cols, "B");

            while (true)
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1. Сложение (A + B)");
                Console.WriteLine("2. Вычитание (A - B)");
                Console.WriteLine("3. Умножение (A * B)");
                Console.WriteLine("0. Выход");
                Console.Write("Ваш выбор: ");
                var choice = Console.ReadLine();

                try
                {
                    Matrix result = null;
                    switch (choice)
                    {
                        case "1":
                            result = matrixA + matrixB;
                            Console.WriteLine("\nРезультат сложения A + B:");
                            Console.WriteLine(result);
                            break;
                        case "2":
                            result = matrixA - matrixB;
                            Console.WriteLine("\nРезультат вычитания A - B:");
                            Console.WriteLine(result);
                            break;
                        case "3":
                            result = matrixA * matrixB;
                            Console.WriteLine("\nРезультат умножения A * B:");
                            Console.WriteLine(result);
                            break;
                        case "0":
                            Console.WriteLine("Выход...");
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Повторите попытку.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        static (int rows, int cols) ReadSize()
        {
            while (true)
            {
                Console.Write("> ");
                var input = Console.ReadLine();
                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int rows) &&
                    int.TryParse(parts[1], out int cols) &&
                    rows > 0 && cols > 0)
                {
                    return (rows, cols);
                }
                Console.WriteLine("Неверный ввод. Введите два положительных числа через пробел (например: 2 3).");
            }
        }

        static Matrix ReadMatrix(int rows, int cols, string name)
        {
            var matrix = new Matrix(rows, cols);
            Console.WriteLine($"Введите элементы матрицы {name} построчно (через пробел):");

            for (int i = 0; i < rows; i++)
            {
                while (true)
                {
                    Console.Write($"Строка {i + 1}: ");
                    var input = Console.ReadLine();
                    var values = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (values.Length != cols)
                    {
                        Console.WriteLine($"Ошибка: требуется {cols} элементов.");
                        continue;
                    }

                    try
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            matrix[i, j] = double.Parse(values[j]);
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка ввода. Убедитесь, что все элементы — числа.");
                    }
                }
            }

            return matrix;
        }
    }
}