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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        private int clientId;
        private void button1_Click(object sender, EventArgs e)
        {

            string id = txtId.Text.Substring(0, 5);
            int y = int.Parse(id.Substring(0,1));
            int ys = int.Parse(txtId.Text.Substring(0,1));
            if (ys < 2)
            {

            }

            //validate
            if (txtName.Text == "")
            {
                MessageBox.Show("Client name cannot be empty");
            }
            else if (txtSurname.Text == "")
            {
                MessageBox.Show("Client Surname cannot be empty");
            }
            else if (txtAge.Text == "")
            {
                MessageBox.Show("client ");
            }
            else if (txtCell.Text == "")
            {
                MessageBox.Show("client cell number cannot be empty");
            }
            else if (txtCity.Text == "")
            {
                MessageBox.Show("city cannot be empty");
            }
            else if (txtCode.Text == "")
            {
                MessageBox.Show("postal code cannot be empty");
            }
            else if (rtxtAddress1.Text == "")
            {
                MessageBox.Show("address 1 cannot be empty");

            }
            else if (rtxtAddress2.Text == "")
            {
                MessageBox.Show("address 2 cannot be empty");
            }
            else if (rtxtAddress2.Text == "")
            {
                MessageBox.Show("address 2 cannot be empty");
            }
            else if (cbbCountry.Text == "")
            {
                MessageBox.Show("please select a country");
            }
            else
            {
                Client client = new Client();
                bool success = client.Insert(txtName.Text, txtSurname.Text, int.Parse(txtAge.Text), txtId.Text, DateTime.Parse(dateTimePicker1.Text), txtCell.Text, rtxtAddress1.Text, rtxtAddress2.Text, txtCity.Text, int.Parse(txtCode.Text), cbbCountry.Text);

                if (success)
                {
                    MessageBox.Show("Client has been saved");
                }
                else
                {
                    MessageBox.Show("Client has not been saved");
                }
            }

            
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            //validate
            if (txtEditName.Text == "")
            {
                MessageBox.Show("Client name cannot be empty");
            }
            else if (txtEditSurname.Text == "")
            {
                MessageBox.Show("Client Surname cannot be empty");
            }
            else if (txtEditAge.Text == "")
            {
                MessageBox.Show("client ");
            }
            else if (txtEditCell.Text == "")
            {
                MessageBox.Show("client cell number cannot be empty");
            }
            else if (txtEditCity.Text == "")
            {
                MessageBox.Show("city cannot be empty");
            }
            else if (txtEditCode.Text == "")
            {
                MessageBox.Show("postal code cannot be empty");
            }
            else if (rtxtEditAddress1.Text == "")
            {
                MessageBox.Show("address 1 cannot be empty");

            }
            else if (rtxtEditAddress2.Text == "")
            {
                MessageBox.Show("address 2 cannot be empty");
            }
            else if (cbbEditCountry.Text == "")
            {
                MessageBox.Show("please select a country");
            }
            else
            {
                Client client = new Client();
                bool success = client.Update(txtEditName.Text, txtEditSurname.Text, int.Parse(txtEditAge.Text), txtEditCell.Text, rtxtEditAddress1.Text, rtxtEditAddress2.Text, txtEditCity.Text, int.Parse(txtEditCode.Text), cbbEditCountry.Text, clientId);

                if (success)
                {
                    MessageBox.Show("Employe has been updated");
                }
                else
                    MessageBox.Show("Employee has not been updated");
            }
            
        }

        Client client = new Client();
        private void Clients_Load(object sender, EventArgs e)
        {
            // load clients
            dataGridView1.DataSource = client.GetClients();

            // load employees in edit
            foreach (Client item in client.GetClients())
            {
                cbbEditDSelectEmp.Items.Add(item.FirstName + " " + item.LastName);
                cbbDeleteEmp.Items.Add(item.FirstName + " " + item.LastName);
                clientId = item.Id;
            }
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            bool success= client.Delete(clientId);

            if (success)
            {
                MessageBox.Show("Client has been deleted successfully");
            }
            else
                MessageBox.Show("Client has not been deleted!");
        }

        private void cbbEditDSelectEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Client item in client.GetClients())
            {
                if (cbbEditDSelectEmp.Text.Contains(item.FirstName))
                {
                    txtEditName.Text = item.FirstName;
                    txtEditSurname.Text = item.LastName;
                    txtEditAge.Text = item.Age.ToString();
                    txtEditCell.Text = item.CellNumber;
                    txtEditCity.Text = item.City;
                    txtEditCode.Text = item.PostalCode.ToString();
                    rtxtEditAddress1.Text = item.AddressLine1;
                    rtxtEditAddress2.Text = item.AddressLine2;
                    cbbEditCountry.Text = item.Country;
                    dateTimePicker2.Text = item.DateOfBirth.ToLongDateString();
                    txtEditId.Text = item.IDNumber;
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
