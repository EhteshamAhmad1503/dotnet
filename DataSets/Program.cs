using NLog.Internal;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataSets
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("Select* from Employee", con);
            DataSet dsa = new DataSet();
            da.Fill(dsa);

            foreach (DataRow row in dsa.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", row[0], row[1], row[2], row[3], row[4]);
            }
            Console.ReadLine();
        }
    }
}
