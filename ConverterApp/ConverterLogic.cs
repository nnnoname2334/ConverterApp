using System;

namespace ConverterApp
{
    /// <summary>
    /// Статический класс, содержащий логику конвертации величин.
    /// Вынесен отдельно от UI, чтобы его можно было тестировать независимо.
    /// </summary>
    public static class ConverterLogic
    {
        /// <summary>
        /// Конвертирует метры в километры.
        /// </summary>
        /// <param name="meters">Расстояние в метрах (не может быть отрицательным)</param>
        /// <returns>Расстояние в километрах</returns>
        /// <exception cref="ArgumentException">Если переданное значение отрицательное</exception>
        public static double MetersToKilometers(double meters)
        {
            if (meters < 0)
                throw new ArgumentException("Расстояние не может быть отрицательным.");

            return meters / 1000.0;
        }

        /// <summary>
        /// Конвертирует километры в метры.
        /// </summary>
        /// <param name="kilometers">Расстояние в километрах (не может быть отрицательным)</param>
        /// <returns>Расстояние в метрах</returns>
        /// <exception cref="ArgumentException">Если переданное значение отрицательное</exception>
        public static double KilometersToMeters(double kilometers)
        {
            if (kilometers < 0)
                throw new ArgumentException("Расстояние не может быть отрицательным.");

            return kilometers * 1000.0;
        }

        /// <summary>
        /// Конвертирует градусы Цельсия в градусы Фаренгейта.
        /// Формула: F = C * 9/5 + 32
        /// </summary>
        /// <param name="celsius">Температура в градусах Цельсия</param>
        /// <returns>Температура в градусах Фаренгейта</returns>
        public static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9.0 / 5.0 + 32.0;
        }

        /// <summary>
        /// Конвертирует градусы Фаренгейта в градусы Цельсия.
        /// Формула: C = (F - 32) * 5/9
        /// </summary>
        /// <param name="fahrenheit">Температура в градусах Фаренгейта</param>
        /// <returns>Температура в градусах Цельсия</returns>
        public static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32.0) * 5.0 / 9.0;
        }
    }
}
