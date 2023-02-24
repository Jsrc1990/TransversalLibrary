using System;

namespace TransversalLibrary
{
    /// <summary>
    /// Define las extensiones de las fechas y horas
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Cambia el año de la fecha
        /// </summary>
        /// <param name="date">La fecha y hora</param>
        /// <param name="year">El año a cambiar</param>
        /// <returns>La fecha con el año cambiado</returns>
        public static DateTime ChangeYear(this DateTime date, int year)
        {
            // you can also provide Hour, Minute, Second and Millisecond
            return new DateTime(year, date.Month, date.Day);
        }
    }
}