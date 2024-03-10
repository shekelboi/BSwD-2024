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
        }
    }
}