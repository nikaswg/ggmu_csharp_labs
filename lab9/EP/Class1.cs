using System;

namespace PolynomialLibrary.Exceptions
{
    public class PolynomialException : Exception
    {
        public PolynomialException(string message) : base(message) { }
    }

    public class PolynomialNullException : PolynomialException
    {
        public PolynomialNullException() : base("Коэффициенты полинома не могут быть null.") { }
    }

    public class PolynomialDegreeException : PolynomialException
    {
        public PolynomialDegreeException() : base("Должен быть хотя бы один коэффициент.") { }
    }

    public class PolynomialOverflowException : PolynomialException
    {
        public PolynomialOverflowException() : base("Переполнение при вычислении полинома.") { }
    }

    public class PolynomialZeroCoefficientsException : PolynomialException
    {
        public PolynomialZeroCoefficientsException() : base("Полином состоит только из нулевых коэффициентов.") { }
    }

    public class PolynomialSingleCoefficientException : PolynomialException
    {
        public PolynomialSingleCoefficientException() : base("Полином с единственным коэффициентом не может быть использован для вычислений.") { }
    }
}