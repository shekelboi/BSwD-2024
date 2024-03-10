using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_3
{
    class FamilyApartment : Flat
    {
        int childrenCount;

        public FamilyApartment(double area, int roomsCount, int unitPrice) : base(area, roomsCount, 0, unitPrice)
        {
            childrenCount = residentsCount;
        }
        bool ChildIsBorn()
        {
            if (residentsCount - childrenCount >= 2)
            {
                residentsCount++;
                childrenCount++;
                return true;
            }
            return false;
        }

        public override bool MoveIn(int newResidents)
        {
            if (residentsCount / roomsCount <= 2)
            {
                int areaForChildren = childrenCount * 5;
                int areaForResidents = (residentsCount + newResidents - childrenCount) * 10;

                if (area >= (areaForChildren + areaForResidents))
                {
                    residentsCount += newResidents;
                    return true;
                }

            }
            return false;
        }

        public override string ToString()
        {
            return $"[FamilyApartment] {childrenCount} children, " + base.ToString();
        }
    }
}
