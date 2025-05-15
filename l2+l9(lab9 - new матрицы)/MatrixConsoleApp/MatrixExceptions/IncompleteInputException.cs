using System;

namespace MatrixExceptions
{
    /// <summary>
    /// Исключение при неполном вводе строки матрицы.
    /// </summary>
    public class IncompleteInputException : Exception
    {
        public IncompleteInputException()
            : base("Ввод строки матрицы неполный. Пожалуйста, проверьте количество введённых элементов.") { }

        public IncompleteInputException(string message)
            : base(message) { }
    }
}