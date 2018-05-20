using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Component
    {
        private int id;
        private Product products;
        private string name;
        private decimal price;
        private DateTime purchaseDate;

        public int Id { get => id; set => id = value; }
        public Product Products { get => products; set => products = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }

        public Component(int id, Product product, string name, decimal price, DateTime boughtdate)
        {
            this.id = id;
            this.products = product;
            this.name = name;
            this.price = price;
            this.purchaseDate = boughtdate;
        }
    }
}
