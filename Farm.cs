using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Farm
    {
        AnimalManager animalManager;
        CropManager cropManager;
        public Farm()
        {
            cropManager = new CropManager();
            animalManager = new AnimalManager(cropManager);
        }
        public void MainMenu()
        {
            int MainMenuInput = 0;
            while (MainMenuInput != 3)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("MAIN MENU\n");
                    Console.WriteLine("1. Animal menu");
                    Console.WriteLine("2. Crop menu");
                    Console.WriteLine("3. End program\n");
                    Console.WriteLine("What would you like to do? Chose by number");
                    MainMenuInput = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\nYou can only write numbers");
                }

                switch (MainMenuInput.ToString())
                {
                    case "1":
                        Console.Clear();
                        animalManager.AnimalMenu(cropManager.GetCrop());
                        break;
                    case "2":
                        Console.Clear();
                        cropManager.CropMenu();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("\nYou either wrote to many numbers or a number that doesnt exist.");
                        break;
                }
            }
        }
    }
}
