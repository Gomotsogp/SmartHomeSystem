using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Product
    {
        private int id;
        private string name;
        private decimal price;
        private string description;
        private DateTime dateCreated;
        private Category category;
        private Supplier supplier;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
        public Category Category { get => category; set => category = value; }
        public Supplier Supplier { get => supplier; set => supplier = value; }

        public Product(int id, string name, decimal price, DateTime dateCreated, Category category, Supplier supplier)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.dateCreated = dateCreated;
            this.category = category;
            this.supplier = supplier;
        }
    }
}
