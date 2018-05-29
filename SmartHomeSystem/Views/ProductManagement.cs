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
    public partial class ProductManagement : Form
    {
        public ProductManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Products prod = new Products();
            prod.ShowDialog();
            //this.Hide();
           // this.Close();
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            Components c = new Components();
            c.ShowDialog();
            
        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
