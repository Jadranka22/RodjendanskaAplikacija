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
    public partial class nbUpdate : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public nbUpdate()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            LoadBirthdays();
        }

        public void LoadBirthdays()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("SELECT * FROM Rodjendan order by Id", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                dataGridView1.Rows.Add(i, dr["ime_roditelja"].ToString(), dr["prezime_roditelja"].ToString(), dr["kontakt_telefon"].ToString(), dr["ime_deteta"].ToString(), dr["godina"].ToString(), dr["dece"].ToString(), dr["odraslih"].ToString(), dr["pice"].ToString(), dr["datum_rodj"].ToString(), dr["vreme"].ToString(), dr["ukupna_cena"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void pbOpen_Click(object sender, EventArgs e)
        {
            newED nss = new newED(this);
            nss.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {

                newED ned = new newED(this);
                ned.txtNameP.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                ned.txtLastN.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                ned.txtPhoneNo.Text = dataGridView1[3, e.RowIndex].Value.ToString();
                ned.txtKidName.Text = dataGridView1[4, e.RowIndex].Value.ToString();
                ned.txtYearsK.Text = dataGridView1[5, e.RowIndex].Value.ToString();
                ned.comboBox3.Text = dataGridView1[6, e.RowIndex].Value.ToString();
                ned.comboBox2.Text = dataGridView1[7, e.RowIndex].Value.ToString();
                ned.comboBox1.Text = dataGridView1[8, e.RowIndex].Value.ToString();
                ned.dateTimePicker1.Text = dataGridView1[9, e.RowIndex].Value.ToString();
                ned.comboBox4.Text = dataGridView1[10, e.RowIndex].Value.ToString();
                ned.txtPrice.Text = dataGridView1[11, e.RowIndex].Value.ToString();
                ned.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Da li ste sigurni da zelite da obrisete ovaj rodjendan?", "Obrisan rodjendan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from Rodjendan where ime_roditelja like '" + dataGridView1[1, e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Rodjendan je uspesno obrisan.", "Rodjendan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBirthdays();
                }
            }
        }
    }
}
