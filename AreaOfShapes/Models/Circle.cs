using System;

namespace AreaOfShapes.Models
{
    public class Circle : Interfaces.IShape
    {
        /// <summary>
        /// Радиус круга.
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Инициализирует объект круг.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentException($"радиус не может быть меньше нуля ({radius})");

            Radius = radius;
        }

        /// <summary>
        /// Высчитывает площадь круга.
        /// </summary>
        /// <returns>Плозадь круга</returns>
        public double CalculateArea() => CalculateArea(Radius);

        /// <summary>
        /// Высчитывает площадь круга.
        /// Если входные данные некорректны выкидывает ArgumentException.
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        public static double CalculateArea(double radius)
        {
            ThrowIfWrongInput(radius);

            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Проверяет на корректность входные данные. Если данные некорректны выкидывает ArgumentException.
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public static void ThrowIfWrongInput(double radius)
        {
            if (radius < 0)
                throw new ArgumentException($"радиус не может быть меньше нуля ({radius})");
        }
    }
}