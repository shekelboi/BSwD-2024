using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_3
{
    class RentalApartment : Flat, IRent
    {
        int bookedMonths;

        public RentalApartment(double area, int roomsCount, int unitPrice) : base(area, roomsCount, 0, unitPrice)
        {
            this.bookedMonths = 0;
        }

        public bool Book(int months)
        {
            if (!IsBooked())
            {
                bookedMonths += months;
                return true;
            }
            return false;
        }

        public double GetCost(int months)
        {
            return TotalValue() / 240 / residentsCount;
        }

        public bool IsBooked()
        {
            return bookedMonths != 0;
        }

        public override bool MoveIn(int newResidents)
        {
            bool success = IsBooked() && (residentsCount + newResidents) / roomsCount <= 8 && (area / residentsCount) >= 2;
            if (success)
            {
                residentsCount += newResidents;
            }
            return success;
        }

        public override string ToString()
        {
            return $"[RentalApartment] {bookedMonths} months booked, " + base.ToString();
        }
    }
}
