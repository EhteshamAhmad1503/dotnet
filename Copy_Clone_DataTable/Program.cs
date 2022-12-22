using System;
using System.Data;
using System.Data.SqlClient;

namespace Copy_Clone_DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string cs = "Data Source=CGL-081;initial catalog=EmployeeDB;integrated Security=true;";
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter da = new SqlDataAdapter("Select*from Employee", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Console.WriteLine("Original Data Table");
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["ID"] + " " + row["FirstName"] + " " + row["LastName"] + " " + row["Gender"] + " " + row["Salary"]);
                }

                DataTable data = dt.Copy();
                Console.WriteLine("----------------Copy Data Table--------------");
                foreach (DataRow row in data.Rows)
                {
                    Console.WriteLine(row["ID"] + " " + row["FirstName"] + " " + row["LastName"] + " " + row["Gender"] + " " + row["Salary"]);
                }

                DataTable dataTable = dt.Clone();
                Console.WriteLine("--------Clone Data---------");
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(row["ID"] + " " + row["FirstName"] + " " + row["LastName"] + " " + row["Gender"] + " " + row["Salary"]);
                    }
                }
                else
                {
                    // Console.WriteLine("Rows not found");
                    dataTable.Rows.Add(1, "Ehtesham", "Ahmad", "Male", 15000);
                    dataTable.Rows.Add(2, "Altaf", "Ahmad", "Male", 15000);
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["ID"] + " " + row["FirstName"] + " " + row["LastName"] + " " + row["Gender"] + " " + row["Salary"]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
