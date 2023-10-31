using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CropManager
    {
        public List<Crop> crops = new List<Crop>();
        public CropManager()
        {
            crops.Add(new Crop(1, "Beetroot", "Vegetable", 2));
            crops.Add(new Crop(2, "Carrot", "Vegetable", 4));
            crops.Add(new Crop(3, "Apple", "Fruit", 3));
            crops.Add(new Crop(4, "Pear", "Fruit", 1));
            crops.Add(new Crop(5, "Hay", "Grain", 3));
            crops.Add(new Crop(6, "Oats", "Grain", 10));
        }
        public void CropMenu()
        {
            int MenuChoice = 0;
            bool continuing = true;
            while (continuing == true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("CROP MENU\n");
                    Console.WriteLine("1. View crops");
                    Console.WriteLine("2. Add a crop");
                    Console.WriteLine("3. Remove a crop");
                    Console.WriteLine("4. Return to main menu\n");
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
                        ViewCrops();
                        Console.WriteLine("\nPress enter to return to Crop menu.\n");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        AddCrop();
                        Console.WriteLine("\nPress enter to return to Crop menu.\n");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Clear();
                        RemoveCrop();
                        Console.WriteLine("\nPress enter to return to Crop menu.\n");
                        Console.ReadLine();
                        break;
                    case "4":
                        continuing = false;
                        break;
                    default:
                        break;
                }
            }

        }
        private void ViewCrops()
        {
            foreach (Crop crop in crops)
            {
                crop.GetDescriptions();
            }
        }
        private void AddCrop()
        {
            try
            {
                Console.WriteLine("1. Add to the quantity of an already existing croptype.");
                Console.WriteLine("2. Add a brand new croptype.\n");
                Console.WriteLine("What do you want to do? Chose by number.\n");
                int cropChoice = int.Parse(Console.ReadLine());
                Console.Clear();
                ViewCrops();

                if (cropChoice == 1)
                {
                    Console.WriteLine("\nAdd to the quantity of an already existing croptype.\n");
                    Console.WriteLine("What Id?");
                    int idInput = int.Parse(Console.ReadLine());
                    Crop existingCrop = FindCrop(idInput);

                    if (existingCrop != null)
                    {
                        Console.WriteLine("\nHow many?");
                        int quantityInput = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nYour crop was succesfully added.");
                        existingCrop.AddCrop(quantityInput);
                    }
                    else
                    {
                        Console.WriteLine("\nNo crop with that ID found.");
                    }
                }
                else if (cropChoice == 2)
                {
                    
                    Console.WriteLine("\nAdd a brand new croptype.\n");
                    Console.WriteLine("What Id?");
                    int idInput = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nWhat croptype?");
                    string cropInput = Console.ReadLine();
                    Console.WriteLine("\nWhat name?");
                    string nameInput = Console.ReadLine();
                    Console.WriteLine("\nHow many?");
                    int quantityInput = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n" + quantityInput + " " + nameInput + " is now added to the crops");
                    crops.Add(new Crop(idInput, nameInput, cropInput, quantityInput));
                }
            }
            catch
            {
                Console.WriteLine("You can only write numbers.");
            }
        }
        private void RemoveCrop()
        {
            Console.WriteLine("These are the current existing crops:\n");
            ViewCrops();

            Console.WriteLine("\nWrite the Id of the crop you want to remove\n");
            int inputCHoiceId;
            try
            {
                inputCHoiceId = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("\nYou can only write numbers");
                return;
            }

            Crop removeCrop = FindCrop(inputCHoiceId);
            if (removeCrop != null)
            {
                crops.Remove(removeCrop);
                Console.WriteLine("\nYour crop has been succesfully removed");
            }
            else
            {
                Console.WriteLine("\nWe dont have any crop with that Id.");
            }
        }
        public Crop FindCrop(int id)
        {
            foreach (Crop crop in crops)
            {
                if (crop.Id == id)
                {
                    return crop;
                }
            }
            return null;
        }
        public List<Crop> GetCrop()
        {
            return crops;
        }
        
    }

}
