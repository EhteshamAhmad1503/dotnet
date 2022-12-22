using System;
using System.Data;
using System.Data.SqlClient;

namespace Properties
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
            string cs = "Data Source =CGL-081 ;initial Catalog=Infromation;integrated Security=true;";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("SELECT * FROM introduction;Select * from introduction2 ", con);
            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                // Console.WriteLine(dr.GetName(0));
                //  Console.WriteLine(dr.FieldCount);
                //  Console.WriteLine(dr.HasRows);

                while (dr.Read())
                {
                    Console.WriteLine("Id :{0} = Name:{1} = Course:{2} = Collage:{3} = Gender:{4} =City{5} ", dr["Id"], dr["Name"], dr["Course"], dr["Collage"], dr["Gender"], dr["City"]);
                }
                Console.WriteLine("---------------------------------------------------------------------");

                if (dr.NextResult())// it's use for more than one quary
                {
                    while (dr.Read())
                    {
                        Console.WriteLine("ID : {0} : Gender : {1} ", dr["id"], dr["Gender"]);
                    }
                }

            }

            con.Close();
            Console.ReadLine();
        }
    }
}

