using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class TechnicalSupport:Employee
    {
        private string speciality;
        private int yearsOfExperience;
        private int techId;
        public TechnicalSupport(int id, string name, string surname, int age, string idno, DateTime dob, string cellNo, string address1, string address2, string city, int code, string country, Department dept, string username, string password,int techid, string speciality, int yearsExperience) : base(id, name, surname, age, idno, dob, cellNo, address1, address2, city, code, country, dept, username, password)
        {
            this.speciality = speciality;
            this.yearsOfExperience = yearsExperience;
            this.techId = techid;
        }

        public TechnicalSupport()
        {

        }
        private bool isSuccess = false;

        public string Speciality { get => speciality; set => speciality = value; }
        public int YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
        public int TechId { get => techId; set => techId = value; }

        public List<TechnicalSupport> GetTechnicalSupports()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetTechSupport();
        }
        public bool InsertTech(string name, decimal price, string description, DateTime datecreated, int category, int supplier)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.CreateNewProduct(name, price, description, datecreated, category, supplier);

            return isSuccess;
        }
        public bool CreateNewEmployee(string name, string surname, int age, string idno, DateTime dob, string cellno, string address1, string address2, string city, int postalcode, string country, int deptid, string username, string password, int yearsExperience, string specialty)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.CreateNewTech(name, surname, age, idno, dob, cellno, address1, address2, city, postalcode, country,  deptid,  username,  password,  yearsExperience,  specialty);

            return isSuccess;
        }


        public bool UpdateTech(int id, decimal price, int supplier)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.UpdateProduct(id, price, supplier);

            return isSuccess;
        }

        public bool DeleteTech(int id)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.DeleteClient(id);

            return isSuccess;
        }
    }
}
