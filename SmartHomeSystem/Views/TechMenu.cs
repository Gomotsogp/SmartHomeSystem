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
    public partial class TechMenu : Form
    {
        public TechMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Employees emp = new Employees();
            emp.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TechSupport ts = new TechSupport();
            ts.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Schedules schedules = new Schedules();
            schedules.ShowDialog();
        }

        private void TechMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
