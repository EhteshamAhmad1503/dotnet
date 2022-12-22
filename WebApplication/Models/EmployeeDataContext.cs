using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class EmployeeDataContext
    {

        string sc = ConfigurationManager.ConnectionStrings["Employee"].ConnectionString;
        public List<Student> GetStudents()
        {
            List<Student> studentsList = new List<Student>();
            try
            {
                SqlConnection con = new SqlConnection(sc);
                SqlCommand cmd = new SqlCommand("GetEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Student stu = new Student();
                    stu.ID = Convert.ToInt32(dr.GetValue(0));
                    stu.FirstName = dr.GetValue(1).ToString();
                    stu.LastName = dr.GetValue(2).ToString();
                    stu.Gender = dr.GetValue(3).ToString();
                    stu.Salary = Convert.ToInt32(dr.GetValue(4));
                    studentsList.Add(stu);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return studentsList;
        }
        public bool AddStudent(Student std)
        {
            SqlConnection con = new SqlConnection(sc);
            SqlCommand cmd = new SqlCommand("AddEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", std.FirstName);
            cmd.Parameters.AddWithValue("@LastName", std.LastName);
            cmd.Parameters.AddWithValue("@Gender", std.Gender);
            cmd.Parameters.AddWithValue("@Salary", std.Salary);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateStudent(Student std)
        {
            SqlConnection con = new SqlConnection(sc);
            SqlCommand cmd = new SqlCommand("UpdateEmployees", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", std.ID);
            cmd.Parameters.AddWithValue("@FirstName", std.FirstName);
            cmd.Parameters.AddWithValue("@LastName", std.LastName);
            cmd.Parameters.AddWithValue("@Gender", std.Gender);
            cmd.Parameters.AddWithValue("@Salary", std.Salary);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteStudent(int id)
        {
            SqlConnection con = new SqlConnection(sc);
            SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}