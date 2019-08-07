using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Заопвнення даними для тестування
            // для випадкових значень довжин сторін
            Random rnd = new Random();

            // діапазон занчень для рандомного вибору 
            int min = 1,
                max = sbyte.MaxValue + 1;

            // створення масиву клинів (див. примітку в класі)
            Block[] wedge = new Block[2];

            for (int i = 0; i < wedge.Length; i++)
            {
                wedge[i] = new Block(rnd.Next(min, max),
                    rnd.Next(min, max),
                    rnd.Next(min, max),
                    rnd.Next(min, max));
            } 
            #endregion

            Show("\n\tВиведення даних про клини:\n");
            for (int i = 0; i < wedge.Length; i++)
            {
                Console.WriteLine(wedge[i].ToString());
            }

            Show("\n\tПеревірка рівності клинів (Equals):\n");
            Console.Write("1 - ");
            Console.WriteLine(wedge[0].ToString());
            Console.Write("2 - ");
            Console.WriteLine(wedge[1].ToString());
            Console.WriteLine($"\n\tРезультат: {wedge[0].Equals(wedge[1])}\n");

            Show("\n\tКопіювання силки 1-го клину і порівння з першим (Equals):\n");
            Block temp = wedge[0];
            Console.Write("3 - ");
            Console.WriteLine(temp.ToString());
            Console.WriteLine($"\n\tРезультат: {wedge[0].Equals(temp)}\n");

            Show("\n\tСтворення вручну 2-х клинів і порівння (Equals):\n");
            Block wedge1 = new Block(10, 5, 12, 13),
                wedge2 = new Block(5, 10, 12, 13);
            Console.Write("1 - ");
            Console.WriteLine(wedge1.ToString());
            Console.Write("2 - ");
            Console.WriteLine(wedge2.ToString());
            Console.WriteLine($"\n\tРезультат: {wedge1.Equals(wedge2)}\n");

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Відображення заголовку в кольорі
        /// </summary>
        /// <param name="s">сповіщення</param>
        private static void Show(string s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);
            Console.ResetColor();
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
