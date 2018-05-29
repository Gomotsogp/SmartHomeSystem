using SmartHomeSystem.DAL.Data_Access;
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

        private bool IsSuccess = false;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }

        public Category(int id, string name, string desc)
        {
            this.id = id;
            this.name = name;
            this.description = desc;
        }

        public Category()
        {

        }
        

        public List<Category> GetCategories()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetCategories();
        }
        public bool Insert(string name, string description)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.CreateNewCategory(name, description);

            return IsSuccess;
        }

        public bool Update(string name, string description, int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.UpdateCategory(id, name, description);

            return IsSuccess;
        }

        public bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.DeleteCategory(id);

            return IsSuccess;
        }
    }
}
