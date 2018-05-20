using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Invoices
    {
        private int id;
        private DateTime purchasedDate;
        private Orders orders;

        public int Id { get => id; set => id = value; }
        public DateTime PurchasedDate { get => purchasedDate; set => purchasedDate = value; }
        public Orders Orders { get => orders; set => orders = value; }

        public Invoices(int id, DateTime purchaseddate, Orders orders)
        {
            this.id = id;
            this.purchasedDate = purchaseddate;
            this.orders = orders;
        }
    }
}
