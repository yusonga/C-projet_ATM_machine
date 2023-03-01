using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMTuto
{
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wurthcaraibes\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Pin1Tb.Text == "" || Pin2Tb.Text == "")
            {
                MessageBox.Show("Enter and confirm the new pin");
            }
            else if(Pin2Tb.Text!= Pin1Tb.Text)
            {
                MessageBox.Show("confirmed pin is different");
            }
            else
            {

                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set Pin=" + Pin1Tb.Text + "where AccNum= '" + Acc + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pin Successfully changed");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME home = new HOME();
            home.Show();
        }
    }
}
