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
           bool inserted = dept.Insert(textBox1.Text, richTextBox1.Text);

            if (inserted)
            {
                MessageBox.Show("Department has been saved to the database");
            }
        }

        private void Department_Load(object sender, EventArgs e)
        {
            var dept = new DAL.Model.Department();
            List<DAL.Model.Department> departments = dept.GetDepartments();

            dataGridView1.DataSource = departments;
            dataGridView1.Refresh();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}
