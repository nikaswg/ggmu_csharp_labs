using System;

namespace MatrixExceptions
{
    /// <summary>
    /// Исключение при вводе некорректного размера матрицы.
    /// </summary>
    public class InvalidMatrixSizeException : Exception
    {
        public InvalidMatrixSizeException()
            : base("Размеры матрицы должны быть положительными числами.") { }

        public InvalidMatrixSizeException(string message)
            : base(message) { }
    }
}