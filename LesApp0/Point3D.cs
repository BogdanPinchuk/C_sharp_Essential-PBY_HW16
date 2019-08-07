using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Координати точки (x, y, z)
    /// </summary>
    struct Point3D
    {
        /// <summary>
        /// Координати точки по осі Ox
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// Координати точки по осі Oy
        /// </summary>
        public double Y { get; set; }
        /// <summary>
        /// Координати точки по осі Oz
        /// </summary>
        public double Z { get; set; }
        /// <summary>
        /// Назва точки, задається в крайній необхідності
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ініціалізація координат
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="name"></param>
        private Point3D(double x, double y, double z, string name)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Name = name;
        }

        /// <summary>
        /// Ініціалізація координат
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Point3D(double x, double y, double z)
            : this(x, y, z, string.Empty) { }

        /// <summary>
        /// Додавання точок
        /// </summary>
        /// <param name="a">1 точка</param>
        /// <param name="b">2 тчока</param>
        /// <returns></returns>
        public static Point3D operator +(Point3D a, Point3D b) 
            => new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        /// <summary>
        /// Віднімання точок
        /// </summary>
        /// <param name="a">1 точка</param>
        /// <param name="b">2 тчока</param>
        /// <returns></returns>
        public static Point3D operator -(Point3D a, Point3D b)
            => new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        /// <summary>
        /// Інкремент точки
        /// </summary>
        /// <param name="a">1 точка</param>
        /// <returns></returns>
        public static Point3D operator ++(Point3D a)
            => new Point3D(++a.X, ++a.Y, ++a.Z);

        /// <summary>
        /// Декремент точки
        /// </summary>
        /// <param name="a">1 точка</param>
        /// <returns></returns>
        public static Point3D operator --(Point3D a)
            => new Point3D(--a.X, --a.Y, --a.Z);

        /// <summary>
        /// Вивід точки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"({this.X}, {this.Y}, {this.Z})";
    }
}
