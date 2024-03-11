namespace BSwD_Week_3
{
    class Program
    {
        private static void Main(string[] args)
        {
            ApartmentBuilding apartment = ApartmentBuilding.LoadFromFile("apartments.txt");

            for (int i = 0; i < apartment.NumberOfFlats; i++)
            {
                Console.WriteLine(apartment.Flats[i]);
            }

            for (int i = 0; i < apartment.NumberOfGarages; i++)
            {
                Console.WriteLine(apartment.Garages[i]);
            }

            // Attempting to move in 100 people
            Console.WriteLine(apartment.Flats[1].MoveIn(100));
            // Attempting to move in 10 person
            Console.WriteLine(apartment.Flats[1].MoveIn(10));
            // Attempting to move in 1 person
            Console.WriteLine(apartment.Flats[1].MoveIn(1));

            Console.WriteLine($"Number of residents: {apartment.Flats[1].ResidentsCount}");

            // Trying the comparison
            Flat[] flats = new Flat[]
            {
                new RentalApartment(100, 2, 40),
                new RentalApartment(40.5, 1, 20),
                new RentalApartment(40, 1, 20),
                new RentalApartment(39.5, 1, 20),
                new FamilyApartment(500, 12, 5000),
                new RentalApartment(20, 1, 10),
            };
            Array.Sort(flats);

            for (int i = 0; i < flats.Length; i++)
            {
                Console.WriteLine(flats[i]);
            }
        }
    }
}