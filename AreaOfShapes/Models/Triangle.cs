using System;

namespace AreaOfShapes.Models
{
    public class Triangle : Interfaces.IShape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        private double _s = -1;

        /// <summary>
        /// Инициализирует объект треугольник.
        /// </summary>
        /// <param name="a">сторона а</param>
        /// <param name="b">сторона b</param>
        /// <param name="c">сторона c</param>
        public Triangle (double a, double b, double c)
        {
            ThrowIfWrongInput(a, b, c);

            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Высчитывает и возвращает площадь треугольника.
        /// </summary>
        /// <returns>площадь треугольника</returns>
        public double CalculateArea()
        {
            if (_s < 0)
                _s = CalculateArea(A, B, C);

            return _s;
        }

        /// <summary>
        /// Возвращает true, если треугольник прямоугольный.
        /// </summary>
        /// <returns></returns>
        public bool IsRight() => IsRight(A, B, C);

        /// <summary>
        /// Высчитывает и возвращает площадь треугольника.
        /// Если входные данные некорректны выкидывает ArgumentException.
        /// </summary>
        /// <param name="a">сторона а</param>
        /// <param name="b">сторона b</param>
        /// <param name="c">сторона c</param>
        /// <returns>площадь треугольника</returns>
        public static double CalculateArea(double a, double b, double c)
        {
            ThrowIfWrongInput(a, b, c);

            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// Проверяет на корректность входные данные. Если данные некорректны выкидывает ArgumentException.
        /// </summary>
        /// <param name="a">сторона а</param>
        /// <param name="b">сторона b</param>
        /// <param name="c">сторона c</param>
        public static void ThrowIfWrongInput(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException($"одна из сторон меньше нуля ({a}, {b}, {c})");
        }

        /// <summary>
        /// Возвращает true, если треугольник прямоугольный.
        /// Если входные данные некорректны выкидывает ArgumentException.
        /// </summary>
        /// <param name="a">сторона а</param>
        /// <param name="b">сторона b</param>
        /// <param name="c">сторона c</param>
        /// <returns></returns>
        public static bool IsRight(double a, double b, double c)
        {
            ThrowIfWrongInput(a, b, c);

            if (a > b && a > c)
                return a * a == b * b + c * c;

            if (b > a && b > c)
                return b * b == a * a + c * c;

            if (c > a && c > b)
                return c * c == a * a + b * b;

            return false;
        }
    }
}