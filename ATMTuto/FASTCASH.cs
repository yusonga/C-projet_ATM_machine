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
    public partial class FASTCASH : Form
    {
        public FASTCASH()
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
        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            HOME home = new HOME();
            home.Show();

        }
        
        private void addtransaction1()
        {
            String TrType = "FASTCASH";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + 100 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction2()
        {
            String TrType = "FASTCASH";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + 500 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction3()
        {
            String TrType = "FASTCASH";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + 1000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction4()
        {
            String TrType = "FASTCASH";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + 2000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction5()
        {
            String TrType = "FASTCASH";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + 5000 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addtransaction6()
        {
            String TrType = "FASTCASH";
            try
            {
                Con.Open();
                string query = "insert into TranscationTb1 values('" + Acc + "','" + TrType + "'," + 10000 + ",'" + DateTime.Today.Date.ToString() + "')";
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

        private void FASTCASH_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        int newbalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if (bal < 100)
            {
                MessageBox.Show("Balance Cannot be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - 100;
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success withdraw");
                        Con.Close();
                        addtransaction1();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 500)
            {
                MessageBox.Show("Balance Cannot be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - 500;
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success withdraw");
                        Con.Close();
                        addtransaction2();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 1000)
            {
                MessageBox.Show("Balance Cannot be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - 1000;
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success withdraw");
                        Con.Close();
                        addtransaction3();
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 2000)
            {
                MessageBox.Show("Balance Cannot be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - 2000;
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success withdraw");
                        Con.Close();
                        addtransaction4();
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 5000)
            {
                MessageBox.Show("Balance Cannot be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - 5000;
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success withdraw");
                        Con.Close();
                        addtransaction5();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 10000)
            {
                MessageBox.Show("Balance Cannot be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - 10000;
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set Balance=" + newbalance + "where AccNum= '" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success withdraw");
                        Con.Close();
                        addtransaction6();
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
    }
}
