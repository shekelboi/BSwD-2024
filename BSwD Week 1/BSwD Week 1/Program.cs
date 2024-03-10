using System.Security.Principal;

namespace BSwD_Week_1
{
    public class Program
    {
        static Random r = new Random();
        private static void Main(string[] args)
        {
            Cage[] cages = new Cage[4];
            Console.WriteLine("Generated cages:");
            for (int i = 0; i < cages.Length; i++)
            {
                cages[i] = new Cage();
                Console.WriteLine(cages[i]);
            }
            Cage selectedCage = cages[r.Next(4)];
            Animal selectedAnimal = selectedCage.Animals[r.Next(selectedCage.NumberOfAnimals)];
            Console.WriteLine("Selected cage:");
            Console.WriteLine(selectedCage);


            //Console.WriteLine("Let's remove this one: " + selectedAnimal);
            //selectedCage.Remove(selectedAnimal.Name);

            //Console.WriteLine("Animals after removal:");
            //for (int i = 0; i < cages.Length; i++)
            //{
            //    Console.WriteLine(cages[i]);
            //}

            // Task 1
            Console.WriteLine("Given a cage, how many animals of a certain species are living in the cage?");
            Species selectedSpecies = (Species)r.Next(3);
            Console.WriteLine($"Let's try it with {selectedSpecies} on the selected cage:");
            Console.WriteLine(selectedCage.NumberOfAnimalsOfSpecies(selectedSpecies));
            Console.WriteLine();

            // Task 2
            Console.WriteLine("Given a cage, are there any predators of a certain species living in the cage?");
            Console.WriteLine("Let's see if the selected cage has any predator in it:");
            Console.WriteLine(selectedCage.HasPredator() ? "Yes" : "No");
            Console.WriteLine();

            // Task 3
            Console.WriteLine("Given a cage, return the collection of animals of a certain species");
            Console.WriteLine($"Let's see the {selectedSpecies}s in the selected cage:");
            Animal[] animalsFound = selectedCage.GetAnimalsOfSpecies(selectedSpecies);
            for (int i = 0; i < animalsFound.Length; i++)
            {
                Console.WriteLine(animalsFound[i]);
            }
            Console.WriteLine();

            // Task 4
            Console.WriteLine("What is the average weight of the animal in a certain cage?");
            Console.WriteLine("Let's get the average weight in our selected cage:");
            Console.WriteLine($"{selectedCage.AverageWeight()} kg");

            // Task 5
            Console.WriteLine("Whether or not exist two predators of a certain species in a given cage.");
            Console.WriteLine($"Let's check if there are at least 2 {selectedSpecies}s in the selected cage that are predators.");
            Console.WriteLine(selectedCage.HasTwoOrMorePredatorsOfTheSameSpecies(selectedSpecies) ? "Yes" : "No");
            Console.WriteLine();

            // Task 6
            Console.WriteLine("Which cage has the highest number of species in it?");
            Console.WriteLine("This cage:");
            Console.WriteLine(Cage.CageWithMostAnimals(cages));
        }
    }
}