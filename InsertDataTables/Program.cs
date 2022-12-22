using System;
using System.Data;

namespace InsertDataTables
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataTable Employees = new DataTable("Employee");
                DataColumn id = new DataColumn("Id");
                id.Caption = "Emp_Id";
                id.DataType = typeof(int);
                id.AllowDBNull = false;
                id.AutoIncrement = true;
                id.AutoIncrementSeed = 0;
                id.AutoIncrementStep = 1;
                Employees.Columns.Add(id);

                DataColumn name = new DataColumn("Name");
                name.Caption = "Name";
                name.DataType = typeof(string);
                name.AllowDBNull = false;
                name.MaxLength = 50;
                name.DefaultValue = "Anonymous";
                name.Unique = true;
                Employees.Columns.Add(name);

                DataColumn gender = new DataColumn("Gender");
                gender.Caption = "Gender";
                gender.DataType = typeof(string);
                gender.AllowDBNull = false;
                gender.MaxLength = 15;
                Employees.Columns.Add(gender);

                DataRow row = Employees.NewRow();
                Employees.Rows.Add(null, "Ehtesham", "Male");
                Employees.Rows.Add(null, "Sarwar", "Male");
                Employees.Rows.Add(null, "Irfan", "Male");
                Employees.Rows.Add(null, "Gulam", "Male");

                //Employees.PrimaryKey = new DataColumn[] { id };
                foreach (DataRow data in Employees.Rows)
                {
                    Console.WriteLine(data["Id"] + " " + data["Name"] + " " + data["Gender"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
