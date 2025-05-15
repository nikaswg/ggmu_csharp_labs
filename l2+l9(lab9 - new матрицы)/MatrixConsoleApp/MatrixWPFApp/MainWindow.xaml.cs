using System.Windows;
using System.Windows.Controls;
using MatrixLibrary;
using MatrixExceptions;

namespace MatrixWpfApp
{
    public partial class MainWindow : Window
    {
        private int rowsA, colsA, rowsB, colsB;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateMatrices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(RowsABox.Text, out rowsA) || rowsA <= 0)
                    throw new InvalidMatrixSizeException("Некорректное количество строк матрицы A");

                if (!int.TryParse(ColsABox.Text, out colsA) || colsA <= 0)
                    throw new InvalidMatrixSizeException("Некорректное количество столбцов матрицы A");

                if (!int.TryParse(RowsBBox.Text, out rowsB) || rowsB <= 0)
                    throw new InvalidMatrixSizeException("Некорректное количество строк матрицы B");

                if (!int.TryParse(ColsBBox.Text, out colsB) || colsB <= 0)
                    throw new InvalidMatrixSizeException("Некорректное количество столбцов матрицы B");

                MatrixAInputs.Items.Clear();
                MatrixBInputs.Items.Clear();

                for (int i = 0; i < rowsA; i++)
                    MatrixAInputs.Items.Add(CreateRow(colsA));

                for (int i = 0; i < rowsB; i++)
                    MatrixBInputs.Items.Add(CreateRow(colsB));

                ResultBox.Text = "Матрицы успешно созданы. Введите значения.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка создания матриц");
            }
        }

        private StackPanel CreateRow(int columns)
        {
            var panel = new StackPanel { Orientation = Orientation.Horizontal };
            for (int i = 0; i < columns; i++)
            {
                panel.Children.Add(new TextBox
                {
                    Width = 40,
                    Margin = new Thickness(2)
                });
            }
            return panel;
        }

        private Matrix ReadMatrix(ItemsControl control, int rows, int cols)
        {
            var matrix = new Matrix(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                if (control.Items[i] is StackPanel rowPanel)
                {
                    if (rowPanel.Children.Count != cols)
                        throw new IncompleteInputException();

                    for (int j = 0; j < cols; j++)
                    {
                        var box = rowPanel.Children[j] as TextBox;
                        if (!double.TryParse(box.Text, out double value))
                            throw new MatrixNumberFormatException($"Ошибка ввода числа в позиции [{i + 1},{j + 1}]");
                        matrix[i, j] = value;
                    }
                }
            }

            return matrix;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = ReadMatrix(MatrixAInputs, rowsA, colsA);
                var B = ReadMatrix(MatrixBInputs, rowsB, colsB);
                var result = A + B;
                ResultBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сложения матриц");
            }
        }

        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = ReadMatrix(MatrixAInputs, rowsA, colsA);
                var B = ReadMatrix(MatrixBInputs, rowsB, colsB);
                var result = A - B;
                ResultBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка вычитания матриц");
            }
        }

        private void Mul_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var A = ReadMatrix(MatrixAInputs, rowsA, colsA);
                var B = ReadMatrix(MatrixBInputs, rowsB, colsB);
                var result = A * B;
                ResultBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка умножения матриц");
            }
        }
    }
}