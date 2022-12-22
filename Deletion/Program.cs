using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Deletion
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.Deletions();
            Console.ReadLine();
        }
        static void Deletions()
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {

                using (con = new SqlConnection(cs))
                {
                    Console.WriteLine("Employee ID:");
                    string ID = Console.ReadLine();

                    string quary = "Delete from Employee where ID=@ID";
                    SqlCommand cmd = new SqlCommand(quary, con);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data has been deleted Successfully");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong Please Try Again");
            }
            finally
            {
                con.Close();
            }

        }
    }
}

