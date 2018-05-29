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
    public partial class Components : Form
    {
        public Components()
        {
            InitializeComponent();
        }
        private int prodid;
        private int compId;
        Product product = new Product();
        DAL.Model.Component comp = new DAL.Model.Component();
        private void Components_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = comp.GetComponents();

            foreach (Product item in product.GetCProducts())
            {
                cbbProduct.Items.Add(item.Name);
            }

            foreach (DAL.Model.Component item in comp.GetComponents())
            {
                cbbComponnents.Items.Add(item.Name);
            }
        }

        private void cbbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product item in product.GetCProducts())
            {
                if (cbbProduct.Text == item.Name)
                {
                    prodid = item.Id;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool success = comp.Insert(txtComponemt.Text,rtxtDescriptiom.Text,decimal.Parse(txtPrice.Text),prodid);

            if (success)
            {
                MessageBox.Show("Component has been saved");
            }
            else
            {
                MessageBox.Show("Component has not been saved");
            }
        }

        private void cbbComponnents_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DAL.Model.Component item in comp.GetComponents())
            {
                if (cbbComponnents.Text == item.Name)
                {
                    txtEditPrice.Text = item.Price.ToString();
                    rtxtEditDesc.Text = item.Description;
                    compId = item.Id;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool success = comp.Update(compId, rtxtEditDesc.Text, decimal.Parse(txtEditPrice.Text));

            if (success)
            {
                MessageBox.Show("component has been edited");
            }
            else
            {
                MessageBox.Show("component has not been edited");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
