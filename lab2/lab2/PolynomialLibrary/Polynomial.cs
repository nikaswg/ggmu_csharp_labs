using System;
using PolynomialLibrary.Exceptions;

namespace PolynomialLibrary
{
    public class Polynomial
    {
        private double[] coefficients;

        public Polynomial(params double[] coeffs)
        {
            if (coeffs == null)
                throw new PolynomialNullException();

            if (coeffs.Length == 0)
                throw new PolynomialDegreeException();

            coefficients = new double[coeffs.Length];
            for (int i = 0; i < coeffs.Length; i++)
            {
                if (double.IsInfinity(coeffs[i]) || double.IsNaN(coeffs[i]))
                    throw new PolynomialOverflowException();
                coefficients[i] = coeffs[i];
            }
        }

        public double GetCoefficient(int degree)
        {
            if (degree < 0 || degree >= coefficients.Length)
            {
                return 0; // Default coefficient for non-existent degrees
            }
            return coefficients[degree];
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new PolynomialNullException();

            int maxLength = Math.Max(p1.coefficients.Length, p2.coefficients.Length);
            double[] resultCoeffs = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                double coeff1 = (i < p1.coefficients.Length) ? p1.coefficients[i] : 0;
                double coeff2 = (i < p2.coefficients.Length) ? p2.coefficients[i] : 0;

                // Check for overflow
                if (double.IsInfinity(coeff1 + coeff2))
                    throw new PolynomialOverflowException();

                resultCoeffs[i] = coeff1 + coeff2;
            }

            return new Polynomial(resultCoeffs);
        }

        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new PolynomialNullException();

            int degree1 = p1.coefficients.Length;
            int degree2 = p2.coefficients.Length;
            double[] resultCoeffs = new double[degree1 + degree2 - 1];

            for (int i = 0; i < degree1; i++)
            {
                for (int j = 0; j < degree2; j++)
                {
                    resultCoeffs[i + j] += p1.coefficients[i] * p2.coefficients[j];
                }
            }

            return new Polynomial(resultCoeffs);
        }

        public override string ToString()
        {
            if (coefficients.Length == 0)
                return "0";

            string[] terms = new string[coefficients.Length];
            int count = 0;

            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] != 0)
                {
                    terms[count++] = $"{coefficients[i]}x^{i}";
                }
            }

            if (count == 0)
                return "0";

            Array.Sort(terms, 0, count, StringComparer.OrdinalIgnoreCase);
            Array.Reverse(terms, 0, count); // Sort in descending order of degree

            return string.Join(" + ", terms, 0, count);
        }

        public override bool Equals(object obj)
        {
            if (obj is Polynomial other)
            {
                if (coefficients.Length != other.coefficients.Length)
                    return false;

                for (int i = 0; i < coefficients.Length; i++)
                {
                    if (coefficients[i] != other.coefficients[i])
                        return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (var coeff in coefficients)
            {
                hash = hash * 31 + coeff.GetHashCode();
            }
            return hash;
        }
    }
}