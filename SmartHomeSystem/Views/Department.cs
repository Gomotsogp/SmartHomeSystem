using SmartHomeSystem.DAL.Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartHomeSystem.DAL.Model;

namespace SmartHomeSystem.Views
{
    public partial class Department : Form
    {
        public Department()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dept = new DAL.Model.Department();
            //validation
            if (textBox1.Text == "")
            {
                MessageBox.Show("Name cannot be empty");
            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("descroption cannot be empty");
            }
            else
            {
                bool inserted = dept.Insert(textBox1.Text, richTextBox1.Text);

                if (inserted)
                {
                    MessageBox.Show("Department has been saved to the database");
                }
            }

            
        }
        DAL.Model.Department dept = new DAL.Model.Department();
        List<DAL.Model.Department> departments; 
        private void Department_Load(object sender, EventArgs e)
        {
            departments = dept.GetDepartments();
            dataGridView1.DataSource = departments;
            dataGridView1.Refresh();

            //load departmetns 
            foreach (DAL.Model.Department item in departments)
            {
                comboBox1.Items.Add(item.Name);
                comboBox2.Items.Add(item.Name);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(DAL.Model.Department item in departments)
            {
                if (item.Name == comboBox1.Text)
                {
                    richTextBox2.Text = item.Description;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataHandler data = new DataHandler();
            foreach (DAL.Model.Department item in departments)
            {
                data.UpdateDepartment(item.Id,comboBox1.Text,richTextBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataHandler data = new DataHandler();
            foreach (DAL.Model.Department item in departments)
            {
                data.DeleteDepartment(item.Id);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
