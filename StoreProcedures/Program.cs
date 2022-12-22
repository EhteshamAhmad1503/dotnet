using System;
using System.Data;
using System.Data.SqlClient;

namespace StoreProcedures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Id");
            int a = int.Parse(Console.ReadLine());
            string sc = "Data Source=CGL-081;initial Catalog=EmployeeDB;integrated Security=true;";
            SqlConnection con = new SqlConnection(sc);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("GetEmployee", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;//store procedure calling
            da.SelectCommand.Parameters.AddWithValue("@ID", a); //for user input
            DataSet dt = new DataSet();
            da.Fill(dt);

            foreach (DataRow row in dt.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", row["ID"], row["FirstName"], row["LastName"], row["Gender"], row["Salary"]);
            }
            Console.ReadLine();
        }
    }
}
