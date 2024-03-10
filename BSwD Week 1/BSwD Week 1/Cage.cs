using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BSwD_Week_1
{
    public class Cage
    {
        Animal[] animals = new Animal[10];
        int numberOfAnimals = 0;

        static Random r = new Random();

        public Cage()
        {

            // Maximum of 10
            numberOfAnimals = r.Next(1, 11);
            for (int i = 0; i < numberOfAnimals; i++)
            {
                animals[i] = new Animal();
            }
        }

        public void Add(Animal animal)
        {
            animals[numberOfAnimals++] = animal;
        }

        public void Remove(string name)
        {
            // Shifting the array to the left
            for (int i = FindAnimal(name); i < numberOfAnimals - 1; i++)
            {
                animals[i] = animals[i + 1];
            }
            numberOfAnimals--;
        }

        /// <summary>
        /// Finds the index of the animal based on its name in an array.
        /// </summary>
        /// <returns>The index of the searched animal or -1 if not found.</returns>
        public int FindAnimal(string name)
        {
            for (int i = 0; i < numberOfAnimals; i++)
            {
                if (animals[i].Name.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool HasPredator()
        {
            for (int i = 0; i < numberOfAnimals; i++)
            {
                if (animals[i].Predator)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Number of animals of a certain species.
        /// </summary>
        /// <param name="species">The species of the animals.</param>
        /// <returns>The number of animals of the specified species.</returns>
        public int NumberOfAnimalsOfSpecies(Species species)
        {
            int counter = 0;
            for (int i = 0; i < numberOfAnimals; i++)
            {
                if (animals[i].Species == species)
                {
                    counter++;
                }
            }
            return counter;
        }

        /// <summary>
        /// Retrieve an array of animals of a certain species.
        /// </summary>
        /// <param name="species">The species of animals we want to retrieve.</param>
        /// <returns>An array of animals of the specified species.</returns>
        public Animal[] GetAnimalsOfSpecies(Species species)
        {
            Animal[] animalsOfSpecies = new Animal[NumberOfAnimalsOfSpecies(species)];

            int counter = 0;
            for (int i = 0; i < numberOfAnimals; i++)
            {
                if (animals[i].Species == species)
                {
                    animalsOfSpecies[counter++] = animals[i];
                }
            }

            return animalsOfSpecies;
        }

        /// <summary>
        /// Calculates the average weight of the animals in the cage.
        /// </summary>
        /// <returns>The average weight of an animal in the cage.</returns>
        public double AverageWeight()
        {
            int sum = 0;
            for (int i = 0; i < numberOfAnimals; i++)
            {
                sum += animals[i].Weight;
            }
            return (double)sum / numberOfAnimals;
        }

        /// <summary>
        /// Checks whether there exists two predators of a particular species.
        /// </summary>
        /// <returns>Whether there there exists two predators of a particular species.</returns>
        public bool HasTwoOrMorePredatorsOfTheSameSpecies(Species species)
        {
            return NumberOfAnimalsOfSpecies(species) >= 2 && Animal.IsPredator(species);
        }

        /// <summary>
        /// Returns the cage with the most animals.
        /// </summary>
        /// <param name="cages">List of cages to choose from.</param>
        /// <returns>The cage with most animals.</returns>
        public static Cage CageWithMostAnimals(Cage[] cages)
        {
            int indexOfHighest = 0;

            for (int i = 1; i < cages.Length; i++)
            {
                if (cages[i].NumberOfSpecies() > cages[indexOfHighest].NumberOfSpecies())
                {
                    indexOfHighest = i;
                }
            }
            return cages[indexOfHighest];
        }

        public int NumberOfSpecies()
        {
            bool Contains(Species[] species, int length, Species s)
            {
                for (int i = 0; i < length; i++)
                {
                    if (species[i].Equals(s))
                    {
                        return true;
                    }
                }
                return false;
            }
            int counter = 0;
            Species[] species = new Species[3];
            for (int i = 0; i < numberOfAnimals; i++)
            {
                if (!Contains(species, counter, animals[i].Species))
                {
                    species[counter++] = animals[i].Species;
                }
            }
            return counter;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[Cage]");
            for (int i = 0; i < numberOfAnimals; i++)
            {
                sb.AppendLine(animals[i].ToString());
            }
            return sb.ToString();
        }
        public Animal[] Animals { get => animals; }
        public int NumberOfAnimals { get => numberOfAnimals; }
    }
}
