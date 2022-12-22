using Microsoft.IdentityModel.Protocols;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Aggregate_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.ScalerFunction();
            Console.ReadLine();
        }
        static void ScalerFunction()
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {

                using (con = new SqlConnection(cs))
                {
                    //string quary = "SELECT Max(Salary) FROM Employee ";
                    //string quary = "SELECT Min(Salary) FROM Employee ";
                    //string quary = "SELECT COUNT(Salary) FROM Employee ";
                    //string quary = "SELECT AVG(Salary) FROM Employee ";
                    string quary = "SELECT SUM(Salary) FROM Employee ";
                    SqlCommand cmd = new SqlCommand(quary, con);
                    con.Open();
                    int a = (int)cmd.ExecuteScalar();
                    Console.WriteLine(a);
                }
            }
            finally
            {
                con.Close();
            }

        }
    }
}

