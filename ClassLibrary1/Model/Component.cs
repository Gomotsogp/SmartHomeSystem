using SmartHomeSystem.DAL.Data_Access;
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
        private string description;

        private bool isSuccess = false;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public Product Products { get => products; set => products = value; }

        public Component(int id, string name,string desc, decimal price,Product product)
        {
            this.id = id;
            this.products = product;
            this.name = name;
            this.price = price;
        }

        public Component()
        {

        }

        public List<Component> GetComponents()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetComponents();
        }
        public bool Insert(string name, string description, decimal price, int product)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.CreateNewComponent(name, description, price, product);

            return isSuccess;
        }

        public bool Update(int id,string description, decimal price)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.UpdateComponent(id, description,price);

            return isSuccess;
        }

        public bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.DeleteComponent(id);

            return isSuccess;
        }
    }
}
