using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATMTuto
{
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wurthcaraibes\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if(AccNameTb.Text == "" || AccNumTb.Text=="" || FanameTb.Text=="" ||PhoneTb.Text=="" || AddressTb.Text=="" || OccupationTb.Text=="" || PinTb.Text=="" )
            {
                MessageBox.Show("Missing infotmation");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccountTb1 values('" + AccNumTb.Text + "','" + AccNameTb.Text + "','" + FanameTb.Text + "','"+DonDate.Value.Date+ "','" + PhoneTb.Text + "','" + EducationTb.SelectedItem.ToString() + "','" + AddressTb.Text + "','" + OccupationTb.Text + "','" + PinTb.Text + "',"+bal+")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully");
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                    Con.Close();
                    
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
