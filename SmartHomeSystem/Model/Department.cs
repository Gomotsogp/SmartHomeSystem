using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Department
    {
        private int id;
        private string name;
        private string description;
        private static bool IsSuccess = false;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }

        public Department()
        {

        }
        public Department(int id, string name, string desc)
        {
            this.id = id;
            this.name = name;
            this.description = desc;
        }

        public List<Department> GetDepartments()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetDepartments();
        }
        public  bool Insert(string name, string description)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.CreateNewDepartment(name, description);

            return IsSuccess;
        }

        public bool Update(string name, string description, int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.UpdateDepartment(id,name, description);

            return IsSuccess;
        }

        public bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.DeleteDepartment(id);

            return IsSuccess;
        }
    }
}
