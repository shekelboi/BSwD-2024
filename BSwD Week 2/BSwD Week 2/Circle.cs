using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_2
{
    class Circle : Shape
    {
        int radius;

        public Circle(int radius, string color, bool hasHole = false) : base(color, hasHole)
        {
            this.Radius = radius;
            PunchHole();
        }

        public override double Area()
        {
            return Math.Pow(radius, 2) * Math.PI;
        }

        public override double Perimeter()
        {
            return radius * 2 * Math.PI;
        }

        public override string ToString()
        {
            return "[Circle] " + base.ToString();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public int Radius { get => radius; set => radius = value; }
    }
}
