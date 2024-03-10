using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSwD_Week_1
{
    public enum Species
    {
        Dog = 0,
        Panda = 1,
        Rabbit = 2
    }
    public class Animal
    {
        string name;
        bool predator;
        int weight;
        Species species;

        static Random r = new Random();
        /// <summary>
        /// Animal with random attributes.
        /// </summary>
        public Animal()
        {
            name = "";
            for (int i = 0; i < 10; i++)
            {
                this.name += (char)r.Next((int)'A', (int)'Z' + 1);
                this.weight = r.Next(5, 150);
                this.species = (Species)r.Next(3);
                this.predator = IsPredator(species);
            }
        }

        /// <summary>
        /// Creates an animal from semicolon separated properties.
        /// </summary>
        /// <param name="description">Descriptionf of the animal's attribute separated by semicolons.</param>
        public Animal(string description)
        {
            string[] attributes = description.Split(';');
            name = attributes[0];
            predator = Convert.ToBoolean(int.Parse(attributes[1]));
            weight = int.Parse(attributes[2]);
            species = (Species) Enum.Parse(typeof(Species), attributes[3]);
        }

        public Animal(string name, bool predator, int weight, Species species)
        {
            this.name = name;
            this.predator = predator;
            this.weight = weight;
            this.species = species;
        }


        public static bool IsPredator(Species species)
        {
            return species.Equals(Species.Dog);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Predator: {Predator}, Weight: {Weight} kg, Species: {Species}";
        }

        public string Name { get => name; }
        public bool Predator { get => predator;  }
        public int Weight { get => weight; }
        public Species Species { get => species; }

    }
}
