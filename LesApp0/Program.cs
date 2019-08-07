using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // випадкові числа для створення точок
            Random rnd = new Random();

            // створення двох точкок через масив, бо проще заповнити в циклі значеннями
            Point3D[] points = new Point3D[2];

            // заповнення даними
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point3D(
                    rnd.Next(sbyte.MinValue, sbyte.MaxValue),
                    rnd.Next(sbyte.MinValue, sbyte.MaxValue),
                    rnd.Next(sbyte.MinValue, sbyte.MaxValue));
            }

            // Виведення точок
            Console.WriteLine("\n\tЗадані точки:\n");
            for (int i = 0; i < points.Length; i++)
            {
                Console.WriteLine($"\t- точка {i + 1}: {points[i]}");
            }

            Console.Write("\n\tДодані точки: ");
            Console.WriteLine($"{points[0] + points[1]}");

            Console.Write("\n\tВідняті точки: ");
            Console.WriteLine($"{points[0] - points[1]}");

            Console.Write($"\n\tЗміщена 1-ша точка до {double.PositiveInfinity}: ");
            Console.WriteLine($"{++points[0]}");

            Console.Write($"\n\tЗміщена 2-га точка до {double.NegativeInfinity}: ");
            Console.WriteLine($"{--points[1]}");

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
