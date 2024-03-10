using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_3
{
    abstract class Flat : IRealEstate
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
        public int ResidentsCount { get => residentsCount; }
    }
}
