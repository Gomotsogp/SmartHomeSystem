using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Supplier
    {
        private int id;
        private string companyNane;
        private string telephoneNumber;
        private string addressLine1;
        private string addressLine2;
        private string city;
        private int postalCode;
        private string country;

        public int Id { get => id; set => id = value; }
        public string CompanyNane { get => companyNane; set => companyNane = value; }
        public string TelephoneNumber { get => telephoneNumber; set => telephoneNumber = value; }
        public string AddressLine1 { get => addressLine1; set => addressLine1 = value; }
        public string AddressLine2 { get => addressLine2; set => addressLine2 = value; }
        public string City { get => city; set => city = value; }
        public int PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }

        public Supplier(int id, string name, string telno, string address1, string address2, string city, int code, string country)
        {
            this.id = id;
            this.companyNane = name;
            this.telephoneNumber = telno;
            this.addressLine1 = address1;
            this.addressLine2 = address2;
            this.city = city;
            this.postalCode = code;
            this.country = country;
        }
    }
}
