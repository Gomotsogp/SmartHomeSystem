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

        public TechnicalSupport(int id, string name, string surname, int age, string idno, DateTime dob, string cellNo, string address1, string address2, string city, int code, string country, Department dept, string username, string password, string speciality, int yearsExperience) : base(id, name, surname, age, idno, dob, cellNo, address1, address2, city, code, country, dept, username, password)
        {
            this.speciality = speciality;
            this.yearsOfExperience = yearsExperience;
        }

        public string Speciality { get => speciality; set => speciality = value; }
        public int YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
    }
}
