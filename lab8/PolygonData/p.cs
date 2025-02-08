using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PolygonLibrary
{
    public abstract class Polygon : IComparable<Polygon>
    {
        protected double[] sides;
        protected string color;

        protected Polygon(double[] sides, string color)
        {
            this.sides = sides;
            this.color = color;
        }

        public abstract double Area();

        public virtual string GetInfo()
        {
            return $"{GetType().Name}: Стороны = {string.Join(", ", sides)}, Цвет = {color}";
        }

        public int CompareTo(Polygon other)
        {
            return Area().CompareTo(other.Area());
        }

        public string Color => color;

        public double[] GetSides() => sides;

        public double Perimeter() => sides.Sum();
    }

    public class Triangle : Polygon
    {
        public Triangle(double[] sides, string color) : base(sides, color)
        {
            if (sides.Length != 3)
            {
                throw new ArgumentException("Для треугольника должно быть ровно 3 стороны.");
            }

            // Проверка на возможность существования треугольника
            if (sides[0] + sides[1] <= sides[2] ||
                sides[0] + sides[2] <= sides[1] ||
                sides[1] + sides[2] <= sides[0])
            {
                throw new ArgumentException("Указанные стороны не могут образовать треугольник.");
            }
        }

        public override double Area()
        {
            double semiPerimeter = Perimeter() / 2;
            return Math.Sqrt(semiPerimeter *
                             (semiPerimeter - sides[0]) *
                             (semiPerimeter - sides[1]) *
                             (semiPerimeter - sides[2]));
        }
    }

    public class Rectangle : Polygon
    {
        public Rectangle(double[] sides, string color) : base(sides, color)
        {
            if (sides.Length != 2)
            {
                throw new ArgumentException("Для прямоугольника должно быть ровно 2 стороны.");
            }
        }

        public override double Area()
        {
            return sides[0] * sides[1];
        }
    }

    public class RegularPolygon : Polygon
    {
        public RegularPolygon(double[] sides, string color) : base(sides, color)
        {
            if (sides.Length < 3)
            {
                throw new ArgumentException("Должно быть не менее 3 сторон для многоугольника.");
            }
        }

        public override double Area()
        {
            int n = sides.Length;
            double perimeter = Perimeter();
            double apothem = sides[0] / (2 * Math.Tan(Math.PI / n));
            return (perimeter * apothem) / 2;
        }
    }
}