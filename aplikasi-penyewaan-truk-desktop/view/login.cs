using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace desktop.view
{
    public partial class login : Form
    {
        string stringMySqlConnection = "Database=truckdb_kkp;" +
                                   "Server=localhost;" +
                                   "port=3306;" +
                                   "Uid=root;" +
                                   "password=lsd;";
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terima Kasih");
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection ube = new MySqlConnection(stringMySqlConnection);
            MySqlDataAdapter ubee = new MySqlDataAdapter("Select Count(*) From login where username='" + txtUsername.Text + "' and password='" + txtPass.Text + "'", ube);
            DataTable dt = new DataTable();
            ubee.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")//dt.Rows[0][0].ToString() == "1"
            {
                progressBar1.Value = Convert.ToInt32(progressBar1.Value) + 100;
                MessageBox.Show("Selamat Datang");
                Index uu = new Index();
                uu.Show();
                txtUsername.Text = "";
                txtPass.Text = "";
                progressBar1.Value = 0;
                //this.Hide();
            }
            else
            {
                MessageBox.Show("Periksa Kembali Password Anda");
                txtUsername.Text = "";
                txtPass.Text = "";
            }
        }
        private void ok_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //progressBar1.Value = Convert.ToInt32(progressBar1.Value) + 10;

            //if (Convert.ToInt32(progressBar1.Value) > 90)
            //{
            //    timer1.Enabled = false;
            //    MessageBox.Show("Selamat Datang Brother and Sister");
            //    Index uu = new Index();
            //    uu.Show();
            //    txtUsername.Text = "";
            //    txtPass.Text = "";
            //}
        }
    }
}
