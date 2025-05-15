using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixExceptions
{
    /// <summary>
    /// Ошибка при некорректном вводе числа (заменяет FormatException)
    /// </summary>
    public class MatrixNumberFormatException : Exception
    {
        public MatrixNumberFormatException()
            : base("Некорректный ввод числа. Введите число в правильном формате.") { }

        public MatrixNumberFormatException(string message)
            : base(message) { }
    }

    /// <summary>
    /// Ошибка при невозможности выполнить операцию (заменяет InvalidOperationException)
    /// </summary>
    public class MatrixOperationException : Exception
    {
        public MatrixOperationException()
            : base("Невозможно выполнить операцию с матрицами.") { }

        public MatrixOperationException(string message)
            : base(message) { }
    }
}
