using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові числа для дат
            Random rnd = new Random();

            // введемо саме просте бех перевірок додаткови - просто для показу реалізації
            Date date1 = new Date(rnd.Next(1, 29),
                rnd.Next(1, 13), rnd.Next(1991, DateTime.Now.Year + 1)),
                date2 = new Date(rnd.Next(1, 29),
                rnd.Next(1, 13), rnd.Next(1991, DateTime.Now.Year + 1));

            // Виведення
            Console.WriteLine($"\n\tЗадана 1 дата: {date1.ToString()}");
            Console.WriteLine($"\tЗадана 2 дата: {date2.ToString()}");

            Console.WriteLine($"\n\tРізниця: {Math.Abs(date1 - date2)} днів");

            int days = rnd.Next(1, ushort.MaxValue);
            Console.WriteLine($"\n\tДодамо до 1 дати наступну кількість днів: {days}");
            Console.WriteLine($"\n\tРезультат: {(date1 + days).ToString()}");

            // оновлення випадкових днів
            days = rnd.Next(1, ushort.MaxValue);
            Console.WriteLine($"\n\tВіднімемо від 2 дати наступну кількість днів: {days}");
            Console.WriteLine($"\n\tРезультат: {(date2 - days).ToString()}");

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
