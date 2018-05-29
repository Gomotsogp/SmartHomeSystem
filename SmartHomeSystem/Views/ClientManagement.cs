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
    public partial class ClientManagement : Form
    {
        public ClientManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientManagement management = new ClientManagement();
            management.Hide();
            management.Close();
            Clients client = new Clients();
            client.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientManagement management = new ClientManagement();
            management.Hide();
            management.Close();
            ClientProduct client = new ClientProduct();
            client.ShowDialog();
            
        }

        private void ClientManagement_Load(object sender, EventArgs e)
        {

        }
    }
}
