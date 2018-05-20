using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Client : Person
    {
        private static bool isSuccess = false;
        public Client(int id, string name, string surname, int age, string idno, DateTime dob, string cellNo, string address1, string address2, string city, int code, string country) : base(id, name, surname, age, idno, dob, cellNo, address1, address2, city, code, country)
        {
        }

        public static List<Client> GetClients()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetClients();
        }
        public static bool Insert(string name, string surname, int age, string idno, DateTime dob, string cellno, string address1, string address2, string city, int postalcode, string country)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.CreateNewClient(name,surname,age,idno,dob,cellno,address1,address2,city,postalcode,country);

            return isSuccess;
        }

        public static bool Update(string name, string surname, int age, string cellno, string address1, string address2, string city, int postalcode, string country, int id)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.UpdateClient(name, surname, age, cellno, address1, address2, city, postalcode, country,id);

            return isSuccess;
        }

        public static bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.DeleteClient(id);

            return isSuccess;
        }



    }
}
