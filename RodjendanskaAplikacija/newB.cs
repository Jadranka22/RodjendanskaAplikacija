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
    public partial class newB : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        SqlDataReader dr;
        NewBirthday nb;
        public newB(NewBirthday nbs)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            nb = nbs;
        }

        private void Clear()
        {
            btnUpdate.Enabled = true;
            txtNameP.Clear();
            txtNameP.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNameP.Text = "";
            txtLastN.Text = "";
            txtPhoneNo.Text = "";
            txtKidName.Text = "";
            dateTimePicker1.Text = "";
            txtYearsK.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            comboBox4.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite sacuvati ovaj rodjendan?", "Cuvanje rodjendana", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into Rodjendan (ime_roditelja,prezime_roditelja,kontakt_telefon,ime_deteta,godina,dece,odraslih,pice,datum_rodj,vreme)VALUES(@ime_roditelja,@prezime_roditelja,@kontakt_telefon,@ime_deteta,@godina,@dece,@odraslih,@pice,@datum_rodj,@vreme)", cn);
                    cm.Parameters.AddWithValue("@ime_roditelja", txtNameP.Text);
                    cm.Parameters.AddWithValue("@prezime_roditelja", txtLastN.Text);
                    cm.Parameters.AddWithValue("@kontakt_telefon", txtPhoneNo.Text);
                    cm.Parameters.AddWithValue("@ime_deteta", txtKidName.Text);
                    cm.Parameters.AddWithValue("@datum_rodj", DateTime.Parse(dateTimePicker1.Text));
                    cm.Parameters.AddWithValue("@godina", txtYearsK.Text);
                    cm.Parameters.AddWithValue("@dece", comboBox3.Text);
                    cm.Parameters.AddWithValue("@odraslih", comboBox2.Text);
                    cm.Parameters.AddWithValue("@pice", comboBox1.Text);
                    cm.Parameters.AddWithValue("@vreme", comboBox4.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Rodjendan je uspesno sacuvan.");
                    Clear();
                    nb.LoadBirthdays();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
