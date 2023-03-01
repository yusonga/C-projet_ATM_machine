using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMTuto
{
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wurthcaraibes\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;

        private void addtransaction()
        {
            String TrType = "Deposit";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + DepoAmtTb.Text + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void button1_Click(object sender, EventArgs e)
        {
            if(DepoAmtTb.Text == "" || Convert.ToInt32(DepoAmtTb.Text) <= 0)
            {
                MessageBox.Show("Enter the amount to deposit");
            }
            else
            {
                
                newbalance = oldbalance + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                    SqlCommand cmd = new SqlCommand(query,Con) ;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success deposit");
                    Con.Close();
                    addtransaction();
                    HOME home = new HOME(); 
                    home.Show();
                    this.Hide();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int oldbalance, newbalance;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from AccountTb1 where AccNum='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance= Convert.ToInt32( dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            HOME home = new HOME();
            home.Show();
            this.Hide();
        }

        private void Deposit_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}
