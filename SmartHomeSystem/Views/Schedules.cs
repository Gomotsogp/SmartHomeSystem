using SmartHomeSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartHomeSystem.Views
{
    public partial class Schedules : Form
    {
        public Schedules()
        {
            InitializeComponent();
        }

        private int clientID;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*timer1.Enabled = true;
            timer1.Start();
            label4.Text = timer1.Interval.ToString() ;
            StopWatch*/
        }
        Client client = new Client();
        TechnicalSupport support = new TechnicalSupport();
        Calls calls = new Calls();
        private int TechId;
        private int callId;

        private void Schedules_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = support.GetTechnicalSupports();

            foreach (Client item in client.GetClients())
            {
                cbbClient.Items.Add(item.FirstName + " " + item.LastName);

            }

            foreach (TechnicalSupport item in support.GetTechnicalSupports())
            {
                cbbTech.Items.Add(item.FirstName + " " + item.LastName);
            }

            foreach (Calls item in calls.GetCalls())
            {
                lstClient.Items.Add(item.Client.FirstName + " " + item.Client.LastName);
            }
        }

        Stopwatch timer = new Stopwatch();
        private void btnAnswer_Click(object sender, EventArgs e)
        {
           
            timer.Start();
            lblTime.Text = timer.Elapsed.ToString();
            
        }

        private void cbbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Client item in client.GetClients())
            {
                if (cbbClient.Text.Contains(item.FirstName))
                {
                    clientID = item.Id;
                }
            }
        }
        Calls cals = new Calls();
        private void btnSaveCall_Click(object sender, EventArgs e)
        {
            if (cbbClient.Text == "")
            {
                MessageBox.Show("Please select a client");
            }
            else if (rtxtReason.Text == "")
            {
                MessageBox.Show("Please enter a reason");
            }
            else
            {
                bool success = cals.Insert(clientID,lblTime.Text,rtxtReason.Text);

                if (success)
                {
                    MessageBox.Show("call has been saved");
                }
                else
                {
                    MessageBox.Show("Call has not been saved");
                }
            }
        }

        private void btnHangUp_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lblTime.Text = timer.Elapsed.ToString();
        }

        private void cbbTech_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (TechnicalSupport item in support.GetTechnicalSupports())
            {
                if (cbbTech.Text.Contains(item.FirstName))
                {
                    TechId = item.TechId;
                }
            }
        }

        private void lstClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Calls item in calls.GetCalls())
            {
                if (lstClient.SelectedItem.ToString().Contains(item.Client.FirstName))
                {
                    txtName.Text = item.Client.FirstName + item.Client.LastName;
                    rtxtReasons.Text = item.Description;
                    callId = item.Id;
                }
            }
        }

        Schedule schedule = new Schedule();
        private void button1_Click(object sender, EventArgs e)
        {
            //validate
            if (cbbTech.Text == "")
            {
                MessageBox.Show("PLease select a technician to be assigned to the job");
            }
            else if (txtName.Text == "" || rtxtReasons.Text == "")
            {
                MessageBox.Show("please make sure that a call has been selected ");
            }
            else
            {
                bool success = schedule.Insert(DateTime.Parse(dateTimePicker1.Text),dateTimePicker2.Text,callId,TechId);

                if (success)
                {
                    MessageBox.Show("scheduling of technician succeeded");
                }
                else
                {
                    MessageBox.Show("scheduling of technician has failed");
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
