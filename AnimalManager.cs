using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class AnimalManager
    {
        List<Animal> animals = new List<Animal>();
        CropManager CropManager;
        public AnimalManager(CropManager cropManager)
        {
            Animal animal = new Animal(1, "Peppa", "Pig", new List<string> { "Fruit" });
            animals.Add(animal);
            animals.Add(new Animal(2, "Pelle", "Cat", new List<string> { "Fruit" }));
            animals.Add(new Animal(3, "Magnus", "Uggla", new List<string> { "Vegetable" }));
            animals.Add(new Animal(4, "Agda", "Chicken", new List<string> { "Grain" }));
            animals.Add(new Animal(5, "Pricken", "Horse", new List<string> { "Vegetable" }));
            animals.Add(new Animal(6, "Maj", "Cow", new List<string> { "Grain" }));
            CropManager = cropManager;
        }
        public void AnimalMenu(List<Crop> CropList)
        {
            int MenuChoice = 0;
            bool continuing = true;
            while (continuing == true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("ANIMAL MENU\n");
                    Console.WriteLine("1. View animals");
                    Console.WriteLine("2. Add an animal");
                    Console.WriteLine("3. Remove an animal");
                    Console.WriteLine("4. Feed an animal");
                    Console.WriteLine("5. Go back to main menu\n");
                    Console.WriteLine("What would you like to do? Chose by number.\n");
                    MenuChoice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nYou can only write numbers.");
                }

                switch (MenuChoice.ToString())
                {
                    case "1":
                        Console.Clear();
                        ViewAnimal();
                        Console.WriteLine("\nPress enter to return to Animal menu.\n");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        ViewAnimal();
                        AddAnimal();
                        Console.WriteLine("\nPress enter to return to Animal menu.\n");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("These are the current existing animals at the farm:\n");
                        ViewAnimal();
                        Console.WriteLine("\nWrite the Id of the animal you want to remove.\n");
                        int id = 0;
                        try
                        {
                            id = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("\nYou can only write numbers");
                        }
                        RemoveAnimal(id);
                        Console.WriteLine("Press enter to return to Animal menu.\n");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        ViewAnimal();
                        Console.WriteLine("\nWhat animal do you want to feed? Chose by id.\n");
                        try
                        {
                            int feedThisSpecies = int.Parse(Console.ReadLine());
                            string animalToFeed = "Animal " + feedThisSpecies.ToString();
                            bool found = false;

                            foreach (Animal animal in animals)
                            {
                                if (animalToFeed == $"Animal {animal.Id}")
                                {
                                    var acceptableCropTypes = animal.GetAcceptableCropTypes();
                                    Console.Clear();
                                    Console.Write("The animal you chose only eats: ");
                                    Console.WriteLine(string.Join(", ", acceptableCropTypes));
                                    Console.WriteLine();
                                    found = true;
                                }
                                if (!found)
                                {
                                    Console.WriteLine("\nNo matching animal found with the provided ID.");
                                }
                            }
                            Crop crop1 = null;

                            foreach (Crop crop in CropManager.crops)
                            {
                                crop.GetDescriptions();
                            }
                            Console.WriteLine("\nWhat do you want to feed your animal with? Chose by id.\n");
                            int feedThisCrop = int.Parse(Console.ReadLine());

                            foreach (Crop crop in CropManager.crops)
                            {
                                if (feedThisCrop == crop.Id)
                                {
                                    crop1 = crop;
                                }
                            }

                            FeedAnimal(animalToFeed, crop1);
                        }
                        catch
                        {
                            Console.WriteLine("\nYou can only write numbers");
                        }
;
                        Console.WriteLine("\nPress enter to return to Animal menu.");
                        Console.ReadLine();
                        break;
                    case "5":
                        continuing = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void FeedAnimal(string animalToFeed, Crop crop1)
        {
            bool found = false;

            foreach (Animal animal in animals)
            {
                if (animalToFeed == $"Animal {animal.Id}")
                {
                    animal.Feed(crop1);
                    
                    found = true;
                    break; 
                }
            }

            if (!found)
            {
                Console.WriteLine("\nNo matching animal found with the provided ID.");
            }
           
        }
        private void ViewAnimal()
        {
            foreach (Animal animal in animals)
            {
                animal.GetDescriptions();
            }
        }
        
        private void AddAnimal()
        {
            try
            {
                Console.WriteLine("\nWhat Id?");
                int idInput = int.Parse(Console.ReadLine());

                Console.WriteLine("\nWhat name?");
                string nameInput = Console.ReadLine();

                Console.WriteLine("\nWhat species?");
                string speciesInput = Console.ReadLine();

                Console.WriteLine("\nDoes your animal eat, fruit, vegetable or grains?");
                string cropTypeInput = Console.ReadLine();

                List<string> acceptableCropType = new List<string> { cropTypeInput };
                animals.Add(new Animal(idInput, nameInput, speciesInput, acceptableCropType));

                Console.WriteLine("\nYour " + speciesInput + ", " + nameInput + " is now added to the farm and only eats " + cropTypeInput + ".");
            }
            catch
            {
                Console.WriteLine("\nYou can only write numbers to assign Id to your animal.");
            }
        }
        private int RemoveAnimal(int id)
        {
            Animal removeAnimal = FindAnimal(id);
            if (removeAnimal != null)
            {
                animals.Remove(removeAnimal);
                Console.WriteLine("Your animal has been succesfully removed\n");
            }
            else
            {
                Console.WriteLine("\nWe dont have any animal with that Id.");
            }
            return id;
        }

        public Animal FindAnimal(int id)
        {
            foreach (Animal animal in animals)
            {
                if (animal.Id == id)
                {
                    return animal;
                }
            }
            return null;
        }
    }
}
