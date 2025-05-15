using System;
using MatrixExceptions;

namespace MatrixLibrary
{
    /// <summary>
    /// Представляет матрицу и поддерживает базовые математические операции.
    /// </summary>
    public class Matrix
    {
        private readonly double[,] _data;

        /// <summary>
        /// Количество строк в матрице.
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Количество столбцов в матрице.
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Создает матрицу заданного размера.
        /// </summary>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
                throw new InvalidMatrixSizeException("Размеры матрицы должны быть положительными числами.");

            Rows = rows;
            Columns = columns;
            _data = new double[rows, columns];
        }

        /// <summary>
        /// Индексатор для доступа к элементам матрицы.
        /// </summary>
        public double this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }

        /// <summary>
        /// Сложение двух матриц.
        /// </summary>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new MatrixSizeMismatchException("Матрицы должны быть одинакового размера для сложения.");

            var result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] = a[i, j] + b[i, j];

            return result;
        }

        /// <summary>
        /// Вычитание двух матриц.
        /// </summary>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
                throw new MatrixSizeMismatchException("Матрицы должны быть одинакового размера для вычитания.");

            var result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < a.Columns; j++)
                    result[i, j] = a[i, j] - b[i, j];

            return result;
        }

        /// <summary>
        /// Умножение двух матриц.
        /// </summary>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
                throw new MatrixOperationException("Число столбцов первой матрицы должно соответствовать числу строк второй матрицы.");

            var result = new Matrix(a.Rows, b.Columns);
            for (int i = 0; i < a.Rows; i++)
                for (int j = 0; j < b.Columns; j++)
                    for (int k = 0; k < a.Columns; k++)
                        result[i, j] += a[i, k] * b[k, j];

            return result;
        }

        /// <summary>
        /// Возвращает строковое представление матрицы.
        /// </summary>
        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                    sb.Append($"{_data[i, j],8:F2} ");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}