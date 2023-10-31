using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Crop : Entity
    {
        public string CropType { get; set; }
        private int Quantity { get; set; }
        public Crop(int id, string name, string cropType, int quantity)
            : base(id, name)
        {
            Id = id;
            Name = name;
            CropType = cropType;
            Quantity = quantity;
        }
        public override string GetDescriptions()
        {
            Console.WriteLine("Id: " + Id + ", Name: " + Name + ", Type: " + CropType + ", Quantity: " + Quantity);
            return null;
        }
        public void AddCrop(int amount)
        {
            Quantity += amount;
        }
        public bool TakeCrop(int num)
        {
            if (num <= Quantity)
            {
                Quantity -= num; 
                return true;
            }
            else
            {
                return false;
            }
        }
    }
} 
