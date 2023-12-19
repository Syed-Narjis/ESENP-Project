using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ESENP_Project
{
    internal class Connection
    {

        public bool ExecuteQuery(string Query)
        {
            SqlConnection con = new SqlConnection();
            //DataTable dt = new DataTable();

            con.ConnectionString = "Data Source=LAPTOP-UFLSPU3E\\SQLEXPRESS;Initial Catalog=ESENP_Proj;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt);

            con.Close();
            return true;
        }
    }
}
