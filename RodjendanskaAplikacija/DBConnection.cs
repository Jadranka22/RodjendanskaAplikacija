using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RodjendanskaAplikacija
{
    class DBConnection
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private double dailybirthdays;
        public string MyConnection()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Rodjendaonica;Integrated Security=True";
            return con;
        }

        public string GetPassword(string user)
        {
            string password = "";
            cn.ConnectionString = MyConnection();
            cn.Open();
            cm = new SqlCommand("select * from AdminLogin where username = @username", cn);
            cm.Parameters.AddWithValue("@username", user);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["password"].ToString();
            }
            dr.Close();
            cn.Close();
            return password;
        }
    }
}
