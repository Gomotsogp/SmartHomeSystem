using SmartHomeSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHomeSystem.Views
{
    public partial class ClientProduct : Form
    {
        public ClientProduct()
        {
            InitializeComponent();
        }
        private int prodId;
        private int clientId;
        private int empId;

        Employee emp = new Employee();
        Product product = new Product();
        Client client = new Client();
        Orders orders = new Orders();
        Category categories = new Category();
        private void button1_Click(object sender, EventArgs e)
        {
            //validate 
            if (nQuantity.Value == 0)
            {
                MessageBox.Show("Please enter a value");
            }
            else if(txtPrice.Text == "")
            {
                MessageBox.Show("Please enter a price");
            }
            else if (cbbClient.Text == "")
            {
                MessageBox.Show("Please select a client");
            }
            else if (cbbProduct.Text == "")
            {
                MessageBox.Show("Please select a product");
            }
            else if (cbbEmployee.Text == "")
            {
                MessageBox.Show("Please select an employee");
            }
            else
            {
                bool success = orders.Insert(DateTime.Parse(dateTimePicker1.Text), int.Parse(nQuantity.Value.ToString()), decimal.Parse(txtPrice.Text), prodId, clientId, empId);

                if (success)
                {
                    MessageBox.Show("Client Order saved");
                }
                else
                {
                    MessageBox.Show("Client order has not been saved");
                }
            }
            

           
        }
        
        private void ClientProduct_Load(object sender, EventArgs e)
        {
            // load employees in add employee 
            foreach (Employee item in emp.GetEmployees())
            {
                cbbEmployee.Items.Add(item.FirstName + " " + item.LastName);
            
                empId = item.Id;
            }

            // load clients in add employee 
            foreach (Client item in client.GetClients())
            {
                cbbClient.Items.Add(item.FirstName + " " + item.LastName);
                cbbCLient2.Items.Add(item.FirstName + " " + item.LastName);
                clientId = item.Id;
            }

            // load products in add employee 
            foreach (Product item in product.GetCProducts())
            {
                cbbProduct.Items.Add(item.Name);
                prodId = item.Id;
            }

            
        }

        private void cbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product item in product.GetCProducts())
            {
                if (cbbProduct.Text == item.Name)
                {
                    txtPrice.Text = item.Price.ToString();
                }

            }
        }

        private void nQuantity_ValueChanged(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(txtPrice.Text);
            int quantity = int.Parse(nQuantity.Value.ToString());

            decimal totalPrice = price * quantity;

            txtPrice.Text = totalPrice.ToString();
        }

        private void cbbCLient2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*var clientProducts = from o in orders.GetOrders()
                                 select o.Id;
            join p in product.GetCProducts()
                                  on o.Product.Id equals p.Id
                                  join c in categories.GetCategories()
                                  on p.Category.Id equals c.Id
                                  join cc in client.GetClients()
                                  on o.Client.Id equals cc.Id*/

            // clear the controls 
            lstProducts.Items.Clear();
            txtCategory.Text = "";
            txtProd.Text = "";
            rtxtDesc.Text = "";


            foreach (var item in orders.GetOrders())
             {
                 if (cbbCLient2.Text.Contains(item.Client.FirstName))
                 {
                     lstProducts.Items.Add(item.Product.Name);
                 }
             }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in orders.GetOrders())
            {
                if (item.Product.Name == lstProducts.SelectedItem.ToString())
                {
                    txtProd.Text = item.Product.Name;
                    txtCategory.Text = item.Product.Category.Name;
                    rtxtDesc.Text = item.Product.Description;
                }
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
