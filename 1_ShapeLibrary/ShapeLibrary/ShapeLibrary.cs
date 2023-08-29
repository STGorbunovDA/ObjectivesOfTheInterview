namespace ShapeLibrary
{
    public class ShapeLibrary
    {
        public interface IShape
        {
            double CalculateArea();
        }

        public class Circle : IShape
        {
            private readonly double radius;

            public Circle(double radius)
            {
                this.radius = radius;
            }

            public double CalculateArea()
            {
                return Math.PI * radius * radius;
            }
        }

        public class Triangle : IShape
        {
            private readonly double side1;
            private readonly double side2;
            private readonly double side3;

            public Triangle(double side1, double side2, double side3)
            {
                this.side1 = side1;
                this.side2 = side2;
                this.side3 = side3;
            }

            public double CalculateArea()
            {
                if (!IsTriangleValid())
                {
                    throw new ArgumentException("Invalid triangle sides");
                }

                // Использование формулы Герона для вычисления площади треугольника
                double semiPerimeter = (side1 + side2 + side3) / 2;
                return Math.Sqrt(semiPerimeter * (semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));
            }

            private bool IsTriangleValid()
            {
                // Проверка, не превышает ли сумма длин любых двух сторон длину оставшейся стороны
                return side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1;
            }

            public bool IsRightTriangle()
            {
                // Проверка, равен ли квадрат самой длинной стороны сумме квадратов двух других сторон
                double longest = Math.Max(side3, Math.Max(side1, side2));

                if (longest == side1)
                {
                    return side1 * side1 == side2 * side2 + side3 * side3;
                }
                else if (longest == side2)
                {
                    return side2 * side2 == side1 * side1 + side3 * side3;
                }
                else
                {
                    return side3 * side3 == side1 * side1 + side2 * side2;
                }
            }
        }
    }
}