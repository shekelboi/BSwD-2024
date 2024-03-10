using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_3
{
    class Garage : IRent, IRealEstate
    {
        double area;
        int unitPrice;
        bool isHeated;
        int months;
        bool isOccupied;

        public Garage(double area, int unitPrice, bool isHeated, int months = 0, bool isOccupied = false)
        {
            this.area = area;
            this.unitPrice = unitPrice;
            this.isHeated = isHeated;
            this.months = months;
            this.isOccupied = isOccupied;
        }

        public bool Book(int months)
        {
            if (!IsBooked())
            {
                this.months = months;
                return true;
            }
            return false;
        }

        public double GetCost(int months)
        {
            return (TotalValue() / 120) * (isHeated ? 1.5 : 1) * months;
        }

        public bool IsBooked()
        {
            return months > 0 && isOccupied;
        }

        public double TotalValue()
        {
            return area * unitPrice;
        }

        public void UpdateOccupied()
        {
            if (IsBooked())
            {
                isOccupied = true;
            }
        }

        public override string ToString()
        {
            return $"[Garage] {area} m^2, ${unitPrice}, {(isHeated ? "heated" : "not heated")}, rented for {months} month(s), {(isOccupied ? "currently occupied" : "not occupied")}";
        }
    }
}
