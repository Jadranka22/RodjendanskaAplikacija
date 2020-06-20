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
    public partial class ChangePassword : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public ChangePassword()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "    " + msg;
            lblErrorMessage.Visible = true;
        }

        private void btnChange_Click_1(object sender, EventArgs e)
        {
            try
            {
                string password = dbcon.GetPassword(txtUsername.Text);
                if (password != txtOldPass.Text)
                {
                    msgError("  Lozinka nije ista!");
                }
                else if (txtNewPass.Text != txtRetypePass.Text)
                {
                    msgError("  Nova lozinka nije dobro unesena");
                }
                else if (txtUsername.Text == "" && txtOldPass.Text == "" || txtNewPass.Text == "" || txtRetypePass.Text == "")
                {
                    msgError("  Molim vas unesite sva polja!");
                }
                else
                {
                    if (MessageBox.Show("Da li ste sigurni da zelite promeniti lozinku?", "Potvrdi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("update AdminLogin set password =@password where username = @username", cn);
                        cm.Parameters.AddWithValue("@username", txtUsername.Text);
                        cm.Parameters.AddWithValue("@password", txtNewPass.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        msgError("   Lozinka je uspesno promenjena!");
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                msgError(ex.Message);
            }
        }
    }
}
