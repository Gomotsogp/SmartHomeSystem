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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        Product products = new Product();
        private int catId;
        private int catEditId;
        private int suppId;
        private int suppEditid;
        private int prodeditId;
        private void Products_Load(object sender, EventArgs e)
        {
            // loading products in view 
            dataGridView1.DataSource = products.GetCProducts();

            // load products in the select product in edit product
            foreach (Product item in products.GetCProducts())
            {
                cbbProducts.Items.Add(item.Name);
                cbbEditCategory.Items.Add(item.Category.Name);
                cbbEditSupplier.Items.Add(item.Supplier.CompanyNane);
                cbCategory.Items.Add(item.Category.Name);
                cbbSupplier.Items.Add(item.Supplier.CompanyNane);

               

                //edit ids
                if (cbbProducts.Text == item.Name)
                {
                    prodeditId = item.Id;
                }

                if (cbbEditCategory.Text == item.Category.Name)
                {
                    catEditId = item.Category.Id;
                }

                if (cbbEditSupplier.Text == item.Supplier.CompanyNane)
                {
                    suppEditid = item.Supplier.Id;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Product item in products.GetCProducts())
            {
                // get id of selected product
                if (cbCategory.Text == item.Category.Name)
                {
                    catId = item.Category.Id;
                }

                if (cbbSupplier.Text == item.Supplier.CompanyNane)
                {
                    suppId = item.Supplier.Id;
                }
            }

            //validate 
            if (txtProduct.Text == "")
            {
                MessageBox.Show("PLease enter a product name");
            }
            else if (txtPrice.Text == "")
            {
                MessageBox.Show("Please enter price for product");
            }
            else if (rtxtDescriptiom.Text =="")
            {
                MessageBox.Show("please enter a product descriptionm");
            }
            else if (cbCategory.Text == "")
            {
                MessageBox.Show("Please select a Category");
            }
            else if (cbbSupplier.Text == "Please select a supplier")
            {
                MessageBox.Show("Please select a supplier");
            }
            else
            {
                bool success = products.Insert(txtProduct.Text, decimal.Parse(txtPrice.Text), rtxtDescriptiom.Text, DateTime.Parse(dateTimePicker1.Text), catId, suppId);

                if (success)
                {
                    MessageBox.Show("Product has been saved");
                }
                else
                {
                    MessageBox.Show("product has not been saved");
                }
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //validate 
            if (cbbProducts.Text == "")
            {
                MessageBox.Show("PLease select a product name");
            }
            else if (txtEditPrice.Text == "")
            {
                MessageBox.Show("Please enter price for product");
            }
            else if (rtxtEditDesc.Text == "")
            {
                MessageBox.Show("please enter a product descriptionm");
            }
            else if (cbbEditCategory.Text == "")
            {
                MessageBox.Show("Please select a Category");
            }
            else if (cbbEditSupplier.Text == "Please select a supplier")
            {
                MessageBox.Show("Please select a supplier");
            }
            else
            {
                bool success = products.Update(prodeditId, decimal.Parse(txtEditPrice.Text), suppEditid);

                if (success)
                {
                    MessageBox.Show("Product has been saved");
                }
                else
                {
                    MessageBox.Show("product has not been saved");
                }
            }
            
        }

        private void cbbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product item in products.GetCProducts())
            {
                if (cbbProducts.Text == item.Name)
                {
                    txtEditPrice.Text = item.Price.ToString();
                    rtxtEditDesc.Text = item.Description;
                    cbbEditCategory.Text = item.Category.Name;
                    cbbEditSupplier.Text = item.Supplier.CompanyNane;
                    dateTimePicker2.Text = item.DateCreated.ToLongDateString();
                    prodeditId = item.Id;
                }
            }
        }

        private void cbbEditCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product item in products.GetCProducts())
            {
                // get id of selected product
                if (cbbEditCategory.Text == item.Category.Name)
                {
                    catEditId = item.Category.Id;
                }
            }
        }

        private void cbbEditSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Product item in products.GetCProducts())
            {
                // get id of selected product
                if (cbbEditSupplier.Text == item.Supplier.CompanyNane)
                {
                    suppEditid = item.Supplier.Id;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
