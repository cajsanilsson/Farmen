using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Animal : Entity
    {
        private List<string> AcceptableCropTypes = new List<string>();
        public string Species;
        public List<string> GetAcceptableCropTypes()
        {
            return AcceptableCropTypes;
        }
        public Animal(int id, string name, string species, List<string> acceptableCropTypes)
            : base(id, name)
        {
            Species = species;
            AcceptableCropTypes = acceptableCropTypes;
        }
        public override string GetDescriptions()
        {
            string cropTypes = string.Join(", ", AcceptableCropTypes);
            Console.WriteLine("Id: " + Id + ", Name: " + Name + ", Species: " + Species + ", Eats: " + cropTypes);
            return cropTypes;
        }
        public bool Feed(Crop crop)
        {
            bool noFood;
            
            if (AcceptableCropTypes.Contains(crop.CropType))
            {
                if (crop.TakeCrop(1))
                {
                    Console.WriteLine(Name + " has been fed with 1 " + crop.CropType);
                    noFood = false;
                }
                else
                {
                    Console.WriteLine("Not enough " + crop.CropType + " available to feed " + Name);
                    noFood = true;
                }
            }
            else
            {
                Console.WriteLine(Name + " cannot eat " + crop.CropType);
                noFood = true;
            }
            return noFood;
        }
    }
}
