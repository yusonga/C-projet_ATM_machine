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
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wurthcaraibes\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTb1 where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "Balance Rs " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void addtransaction()
        {
            String TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + wdamtTb.Text + ",'" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Login log = new Login();
                log.Show();
                this.Hide();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        int  newbalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if(wdamtTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if(Convert.ToInt32(wdamtTb.Text)<=0)
            {
                MessageBox.Show("Enter a valid Amount");
            }
            else if(Convert.ToInt32(wdamtTb.Text) > bal){
                MessageBox.Show("Balance Cannot be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - Convert.ToInt32(wdamtTb.Text);
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success withdraw");
                        Con.Close();
                        addtransaction();
                        HOME home = new HOME();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME home = new HOME();
            home.Show();
            
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
