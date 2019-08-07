using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class House : ICloneable
    {
        /// <summary>
        /// Поля
        /// </summary>
        private int field1;
        private string field2;

        /// <summary>
        /// Свойсво доступу до першого поля
        /// </summary>
        public int Field1 /*{ get; set; }*/
        {
            get { return field1; }
            set { field1 = value; }
        }

        /// <summary>
        /// Свойсво доступу до другого поля
        /// </summary>
        public string Field2 /*{ get; set; }*/
        {
            get { return field2; }
            set { field2 = value; }
        }

        public House() { }

        private House(int field1, string field2)
        {
            this.field1 = field1;
            this.field2 = field2;
        }

        /// <summary>
        /// Неповне копіювання
        /// </summary>
        /// <returns></returns>
        public object Clone()
            //=> new House(field1, field2); // необхідно для правильної реалізації копіювання
            => new House(); //- не працює, так як показано в приклада, 
                            // бо ж це іде створення пустого екземпляра а не його копіювання

        /// <summary>
        /// Неповне копіювання (швидке)
        /// </summary>
        /// <returns></returns>
        public object FastClone()
            => this.MemberwiseClone();

        /// <summary>
        /// Глибоке копіювання
        /// </summary>
        /// <returns></returns>
        public House DeepClone()
            => new House()
            {
                Field1 = this.field1,
                Field2 = this.field2
            };
        // так як в умові немає про створення окрім полів і властивостей ще й екземплярів,
        // які необхідно було б вручну прописувати копіювання, то резульат тільки такий

        /// <summary>
        /// вивід на екран результатів
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"\n\tfield1 = {field1}, field2 = {field2},";
    }
}
