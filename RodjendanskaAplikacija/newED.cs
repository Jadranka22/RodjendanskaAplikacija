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
    public partial class newED : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection();
        nbUpdate nb;
        public newED(nbUpdate nbs)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            nb = nbs;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Da li ste sigurni da zelite promeniti ovaj rodjendan?", "Rodjendan je promenjen", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("UPDATE Rodjendan SET ime_roditelja=@ime_roditelja,prezime_roditelja=@prezime_roditelja,kontakt_telefon=@kontakt_telefon,ime_deteta=@ime_deteta,godina=@godina,dece=@dece,odraslih=@odraslih,pice=@pice,datum_rodj=@datum_rodj,ukupna_cena=@ukupna_cena WHERE vreme like @vreme", cn);
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
                    cm.Parameters.AddWithValue("@ukupna_cena", txtPrice.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Rodjendan je uspeno promenjen.");
                    nb.LoadBirthdays();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }
    }
}
