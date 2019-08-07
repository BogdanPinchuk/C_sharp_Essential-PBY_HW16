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

        public Date(int day, int month, int year)
        {
            date = new DateTime(day, month, year);
        }

        /// <summary>
        /// Сума дат
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date operator +(Date date1, Date date2)
        {
            this.date = date

            return new Date(date1.Day + date2.Day,
                date1.Month + date2.Month,
                date1.Year + date2.Year);
        }

        /// <summary>
        /// Різниця дат
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date operator -(Date date1, Date date2)
        {
            return new Date(date1.Day - date2.Day,
                date1.Month - date2.Month,
                date1.Year - date2.Year);
        }

        /// <summary>
        /// Сума дат
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date operator +(Date date1, int date2)
        {
            return new Date(date1.Day + date2.Day,
                date1.Month + date2.Month,
                date1.Year + date2.Year);
        }

        /// <summary>
        /// Різниця дат
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Date operator -(Date date1, Date date2)
        {
            return new Date(date1.Day - date2.Day,
                date1.Month - date2.Month,
                date1.Year - date2.Year);
        }

    }
}
