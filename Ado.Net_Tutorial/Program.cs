using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Ado.Net_Tutorial 
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
            //string cs = "Data Source=CGL-081;Initial Catalog=EmployeeDB;Integrated Security=true;";
            string cs = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            SqlConnection con = null;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();
                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Data has been connected Successfully");
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
