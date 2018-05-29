using SmartHomeSystem.DAL.Data_Access;
using SmartHomeSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHomeSystem.Views
{
    public partial class Login : Form
    {
        public Login()
        {
            //Thread t = new Thread(new ThreadStart(SplashScreen));
            //t.Start();
            //Thread.Sleep(5000);
            InitializeComponent();
            //t.Abort();

        }

        public void SplashScreen()
        {
            Application.Run(new SplashScreen());
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var emp = new Employee();
            List<Employee> employees = emp.GetEmployees();

            string username = textBox1.Text;
            string password = textBox2.Text;
            foreach (Employee item in employees)
            {
                if (item.UserName == username && item.Password == password)
                {
                    MessageBox.Show("User has logged in successfully");

                    Menu menu = new Menu();
                    menu.ShowDialog();
                    this.Hide();
                    break;
                }
                else
                {
                    MessageBox.Show("Invalid user login credetials");
                }
            }
        }
    }
}
