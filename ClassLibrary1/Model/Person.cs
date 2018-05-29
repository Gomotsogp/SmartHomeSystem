using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public abstract class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private int age;
        private string iDNumber;
        private DateTime dateOfBirth;
        private string cellNumber;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private int postalCode;
        private string country;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public string IDNumber { get => iDNumber; set => iDNumber = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string CellNumber { get => cellNumber; set => cellNumber = value; }
        public string AddressLine1 { get => addressLine1; set => addressLine1 = value; }
        public string AddressLine2 { get => addressLine2; set => addressLine2 = value; }
        public string City { get => city; set => city = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }

        public Person(int id, string name, string surname, int age, string idno, DateTime dob, string cellNo, string address1, string address2, string city, int code, string country)
        {
            this.id = id;
            this.firstName = name;
            this.lastName = surname;
            this.age = age;
            this.dateOfBirth = dob;
            this.iDNumber = idno;
            this.cellNumber = cellNo;
            this.addressLine1 = address1;
            this.addressLine2 = address2;
            this.city = city;
            this.postalCode = code;
            this.country = country;
        }

        public Person()
        {

        }
        public override string ToString()
        {
            return "Name = "+firstName;
        }
    }
}
