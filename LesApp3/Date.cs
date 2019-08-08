using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    /// <summary>
    /// Дата
    /// </summary>
    class Date
    {
        private DateTime date = new DateTime();
        /// <summary>
        /// День
        /// </summary>
        public int Day
        {
            get { return date.Day; }
            set { date = new DateTime(value, date.Month, date.Year); }
        }
        /// <summary>
        /// Місяць
        /// </summary>
        public int Month
        {
            get { return date.Month; }
            set { date = new DateTime(date.Day, value, date.Year); }
        }
        /// <summary>
        /// Рік
        /// </summary>
        public int Year
        {
            get { return date.Year; }
            set { date = new DateTime(date.Day, date.Month, value); }
        }

        public Date() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="day">день</param>
        /// <param name="month">місяць</param>
        /// <param name="year">рік</param>
        public Date(int day, int month, int year)
        {
            date = new DateTime(year, month, day);
        }

        /// <summary>
        /// Внутрішній конвертер в DateTime
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private static DateTime ConvertToDateTime(Date date)
            => new DateTime(date.Year, date.Month, date.Day);
        /// <summary>
        /// Внутрішній конвертер в Date
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private static Date ConvertToDate(DateTime datetime)
            => new Date(datetime.Day, datetime.Month, datetime.Year);

        /// <summary>
        /// Корвертер в DateTime
        /// </summary>
        /// <param name="date"></param>
        public static explicit operator DateTime(Date date)
            => ConvertToDateTime(date);
        /// <summary>
        /// Корвертер в Date
        /// </summary>
        /// <param name="date"></param>
        public static explicit operator Date(DateTime datetime)
            => ConvertToDate(datetime);

        /// <summary>
        /// Різниця дат в днях
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static int operator -(Date date1, Date date2)
            => ((DateTime)date1 - (DateTime)date2).Days;

        /// <summary>
        /// Додати певну кількість днів
        /// </summary>
        /// <param name="date"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date operator +(Date date, int days)
            => (Date)((DateTime)date).AddDays(days);

        /// <summary>
        /// Відняти певну кількість днів
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date operator -(Date date, int days)
            => (Date)((DateTime)date).AddDays(-days);

        public override string ToString()
            => date.ToShortDateString();

    }
}
