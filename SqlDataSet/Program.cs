using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                string cs = "Data Source=CGL-081;initial catalog=TRAINEE_MANAGEMENT;integrated Security=true;";
                SqlConnection con = new SqlConnection(cs);
                SqlDataAdapter sda = new SqlDataAdapter("GetStudent", con);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet dt = new DataSet();
                sda.Fill(dt);

                foreach (DataRow row in dt.Tables[0].Rows)
                {
                    Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
                }

                Console.WriteLine("--------------------------------------------------");
                foreach (DataRow row in dt.Tables[1].Rows)
                {
                    Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3] + " " + row[4] + " " + row[5]);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
