using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_2
{
    class Rectangle : Shape
    {
        int width, height;

        public Rectangle(int width, int height, string color, bool hasHole = false) : base(color, hasHole)
        {
            this.width = width;
            this.height = height;
            PunchHole();
        }

        public override double Area()
        {
            return width * height;
        }

        public override double Perimeter()
        {
            return (width + height) * 2;
        }

        public override string ToString()
        {
            return "[Rectangle] " + base.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != typeof(Rectangle) && !obj.GetType().IsSubclassOf(typeof(Rectangle)))
            {
                return false;
            }
            Rectangle r = (Rectangle)obj;
            return base.Equals(obj) && r.height == height && r.width == width;
        }

        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
    }
}
