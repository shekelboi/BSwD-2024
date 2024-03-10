using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_3
{
    class ApartmentBuilding
    {
        private int numberOfFlats;
        private int numberOfGarages;

        public ApartmentBuilding(int maxFlats, int maxGarages)
        {
            Flats = new Flat[maxFlats];
            Garages = new Garage[maxGarages];
        }

        public bool AddFlat(Flat flat)
        {
            if (numberOfFlats < Flats.Length)
            {
                Flats[numberOfFlats++] = flat;
                return true;
            }
            return false;
        }
        public bool AddGarage(Garage garage)
        {
            if (numberOfGarages < Garages.Length)
            {
                Garages[numberOfGarages++] = garage;
                return true;
            }
            return false;
        }

        public int ResidentsCount
        {
            get
            {
                int residentCount = 0;

                for (int i = 0; i < Flats.Length; i++)
                {
                    residentCount += Flats[i].ResidentsCount;
                }

                return residentCount;
            }
        }

        public double TotalValue()
        {
            double totalValue = 0;

            for (int i = 0; i < Flats.Length; i++)
            {
                if (Flats[i].ResidentsCount > 0)
                {
                    totalValue += Flats[i].TotalValue();
                }
            }

            for (int i = 0; i < Garages.Length; i++)
            {
                if (Garages[i].IsBooked())
                {
                    totalValue += Garages[i].TotalValue();
                }
            }

            return totalValue;
        }

        public static ApartmentBuilding LoadFromFile(string path)
        {
            string[] properties = File.ReadAllLines(path);
            ApartmentBuilding apartmentBuilding = new ApartmentBuilding(properties.Length, properties.Length);
            for (int i = 0; i < properties.Length; i++)
            {
                string[] attributes = properties[i].Split(' ');
                string type = attributes[0];
                double area = Convert.ToDouble(attributes[1]);


                if (type == "RentalApartment" || type == "FamilyApartment")
                {
                    int roomCount = int.Parse(attributes[2]);
                    int unitPrice = int.Parse(attributes[3]);
                    if (type == "RentalApartment")
                    {
                        apartmentBuilding.AddFlat(new RentalApartment(area, roomCount, unitPrice));
                    }
                    else if (type == "FamilyApartment")
                    {
                        apartmentBuilding.AddFlat(new FamilyApartment(area, roomCount, unitPrice));
                    }
                }
                else if (type == "Garage")
                {
                    int unitPrice = int.Parse(attributes[2]);
                    // If not specified, we will treat it as not heated
                    bool heated = attributes.Length == 4;
                    apartmentBuilding.AddGarage(new Garage(area, unitPrice, heated));
                }
            }
            return apartmentBuilding;
        }

        public  Flat[] Flats { get; private set; }
        public Garage[] Garages { get; private set; }
        public int NumberOfFlats { get => numberOfFlats; set => numberOfFlats = value; }
        public int NumberOfGarages { get => numberOfGarages; set => numberOfGarages = value; }
    }
}