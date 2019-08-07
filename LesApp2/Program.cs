using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Примітка. Напевне для правильнго відображення глибокого копіювання 
// необхідно було б в умові реалізувати ще й якійсь екземпляри на якісь класи

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Join Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // таймер
            Stopwatch timer = new Stopwatch();

            // створення екземпляра
            House house0 = new House()
            {
                Field1 = 1,
                Field2 = 2.ToString()
            };

            Show($"\n\tСтворений екземпляр house0");
            Console.WriteLine(house0.ToString());

            Show("\n" + new string('#', 80));

            Show($"\tНеповне копіювання екземпляра house0");
            timer.Start();
            House house1 = house0.Clone() as House;
            timer.Stop();
            Console.WriteLine(house1.ToString());
            Console.WriteLine($"\n\tЗатрачений час: {timer.ElapsedTicks} тактів");
            timer.Restart();

            Show($"\n\tЗміна екземпляра house1");
            house1.Field1 = 10;
            house1.Field2 = "двадцять";
            Console.WriteLine(house0.ToString());
            Console.WriteLine(house1.ToString());

            Show("\n" + new string('#', 80));

            Show($"\n\tНеповне швидке копіювання екземпляра house0");
            timer.Start();
            House house2 = house0.FastClone() as House;
            timer.Stop();
            Console.WriteLine(house2.ToString());
            Console.WriteLine($"\n\tЗатрачений час: {timer.ElapsedTicks} тактів");
            timer.Restart();

            Show($"\n\tЗміна екземпляра house2");
            house2.Field1 = 10;
            house2.Field2 = "двадцять";
            Console.WriteLine(house0.ToString());
            Console.WriteLine(house2.ToString());

            Show("\n" + new string('#', 80));

            Show($"\n\tГлибоке копіювання екземпляра house0");
            timer.Start();
            House house3 = house0.DeepClone() as House;
            timer.Stop();
            Console.WriteLine(house3.ToString());
            Console.WriteLine($"\n\tЗатрачений час: {timer.ElapsedTicks} тактів");
            timer.Restart();

            Show($"\n\tЗміна екземпляра house3");
            house3.Field1 = 10;
            house3.Field2 = "двадцять";
            Console.WriteLine(house0.ToString());
            Console.WriteLine(house3.ToString());

            Show("\n" + new string('#', 80));

            Show($"\n\tПоверхневе копіювання екземпляра house0");
            timer.Start();
            House house4 = house0;
            timer.Stop();
            Console.WriteLine(house4.ToString());
            Console.WriteLine($"\n\tЗатрачений час: {timer.ElapsedTicks} тактів");
            timer.Restart();

            Show($"\n\tЗміна екземпляра house3");
            house4.Field1 = 10;
            house4.Field2 = "двадцять";
            Console.WriteLine(house0.ToString());
            Console.WriteLine(house4.ToString());

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
