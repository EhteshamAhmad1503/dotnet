using System;
using System.Data.SqlClient;

namespace DataReaders
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source =CGL-081 ;initial Catalog=Infromation;integrated Security=true;";
            SqlConnection con = new SqlConnection(cs);
            string quary = "Select * from Introduction; Select* from Introduction2;";
            SqlCommand cmd = new SqlCommand(quary, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(" {0} {1} {2} ", dr["id"], dr["Name"], dr["Course"]);
            }
            if (dr.NextResult())
            {
                while (dr.Read())
                {
                    Console.WriteLine(" {0} {1} ", dr["Id"], dr["Gender"]);
                }
               
            }
            
            con.Close();
        }

    }
}
