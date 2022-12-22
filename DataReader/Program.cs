using System;
using System.Data.SqlClient;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source =CGL-081 ;initial Catalog=Infromation;integrated Security=true;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select*from Introduction", con);
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Console.WriteLine(" Id : " + dr[0] + " Name: " + dr[1] + " Course: " + dr[2] + " Collage: " + dr[3] + " Gender: " + dr[4] + " City " + dr[5]);
                }
            }
            con.Close();
            Console.ReadLine();
        }
    }
}
