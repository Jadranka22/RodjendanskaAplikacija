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

namespace RodjendanskaAplikacija
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public Login()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "    " + msg;
            lblErrorMessage.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("select * from AdminLogin where username = @username and password = @password", cn);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);//admin
                cm.Parameters.AddWithValue("@password", txtPassword.Text);//admin12
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Main m = new Main();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    msgError("  Pogresno korisniko ime i lozinka");
                }

                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                msgError(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }
    }
}
