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
    public partial class Main : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        public Main()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            customizeDesing();
        }

        private void customizeDesing()
        {
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panel4.Visible == true)
                panel4.Visible = false;
            if (panel5.Visible == true)
                panel5.Visible = false;
            if (panel6.Visible == true)
                panel6.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void pictureBoxMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNewB_Click(object sender, EventArgs e)
        {
            openCH(new NewBirthday());
            hideSubMenu();
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private Form activeForm = null;
        private void openCH(Form CHForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = CHForm;
            CHForm.TopLevel = false;
            CHForm.FormBorderStyle = FormBorderStyle.None;
            CHForm.Dock = DockStyle.Fill;
            panelCH.Controls.Add(CHForm);
            panelCH.Tag = CHForm;
            CHForm.BringToFront();
            CHForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            showSubMenu(panel5);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            openCH(new nbUpdate());
            hideSubMenu();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            showSubMenu(panel6);
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            openCH(new ChangePassword());
            hideSubMenu();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
