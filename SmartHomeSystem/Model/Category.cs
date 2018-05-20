using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Category
    {
        private int id;
        private string name;
        private string description;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }

        public Category(int id, string name, string desc)
        {
            this.id = id;
            this.name = name;
            this.description = desc;
        }
    }
}
