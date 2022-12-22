using System;
using System.Data.SqlClient;
using System.Data;

namespace DataTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source=CGL-081 ;initial Catalog=EmployeeDB;integrated Security=true;";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("Select*from Employee", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0}  {1} {2} {3} {4} ", row["ID"], row["FirstName"], row["LastName"], row["Gender"], row["Salary"]);
            }

            Console.ReadLine();
        }
    }
}
