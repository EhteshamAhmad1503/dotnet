using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlCommands
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
            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {

                using (con = new SqlConnection(cs))
                {

                    string quary = "GetEmployee";
                    SqlCommand cmd = new SqlCommand(quary, con);
                    // cmd.CommandText = quary;
                    // cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        Console.WriteLine("ID= " + dr["ID"] + " FirstName= " + dr["FirstName"] + " LastName= " + dr["LastName"] + " Gender= " + dr["Gender"] + " Salary= " + dr["Salary"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went wrong");
            }
            finally
            {
                con.Close();
            }

        }
    }

}

