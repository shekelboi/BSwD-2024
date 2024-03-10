using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_2
{
    class Square : Rectangle
    {
        public Square(int sideLength, string color, bool hasHole = false) : base(sideLength, sideLength, color, hasHole)
        {
            PunchHole();
        }

        public override string ToString()
        {
            return "[Square] " + base.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != typeof(Rectangle) && obj.GetType() != typeof(Square))
            {
                return false;
            }
            return base.Equals(obj);
        }
    }
}
