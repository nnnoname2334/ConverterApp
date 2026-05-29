using System;
using System.Windows;

namespace ConverterApp
{
    /// <summary>
    /// Код-бихайнд главного окна приложения.
    /// Отвечает только за взаимодействие с UI: получение ввода,
    /// вызов логики и вывод результата. Бизнес-логика — в ConverterLogic.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Инициализация компонентов, описанных в XAML
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия кнопки "Конвертировать".
        /// Вызывается автоматически при нажатии buttonConvert.
        /// </summary>
        private void buttonConvert_Click(object sender, RoutedEventArgs e)
        {
            // ---- Шаг 1: Валидация ввода ----
            // Принимаем как точку, так и запятую в качестве разделителя дробной части
            string inputText = textBoxInput.Text.Trim().Replace(',', '.');

            // double.TryParse возвращает false, если строка не является числом,
            // и НЕ бросает исключение — это безопасный способ проверки
            inputText = inputText.Replace('.', ',');
            if (!double.TryParse(inputText, out double inputValue))
            {
                // Показываем понятное сообщение об ошибке через MessageBox
                MessageBox.Show(
                    "Пожалуйста, введите корректное числовое значение.\nПример: 100 или 36.6",
                    "Ошибка ввода",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                // Очищаем поле результата и выходим из метода
                textBlockResult.Text = "";
                return;
            }

            // ---- Шаг 2: Конвертация ----
            try
            {
                double result;
                string unitLabel;

                // Определяем, какой RadioButton выбран, и вызываем нужный метод логики
                if (radioMetersToKm.IsChecked == true)
                {
                    result = ConverterLogic.MetersToKilometers(inputValue);
                    unitLabel = "км";
                }
                else if (radioKmToMeters.IsChecked == true)
                {
                    result = ConverterLogic.KilometersToMeters(inputValue);
                    unitLabel = "м";
                }
                else if (radioCelsiusToF.IsChecked == true)
                {
                    result = ConverterLogic.CelsiusToFahrenheit(inputValue);
                    unitLabel = "°F";
                }
                else // radioFToCelsius
                {
                    result = ConverterLogic.FahrenheitToCelsius(inputValue);
                    unitLabel = "°C";
                }

                // ---- Шаг 3: Отображение результата ----
                // Форматирование: до 4 знаков после запятой, с заменой точки на запятую для русской локали
                textBlockResult.Text = $"{result:F4} {unitLabel}";
            }
            catch (ArgumentException ex)
            {
                // Перехватываем ошибки, которые выбрасывает ConverterLogic
                // (например, при вводе отрицательного расстояния)
                MessageBox.Show(
                    ex.Message,
                    "Ошибка конвертации",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                textBlockResult.Text = "";
            }
        }
    }
}
