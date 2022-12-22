using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Insertion
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.insertions();
            Console.ReadLine();
        }
        static void insertions()
        {

            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = null;
            try
            {

                using (con = new SqlConnection(cs))
                {

                    Console.WriteLine("Employee FistName:");
                    string FirstName = Console.ReadLine();
                    Console.WriteLine("Employee LastName:");
                    string LastName = Console.ReadLine();
                    Console.WriteLine("Employee Gender:");
                    string Gender = Console.ReadLine();
                    Console.WriteLine("Employee Salary:");
                    string Salary = Console.ReadLine();
                    string quary = "insert into [dbo].[Employee] values(@FirstName, @LastName, @Gender ,@Salary)";
                    SqlCommand cmd = new SqlCommand(quary, con);

                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Salary", Salary);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        Console.WriteLine("Data has been inserted Successfully");
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

