using System;
using System.Data;
using System.Data.SqlClient;

namespace GetDatas
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Connection();
            Console.ReadLine();
        }
        static void Connection()
        {
            string cs = "Data Source=CGL-081;Initial Catalog=EmployeeDB;Integrated Security=true;";
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    string quarry = "Select * from Employee";
                    SqlCommand cmd = new SqlCommand(quarry, con);
                    //cmd.CommandText = quarry;
                    //cmd.Connection = con;

                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            Console.WriteLine("" + dr["ID"] + " " + dr["FirstName"] + " " + dr["LastName"] + " " + dr["Gender"] + " " + dr["Salary"]);
                        }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}



