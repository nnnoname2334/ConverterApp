using ConverterApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConverterApp.Tests
{
    /// <summary>
    /// Тесты для класса ConverterLogic.
    /// Покрывают: корректные данные, граничные значения, некорректные данные (исключения).
    /// Тестируются только методы класса логики — без UI!
    /// </summary>
    [TestClass]
    public class ConverterLogicTests
    {
        // ============================================================
        //  МЕТРЫ → КИЛОМЕТРЫ
        // ============================================================

        /// <summary>
        /// Корректные данные: 1000 метров = 1 километр
        /// </summary>
        [TestMethod]
        public void MetersToKilometers_1000Meters_Returns1Km()
        {
            // Arrange — подготовка данных
            double input = 1000;
            double expected = 1.0;

            // Act — выполнение метода
            double result = ConverterLogic.MetersToKilometers(input);

            // Assert — проверка результата (допуск 0.0001 из-за double)
            Assert.AreEqual(expected, result, 0.0001);
        }

        /// <summary>
        /// Корректные данные: 500 метров = 0.5 километра
        /// </summary>
        [TestMethod]
        public void MetersToKilometers_500Meters_Returns0Point5Km()
        {
            double result = ConverterLogic.MetersToKilometers(500);
            Assert.AreEqual(0.5, result, 0.0001);
        }

        /// <summary>
        /// Граничное значение: 0 метров = 0 километров
        /// </summary>
        [TestMethod]
        public void MetersToKilometers_ZeroMeters_ReturnsZero()
        {
            double result = ConverterLogic.MetersToKilometers(0);
            Assert.AreEqual(0.0, result, 0.0001);
        }

        /// <summary>
        /// Граничное значение: результат не равен неправильному ожидаемому значению
        /// </summary>
        [TestMethod]
        public void MetersToKilometers_1000Meters_ResultNotEquals2()
        {
            double result = ConverterLogic.MetersToKilometers(1000);
            Assert.AreNotEqual(2.0, result);
        }

        /// <summary>
        /// Граничное значение: результат конвертации 5000 м меньше 10 км
        /// </summary>
        [TestMethod]
        public void MetersToKilometers_5000Meters_ResultLessThan10()
        {
            double result = ConverterLogic.MetersToKilometers(5000);
            Assert.IsTrue(result < 10.0);
        }

        /// <summary>
        /// Некорректные данные: отрицательное расстояние бросает ArgumentException
        /// </summary>
        [TestMethod]
        public void MetersToKilometers_NegativeValue_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => ConverterLogic.MetersToKilometers(-100));
        }

        // ============================================================
        //  КИЛОМЕТРЫ → МЕТРЫ
        // ============================================================

        /// <summary>
        /// Корректные данные: 1 километр = 1000 метров
        /// </summary>
        [TestMethod]
        public void KilometersToMeters_1Km_Returns1000Meters()
        {
            double result = ConverterLogic.KilometersToMeters(1.0);
            Assert.AreEqual(1000.0, result, 0.0001);
        }

        /// <summary>
        /// Корректные данные: 2.5 километра = 2500 метров
        /// </summary>
        [TestMethod]
        public void KilometersToMeters_2Point5Km_Returns2500Meters()
        {
            double result = ConverterLogic.KilometersToMeters(2.5);
            Assert.AreEqual(2500.0, result, 0.0001);
        }

        /// <summary>
        /// Граничное значение: 0 километров = 0 метров
        /// </summary>
        [TestMethod]
        public void KilometersToMeters_ZeroKm_ReturnsZero()
        {
            double result = ConverterLogic.KilometersToMeters(0);
            Assert.AreEqual(0.0, result, 0.0001);
        }

        /// <summary>
        /// Граничное значение: результат конвертации 1 км больше 500 м
        /// </summary>
        [TestMethod]
        public void KilometersToMeters_1Km_ResultGreaterThan500()
        {
            double result = ConverterLogic.KilometersToMeters(1.0);
            Assert.IsTrue(result > 500.0);
        }

        /// <summary>
        /// Граничное значение: 1 км НЕ равно 500 м
        /// </summary>
        [TestMethod]
        public void KilometersToMeters_1Km_ResultNotEquals500()
        {
            double result = ConverterLogic.KilometersToMeters(1.0);
            Assert.AreNotEqual(500.0, result);
        }

        /// <summary>
        /// Некорректные данные: отрицательное расстояние бросает ArgumentException
        /// </summary>
        [TestMethod]
        public void KilometersToMeters_NegativeValue_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(
                () => ConverterLogic.KilometersToMeters(-5.0));
        }

        // ============================================================
        //  ЦЕЛЬСИЙ → ФАРЕНГЕЙТ
        // ============================================================

        /// <summary>
        /// Корректные данные: 0°C = 32°F (точка замерзания воды)
        /// </summary>
        [TestMethod]
        public void CelsiusToFahrenheit_Zero_Returns32()
        {
            double result = ConverterLogic.CelsiusToFahrenheit(0);
            Assert.AreEqual(32.0, result, 0.0001);
        }

        /// <summary>
        /// Корректные данные: 100°C = 212°F (точка кипения воды)
        /// </summary>
        [TestMethod]
        public void CelsiusToFahrenheit_100_Returns212()
        {
            double result = ConverterLogic.CelsiusToFahrenheit(100);
            Assert.AreEqual(212.0, result, 0.0001);
        }

        /// <summary>
        /// Корректные данные: 37°C ≈ 98.6°F (температура тела)
        /// </summary>
        [TestMethod]
        public void CelsiusToFahrenheit_37_Returns98Point6()
        {
            double result = ConverterLogic.CelsiusToFahrenheit(37);
            Assert.AreEqual(98.6, result, 0.1);
        }

        /// <summary>
        /// Граничное значение: -40°C = -40°F (единственная точка совпадения шкал)
        /// </summary>
        [TestMethod]
        public void CelsiusToFahrenheit_Minus40_ReturnsMinus40()
        {
            double result = ConverterLogic.CelsiusToFahrenheit(-40);
            Assert.AreEqual(-40.0, result, 0.0001);
        }

        /// <summary>
        /// Граничное значение: результат для 100°C больше 200°F
        /// </summary>
        [TestMethod]
        public void CelsiusToFahrenheit_100C_ResultGreaterThan200F()
        {
            double result = ConverterLogic.CelsiusToFahrenheit(100);
            Assert.IsTrue(result > 200.0);
        }

        /// <summary>
        /// Граничное значение: результат для 0°C НЕ равен 0°F
        /// </summary>
        [TestMethod]
        public void CelsiusToFahrenheit_ZeroC_ResultNotEqualsZeroF()
        {
            double result = ConverterLogic.CelsiusToFahrenheit(0);
            Assert.AreNotEqual(0.0, result);
        }

        // ============================================================
        //  ФАРЕНГЕЙТ → ЦЕЛЬСИЙ
        // ============================================================

        /// <summary>
        /// Корректные данные: 32°F = 0°C
        /// </summary>
        [TestMethod]
        public void FahrenheitToCelsius_32_ReturnsZero()
        {
            double result = ConverterLogic.FahrenheitToCelsius(32);
            Assert.AreEqual(0.0, result, 0.0001);
        }

        /// <summary>
        /// Корректные данные: 212°F = 100°C
        /// </summary>
        [TestMethod]
        public void FahrenheitToCelsius_212_Returns100()
        {
            double result = ConverterLogic.FahrenheitToCelsius(212);
            Assert.AreEqual(100.0, result, 0.0001);
        }

        /// <summary>
        /// Корректные данные: 98.6°F ≈ 37°C
        /// </summary>
        [TestMethod]
        public void FahrenheitToCelsius_98Point6_Returns37()
        {
            double result = ConverterLogic.FahrenheitToCelsius(98.6);
            Assert.AreEqual(37.0, result, 0.1);
        }

        /// <summary>
        /// Граничное значение: -40°F = -40°C
        /// </summary>
        [TestMethod]
        public void FahrenheitToCelsius_Minus40_ReturnsMinus40()
        {
            double result = ConverterLogic.FahrenheitToCelsius(-40);
            Assert.AreEqual(-40.0, result, 0.0001);
        }

        /// <summary>
        /// Граничное значение: результат для 32°F не отрицательный
        /// </summary>
        [TestMethod]
        public void FahrenheitToCelsius_32F_ResultIsNotNegative()
        {
            double result = ConverterLogic.FahrenheitToCelsius(32);
            Assert.IsFalse(result < 0);
        }

        /// <summary>
        /// Граничное значение: 32°F НЕ равно 32°C
        /// </summary>
        [TestMethod]
        public void FahrenheitToCelsius_32F_ResultNotEquals32()
        {
            double result = ConverterLogic.FahrenheitToCelsius(32);
            Assert.AreNotEqual(32.0, result);
        }

        // ============================================================
        //  ПРОВЕРКА СИММЕТРИИ (обратная конвертация)
        // ============================================================

        /// <summary>
        /// Если перевести метры в км и обратно — получим исходное значение
        /// </summary>
        [TestMethod]
        public void MetersKilometers_RoundTrip_ReturnsOriginalValue()
        {
            double original = 1234.56;
            double km = ConverterLogic.MetersToKilometers(original);
            double backToMeters = ConverterLogic.KilometersToMeters(km);
            Assert.AreEqual(original, backToMeters, 0.0001);
        }

        /// <summary>
        /// Если перевести Цельсий в Фаренгейт и обратно — получим исходное значение
        /// </summary>
        [TestMethod]
        public void CelsiusFahrenheit_RoundTrip_ReturnsOriginalValue()
        {
            double original = 25.0;
            double fahrenheit = ConverterLogic.CelsiusToFahrenheit(original);
            double backToCelsius = ConverterLogic.FahrenheitToCelsius(fahrenheit);
            Assert.AreEqual(original, backToCelsius, 0.0001);
        }
    }
}
