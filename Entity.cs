using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Entity
    {
        public int Id { get; set; }
        protected string Name { get; set; }

        public Entity(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public abstract string GetDescriptions();
    }
}
