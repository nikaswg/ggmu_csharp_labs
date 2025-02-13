using PolygonLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PolygonManagerLibrary
{
    public class PolygonManager
    {
        public List<Polygon> Polygons { get; private set; } = new List<Polygon>();
        private const string filePath = @"C:\Users\Никита\Downloads\lab8\test.txt";

        public void LoadFromFile()
        {
            Polygons.Clear();

            try
            {
                if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
                {
                    GenerateDefaultPolygons();
                }
                else
                {
                    foreach (var line in File.ReadLines(filePath))
                    {
                        var parts = line.Split(' ');
                        var sides = parts.Take(parts.Length - 1).Select(double.Parse).ToArray();
                        var color = parts.Last();

                        Polygon polygon;
                        if (sides.Length == 3)
                        {
                            polygon = new Triangle(sides, color);
                        }
                        else if (sides.Length == 2)
                        {
                            polygon = new Rectangle(sides, color);
                        }
                        else if (sides.Length >= 3)
                        {
                            polygon = new RegularPolygon(sides, color);
                        }
                        else
                        {
                            continue; // Неизвестный тип многоугольника
                        }

                        Polygons.Add(polygon);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                GenerateDefaultPolygons();
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка формата данных в файле: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неожиданная ошибка: {ex.Message}");
            }
        }

        private void GenerateDefaultPolygons()
        {
            var random = new Random();
            Polygons.Clear();

            for (int i = 0; i < 10; i++)
            {
                int sidesCount = random.Next(3, 6);
                double[] sides = new double[sidesCount];

                for (int j = 0; j < sidesCount; j++)
                {
                    sides[j] = random.Next(1, 11);
                }

                if (i < 2)
                {
                    Polygons.Add(new Triangle(new[] { 3.0, 4.0, 5.0 }, "red"));
                }
                else if (i == 2)
                {
                    Polygons.Add(new Triangle(new[] { 6.0, 8.0, 10.0 }, "purple"));
                }
                else
                {
                    Polygons.Add(new RegularPolygon(sides, "blue"));
                }
            }

            SaveToFile();
        }

        public void SaveToFile()
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var polygon in Polygons)
                    {
                        var sides = string.Join(" ", polygon.GetSides());
                        writer.WriteLine($"{sides} {polygon.Color}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла неожиданная ошибка: {ex.Message}");
            }
        }

        public void AddPolygon(double[] sides, string color)
        {
            Polygon polygon;

            if (sides.Length == 3)
            {
                polygon = new Triangle(sides, color);
            }
            else if (sides.Length == 2)
            {
                polygon = new Rectangle(sides, color);
            }
            else if (sides.Length >= 3)
            {
                polygon = new RegularPolygon(sides, color);
            }
            else
            {
                throw new ArgumentException("Неизвестный тип многоугольника.");
            }

            Polygons.Add(polygon);
            SaveToFile();
        }

        public void EditPolygon(int index, double[] sides, string color)
        {
            if (index < 0 || index >= Polygons.Count)
            {
                throw new ArgumentOutOfRangeException("Индекс вне диапазона.");
            }

            Polygon newPolygon;

            if (sides.Length == 3)
            {
                newPolygon = new Triangle(sides, color);
            }
            else if (sides.Length == 2)
            {
                newPolygon = new Rectangle(sides, color);
            }
            else if (sides.Length >= 3)
            {
                newPolygon = new RegularPolygon(sides, color);
            }
            else
            {
                throw new ArgumentException("Неизвестный тип многоугольника.");
            }

            Polygons[index] = newPolygon;
            SaveToFile();
        }

        public List<string> GetPolygonInfo()
        {
            return Polygons.Select(polygon =>
                $"{polygon.Color} - S = {polygon.Area()} - P = {polygon.Perimeter()} - Длины сторон = {string.Join(", ", polygon.GetSides())}").ToList();
        }

        public List<string> SortAndDisplay()
        {
            var sortedPolygons = Polygons.OrderBy(p => p.Area()).ToList();
            return sortedPolygons.Select(polygon =>
                $"{polygon.Color} - S = {polygon.Area()} - P = {polygon.Perimeter()} - Длины сторон = {string.Join(", ", polygon.GetSides())}").ToList();
        }

        public List<string> CalculateRedRightTrianglePerimeters()
        {
            var results = new List<string>();

            foreach (var polygon in Polygons.OfType<Triangle>())
            {
                if (polygon.Color.Equals("red", StringComparison.OrdinalIgnoreCase) && IsRightAngled(polygon))
                {
                    double perimeter = polygon.Perimeter();
                    results.Add($"Периметр красного прямоугольного треугольника: {perimeter}");
                }
            }

            // Вывод содержимого results в консоль
            Console.WriteLine("Содержимое results:");
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

            if (results.Count == 0)
            {
                Console.WriteLine("Нет красных прямоугольных треугольников.");
            }

            return results;
        }

        private bool IsRightAngled(Triangle triangle)
        {
            double[] sides = triangle.GetSides();

            // Проверяем все три условия для прямоугольного треугольника
            return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < 1e-10 ||
                   Math.Abs(sides[0] * sides[0] + sides[2] * sides[2] - sides[1] * sides[1]) < 1e-10 ||
                   Math.Abs(sides[1] * sides[1] + sides[2] * sides[2] - sides[0] * sides[0]) < 1e-10;
        }
    }
}