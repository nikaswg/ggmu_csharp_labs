using System;

namespace MatrixExceptions
{
    /// <summary>
    /// Исключение при несовпадении размеров матриц.
    /// </summary>
    public class MatrixSizeMismatchException : Exception
    {
        public MatrixSizeMismatchException()
            : base("Размеры матриц не совпадают.") { }

        public MatrixSizeMismatchException(string message)
            : base(message) { }
    }
}