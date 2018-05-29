using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem.DAL.Model
{
    public class Orders
    {
        private int id;
        private DateTime orderedDate;
        private int quantity;
        private decimal totalPrice;
        private Product product;
        private Client client;
        private Employee employee;

        private bool isSuccess = false;

        public int Id { get => id; set => id = value; }
        public DateTime OrderedDate { get => orderedDate; set => orderedDate = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public Product Product { get => product; set => product = value; }
        public Client Client { get => client; set => client = value; }
        public Employee Employee { get => employee; set => employee = value; }

        public Orders(int id, DateTime ordereddate, int quantity, decimal price, Product product,Client client, Employee employee)
        {
            this.id = id;
            this.orderedDate = ordereddate;
            this.quantity = quantity;
            this.totalPrice = price;
            this.product = product;
            this.client = client;
            this.employee = employee;
        }

        public Orders()
        {

        }

        public List<Orders> GetOrders()
        {
            DataHandler dataHandler = new DataHandler();
            return dataHandler.GetOrders();
        }
        public bool Insert(DateTime ordDate, int quant, decimal price, int prodId, int clientId, int emp)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.CreateNewOrder(ordDate, quant, price, prodId, clientId, emp);

            return isSuccess;
        }

        public bool Update(int id, int quantity, decimal price, int supplier)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.UpdateOrders(id, quantity, price, supplier);

            return isSuccess;
        }

        public bool Delete(int id)
        {
            DataHandler dataHandler = new DataHandler();
            isSuccess = dataHandler.DeleteOrders(id);

            return isSuccess;
        }
    }
}
