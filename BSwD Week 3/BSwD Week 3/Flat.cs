using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_3
{
    abstract class Flat : IRealEstate, IComparable
    {
        protected double area;
        protected int roomsCount;
        protected int residentsCount;
        protected int unitPrice;


        public Flat(double area, int roomsCount, int residentsCount, int unitPrice)
        {
            this.area = area;
            this.roomsCount = roomsCount;
            this.residentsCount = residentsCount;
            this.unitPrice = unitPrice;
        }

        public double TotalValue()
        {
            return area * unitPrice;
        }

        public override string ToString()
        {
            return $" {area} m^2, {roomsCount} room(s), {residentsCount} resident(s), ${unitPrice}";
        }

        public abstract bool MoveIn(int newResidents);

        public int CompareTo(object? obj)
        {
            if (obj != null && (obj.GetType() == typeof(Flat) || obj.GetType().IsSubclassOf(typeof(Flat))))
            {
                Flat flat = (Flat)obj;
                double difference = this.area - flat.area;
                // If the difference is less than 0, round it down, otherwise round it up
                return Convert.ToInt32(difference < 0 ? Math.Floor(difference) : Math.Ceiling(difference));
            }
            return -1;
        }

        public int ResidentsCount { get => residentsCount; }
    }
}
