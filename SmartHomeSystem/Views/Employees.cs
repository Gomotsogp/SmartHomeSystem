using SmartHomeSystem.DAL.Data_Access;
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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        private int deptId;
        private int editEmpId;
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            else if (txtUsername.Text == "")
            {
                MessageBox.Show("username cannot be empty");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password cannot be empty");
            }
            else
            {
                // add an employee
                Employee employee = new Employee();

                bool success = employee.Insert(txtName.Text, txtSurname.Text, int.Parse(txtAge.Text), txtId.Text, DateTime.Parse(dateTimePicker1.Text), txtCell.Text, rtxtAddress1.Text, rtxtAddress2.Text, txtCity.Text, int.Parse(txtCode.Text), cbbCountry.Text, deptId, txtUsername.Text, txtPassword.Text);

                if (success)
                {
                    MessageBox.Show("Employee has been saved");
                    tabControl1.SelectTab(0);
                    dataGridView1.Refresh();
                }
                else
                {
                    MessageBox.Show("Employee has not been saved");
                }
            }

            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        DAL.Model.Department dept = new DAL.Model.Department();
        List<DAL.Model.Department> departments;
        Employee emp = new Employee();
        private void Employees_Load(object sender, EventArgs e)
        {
            // load employees
            dataGridView1.DataSource = emp.GetEmployees();


            //load departmetns
            departments = dept.GetDepartments();
             
            foreach (DAL.Model.Department item in departments)
            {
                cbbDept.Items.Add(item.Name);
                deptId = item.Id;
            }

            // load employees in edit
            foreach (Employee item in emp.GetEmployees())
            {
                cbbEditDSelectEmp.Items.Add(item.FirstName +" "+item.LastName);
                cbbDeleteEmp.Items.Add(item.FirstName + " " + item.LastName);
                editEmpId = item.Id;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtAge.Text = "";
            txtId.Text = "";
            dateTimePicker1.Text = "";
            txtCell.Text = "";
            rtxtAddress1.Text = "";
            rtxtAddress2.Text = "";
            txtCity.Text = "";
            txtCode.Text = "";
            cbbCountry.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void cbbEditDSelectEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Employee item in emp.GetEmployees())
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
                    txtEditUsername.Text = item.UserName;
                    txtEditPass.Text = item.Password;
                    cbbEditCountry.Text = item.Country;
                    dateTimePicker2.Text = item.DateOfBirth.ToLongDateString();
                    txtEditId.Text = item.IDNumber;
                }
            }
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
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
            else if (txtEditUsername.Text == "")
            {
                MessageBox.Show("username cannot be empty");
            }
            else if (txtEditPass.Text == "")
            {
                MessageBox.Show("password cannot be empty");
            }
            else
            {
                Employee emp = new Employee();
                bool success = emp.Update(txtEditName.Text, txtEditSurname.Text, int.Parse(txtEditAge.Text), txtEditCell.Text, rtxtEditAddress1.Text, rtxtEditAddress2.Text, txtEditCity.Text, int.Parse(txtEditCode.Text), cbbEditCountry.Text, deptId, txtEditUsername.Text, txtEditPass.Text, editEmpId);

                if (success)
                {
                    MessageBox.Show("EMploye has been updated");
                }
                else
                    MessageBox.Show("Employee has not been updated");
            }
            
        }

        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            if (cbbDeleteEmp.Text == "")
            {
                MessageBox.Show("Please select an employee to delete");
            }
            else
            {
                bool success = emp.Delete(editEmpId);

                if (success)
                {
                    MessageBox.Show("Client has been deleted successfully");
                }
                else
                    MessageBox.Show("Client has not been deleted!");
            }
            
        }
    }
}
