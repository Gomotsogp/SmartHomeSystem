using SmartHomeSystem.DAL.Data_Access;
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

        private bool isSuccess = false;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
        public Category Category { get => category; set => category = value; }
        public Supplier Supplier { get => supplier; set => supplier = value; }
        public string Description { get => description; set => description = value; }

        public Product(int id, string name, decimal price, string desc, DateTime dateCreated, Category category, Supplier supplier)
        {
            this.id = id;
            this.name = name;
            this.description = desc;
            this.price = price;
            this.dateCreated = dateCreated;
            this.category = category;
            this.supplier = supplier;
        }

        public Product()
        {

        }



        public List<Product> GetCProducts()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.Getproducts();
        }
        public bool Insert(string name, decimal price, string description, DateTime datecreated, int category, int supplier)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.CreateNewProduct( name,  price, description, datecreated, category, supplier);

            return isSuccess;
        }

        public bool Update(int id, decimal price, int supplier)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.UpdateProduct( id, price, supplier);

            return isSuccess;
        }

        public bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.DeleteClient(id);

            return isSuccess;
        }
    }
}
