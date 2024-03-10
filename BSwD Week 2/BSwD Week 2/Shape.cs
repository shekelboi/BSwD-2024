using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_2
{
    abstract class Shape
    {
        static Random random = new Random();
        static int maxSize = 5;

        static string[] colorOptions = new string[]
        {
            "Red", "Green", "Blue", "Orange", "Purple", "Brown"
        };

        string color;
        bool hasHole;

        protected Shape(string color, bool hasHole = false)
        {
            this.color = color;
            this.hasHole = hasHole;
            PunchHole();
        }

        public void MakeHole()
        {
            hasHole = true;
        }

        public abstract double Perimeter();
        public abstract double Area();

        public override string ToString()
        {
            return $"{color}, {(hasHole ? "has hole" : "no hole")}, {Perimeter()} m, {Area()} m^2";
        }

        public string Color { get => color; }

        public override bool Equals(object? obj)
        {
            if (obj == null || !obj.GetType().IsSubclassOf(typeof(Shape)))
            {
                return false;
            }
            Shape s = (Shape)obj;
            return s.color == color && s.hasHole == hasHole;
        }

        public static List<Shape> GenerateRandomShapes(int size)
        {
            List<Shape> shapes = new List<Shape>();

            for (int i = 0; i < size; i++)
            {
                int choice = random.Next(3);
                int width = random.Next(1, maxSize);
                int height = random.Next(1, maxSize);
                string color = colorOptions[random.Next(colorOptions.Length)];
                bool hasHole = Convert.ToBoolean(random.Next(2));

                switch (choice)
                {
                    case 0:
                        shapes.Add(SquareOrRectangle(width, height, color, hasHole));
                        break;
                    case 1:

                        shapes.Add(SquareOrRectangle(width, height, color, hasHole));
                        break;
                    case 2:
                        shapes.Add(new Circle(width, color, hasHole));
                        break;
                }
            }

            return shapes;
        }

        public void PunchHole()
        {
            if (Area() > Perimeter())
            {
                MakeHole();
            }
        }

        public static Shape SquareOrRectangle(int width, int height, string color, bool hasHole = false)
        {
            if (width == height)
            {
                return new Square(width, color, hasHole);
            }
            else
            {
                return new Rectangle(width, height, color, hasHole);
            }
        }

        public static Shape LargestShape(List<Shape> shapes)
        {
            return shapes.First(shape => shape.Area() == shapes.Max(shape => shape.Area()));
        }
    }
}
