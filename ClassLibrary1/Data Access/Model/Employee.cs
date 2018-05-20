using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Employee:Person
    {
        private Department deptId;
        private string userName;
        private string password;
        private static bool IsSuccess = false;
        public Department DeptId { get => deptId; set => deptId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        
        public Employee(int id, string name, string surname, int age, string idno, DateTime dob, string cellNo, string address1, string address2, string city, int code, string country,Department dept,string username, string password) : base(id, name, surname, age, idno, dob, cellNo, address1, address2, city, code, country)
        {
            this.deptId = dept;
            this.UserName = username;
            this.password = password;
        }
        public Employee()
        {

        }

        public List<Employee> GetEmployees()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetEmployees();
        }
        public bool Insert(string name, string surname, int age, string idno, DateTime dob, string cellno, string address1, string address2, string city, int postalcode, string country, int deptid, string username, string password)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.CreateNewEmployee(name, surname, age, idno, dob, cellno, address1, address2, city, postalcode, country,deptid,username,password);

            return IsSuccess;
        }

        public static bool Update(string name, string surname, int age, string cellno, string address1, string address2, string city, int postalcode, string country, int deptid, string username, string password, int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.UpdateEmployee(name, surname, age, cellno, address1, address2, city, postalcode, country,deptid,username,password, id);

            return IsSuccess;
        }

        public static bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            IsSuccess = dataHandler.DeleteEmployee(id);

            return IsSuccess;
        }

    }
}
