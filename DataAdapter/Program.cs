using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "Data Source=CGL-081 ;initial Catalog=EmployeeDB;integrated Security=true;";
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("Select*from Employee", con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0}  {1} {2} {3} {4} ", row["ID"], row["FirstName"], row["LastName"], row["Gender"], row["Salary"]);
            }

            Console.ReadLine();
        }
    }
}
