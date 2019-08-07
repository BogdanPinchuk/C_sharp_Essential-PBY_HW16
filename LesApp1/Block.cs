using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Примітка!!! Проблеми із термінологією/визначеннями
// Блок якщо в 3D - то це зазвичай паралелепіпед, (грубо говоря цеглина)
// і в ньому можуть бути різні тільки 3 сторони,
// сторона (ребро) це відстань між двома точками (вершинами/кутами)
// грань - плошина обмежена ребрами або вершинами;
// і так, про 4-х вимірність не говориться, тоді лишається
// побудувати в одній площині 4-кутник із 4-ма різними сторонами, але лишається
// 5-та сторона - товщина. Тому або 3 або 5 сторін; Якщо ж загадати 4 сторони,
// то це вже не буде блоком (паралелепіпедом), а буде клин
// трикутник певної товщини - єдине, що має найменше відмінностей від умови

namespace LesApp1
{
    /// <summary>
    /// Клин - заданий 4-ма сторонами
    /// </summary>
    class Block
    {
        /// <summary>
        /// клин із 4-ма сторонами
        /// </summary>
        private double[] wedge = new double[4];

        #region Сторони
        /// <summary>
        /// Сторона "a"
        /// </summary>
        public double AB
        {
            get { return wedge[0]; }
            set
            {
                if (value > 0)
                {
                    wedge[0] = value;
                }
                else
                {
                    MessageInputValue();
                }
            }
        }
        /// <summary>
        /// Сторона "b"
        /// </summary>
        public double BC
        {
            get { return wedge[1]; }
            set
            {
                if (value > 0)
                {
                    wedge[1] = value;
                }
                else
                {
                    MessageInputValue();
                }
            }
        }
        /// <summary>
        /// Сторона "c"
        /// </summary>
        public double CA
        {
            get { return wedge[2]; }
            set
            {
                if (value > 0)
                {
                    wedge[2] = value;
                }
                else
                {
                    MessageInputValue();
                }
            }
        }
        /// <summary>
        /// Сторона "d"
        /// </summary>
        public double AD
        {
            get { return wedge[3]; }
            set
            {
                if (value > 0)
                {
                    wedge[3] = value;
                }
                else
                {
                    MessageInputValue();
                }
            }
        }
        /// <summary>
        /// Сума сторін
        /// </summary>
        public double Sum { get { return wedge.Sum(); } }
        #endregion

        /// <summary>
        /// Створення заготовки клина для подальшого введення даних
        /// </summary>
        public Block()
        {
            for (int i = 0; i < wedge.Length; i++)
            {
                wedge[i] = default(double); // зазвичай присвоєння 0.0
            }
        }

        /// <summary>
        /// Створення клина по сторонам
        /// </summary>
        public Block(double a, double b, double c, double d)
        {
            this.AB = a;
            this.BC = b;
            this.CA = c;
            this.AD = d;
        }

        /// <summary>
        /// Копіювання даних із іншого клина
        /// </summary>
        /// <param name="block"></param>
        public Block(Block block)
        {
            AB = block.AB;
            BC = block.BC;
            CA = block.CA;
            AD = block.AD;
        }

        /// <summary>
        /// Виведення інформації про клин
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Клин зі сторонами: a = {AB}, b = {BC}, c = {CA}, d = {AD}; " +
                $"хеш-код: {GetHashCode()}";
        }

        /// <summary>
        /// Порівняння фігур (клинів)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // кастимо
            Block temp = obj as Block;

            // так як можна сказати, що користучач може задати 
            // таку ж фігуру але в іншому порядку сторони, то необхідно
            // звірити це більш детально - перевіряємо кожну сторону

            return wedge.Contains(temp.AB) &&   // спершу чи така сторона наявна в масиві
                wedge.Contains(temp.BC) &&
                wedge.Contains(temp.CA) &&
                wedge.Contains(temp.AD) &&
#if true    // при умові якщо потрібно і перевірити порядок, тобто вимога чіткого співдношення сторін
                AB == temp.AB &&
                BC == temp.BC &&
                CA == temp.CA &&
                AD == temp.AD &&
#endif
                // тоді чи суми сторін рівні, тому що можуть попастися 2 однакові сторони
                temp.Sum == this.Sum;
        }

        /// <summary>
        /// Хеш-код даного екземпляру
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // проблема виникає із порядковими числами, наприклад
            // 2,3,4,5 або 10,11,12,13 і так далі і саме 4 підряд - дають 0
            // а сусідні 2 - дають 1
            int hash = wedge[0].GetHashCode();
            // там набагато ефективніше
            for (int i = 1; i < wedge.Length; i++)
            {
                hash ^= wedge[i].GetHashCode();
            }

            return hash;
        }

        /// <summary>
        /// Виведення сповіщення про невірно введені дані
        /// </summary>
        private void MessageInputValue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tДовжина сторони не може бути меншою або рівною 0!");
            Console.ResetColor();
        }
    }
}
