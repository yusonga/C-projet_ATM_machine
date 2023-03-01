using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMTuto
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ministatement mini = new ministatement();
            mini.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            this.Hide();
            bal.Show();
        }
        public static String AccNumber;

        private void HOME_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = "Account Number:" + Login.AccNumber;
            AccNumber = Login.AccNumber;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangePin Pin = new ChangePin();
            Pin.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            withdraw wd = new withdraw();
            wd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FASTCASH fCash = new FASTCASH();
            fCash.Show();
            this.Hide();
        }
    }
}
