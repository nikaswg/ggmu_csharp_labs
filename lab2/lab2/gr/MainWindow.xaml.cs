using System;
using System.Windows;
using PolynomialLibrary;
using PolynomialLibrary.Exceptions;

namespace PolynomialGraphApp
{
    public partial class MainWindow : Window
    {
        private Polynomial[] polynomials;

        public MainWindow()
        {
            InitializeComponent();
            InitializePolynomials();
        }

        private void InitializePolynomials()
        {
            try
            {
                polynomials = new Polynomial[]
                {
                    new Polynomial(3, 3, 4),         // Нормальный полином 1: 4x^2 + 3x + 3
                    new Polynomial(5, 1),             // Нормальный полином 2: 1x + 5
                    new Polynomial(0),                 // Полином с нулевыми коэффициентами: 0
                    new Polynomial(1),                 // Полином с одним коэффициентом: 1
                    null,                              // Полином с null коэффициентами
                    
                    // Заготовка для случая с переполнением
                    new Polynomial(double.MaxValue, double.MaxValue), // Полином, который может вызвать переполнение
                    
                    // Заготовка для случая с несколькими нулевыми коэффициентами
                    // new Polynomial(0, 0, 0),       // Удалено
                };

                PolynomialSelector.ItemsSource = new string[]
                {
                    "Полином 1 (3x^0 + 3x^1 + 4x^2)",
                    "Полином 2 (5x^0 + 1x^1)",
                    "Полином с нулевыми коэффициентами (0)",
                    "Полином с одним коэффициентом (1)",
                    "Полином с null коэффициентами",
                    "Полином с переполнением (MaxValue)",
                    // "Полином с несколькими нулевыми коэффициентами (0, 0, 0)" // Удалено
                };
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Ошибка инициализации полиномов: {ex.Message}";
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверяем, что выбранный индекс валиден
                if (PolynomialSelector.SelectedIndex < 0)
                {
                    ResultTextBlock.Text = "Выберите полином.";
                    return;
                }

                int selectedIndex = PolynomialSelector.SelectedIndex;

                // Получаем выбранный полином
                Polynomial selectedPolynomial = polynomials[selectedIndex];

                // Проверка на null
                if (selectedPolynomial == null)
                {
                    ResultTextBlock.Text = "Ошибка: Выбранный полином является null.";
                    return;
                }

                // Обработка случаев для сложения и умножения
                if (selectedIndex == 0 || selectedIndex == 1) // Если выбраны нормальные полиномы
                {
                    Polynomial p1 = polynomials[0];
                    Polynomial p2 = polynomials[1];

                    // Проверка на null
                    if (p1 == null || p2 == null)
                    {
                        ResultTextBlock.Text = "Ошибка: Один из полиномов является null.";
                        return;
                    }

                    try
                    {
                        Polynomial sum = p1 + p2;
                        Polynomial product = p1 * p2;

                        ResultTextBlock.Text = $"Сумма: {sum}\nПроизведение: {product}";
                    }
                    catch (PolynomialOverflowException ex)
                    {
                        ResultTextBlock.Text = $"Ошибка при вычислении: {ex.Message}";
                    }
                }
                else if (selectedIndex == 5) // Полином с переполнением
                {
                    ResultTextBlock.Text = "Ошибка: Полином вызывает переполнение.";
                }
                else if (selectedIndex == 2) // Полином с нулевыми коэффициентами
                {
                    throw new PolynomialZeroCoefficientsException();
                }
                else if (selectedIndex == 3) // Полином с одним коэффициентом (1)
                {
                    throw new PolynomialSingleCoefficientException();
                }
                else
                {
                    ResultTextBlock.Text = $"Ошибка: Полином с индексом {selectedIndex} не может быть использован для вычислений.";
                }
            }
            catch (PolynomialNullException ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
            }
            catch (PolynomialDegreeException ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
            }
            catch (PolynomialOverflowException ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
            }
            catch (PolynomialZeroCoefficientsException ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
            }
            catch (PolynomialSingleCoefficientException ex)
            {
                ResultTextBlock.Text = $"Ошибка: {ex.Message}";
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = $"Неизвестная ошибка: {ex.Message}";
            }
        }

        private void PolynomialSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Простой вывод для проверки работоспособности
            ResultTextBlock.Text = $"Выбранный индекс: {PolynomialSelector.SelectedIndex}";
        }
    }
}