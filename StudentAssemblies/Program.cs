using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAssemblies
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
       // public string Email { get; set; }
    }
    public class StudentDB
    {
        private readonly string strConnection = @"server=localhost;database=PE01;uid=linhtnl;pwd=123";
        public bool AddNewStudent(Student s)
        {

            string SQL = "insert Students values(@id,@name,@age)";
            int row = 0;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@id",s.StudentID);
                command.Parameters.AddWithValue("@name", s.StudentName);
                command.Parameters.AddWithValue("@age", s.Age);
                //command.Parameters.AddWithValue("@email", s.Email);
                connection.Open();
                row = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return row == 1;
        }
        public bool IsExist(int id)
        {
            string SQL = "Select * from Students Where StudentID = @id";
            bool check = false;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    check = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return check;
        }

        public bool RemoveStudent(int id)
        {
            string SQL = "Delete Students where StudentID=@id";
            int row = 0;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                row = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return row == 1;
        }
        public bool UpdateStudent(Student s)
        {
            string SQL = "UPDATE Students set StudentName=@name,Age=@age where StudentID=@id";
            int row = 0;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@id", s.StudentID);
                command.Parameters.AddWithValue("@name", s.StudentName);
                command.Parameters.AddWithValue("@age", s.Age);
                //command.Parameters.AddWithValue("@email", s.Email);
                connection.Open();
                row = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return row == 1;
        }
        public List<Student> FindStudent(string search)
        {
            string SQL = "Select * from Students Where StudentName like @search";
            List<Student> list = new List<Student>();
            Student s = null;
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@search", "%" + search + "%");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = int.Parse(reader.GetValue(0).ToString());
                    string name = reader.GetValue(1).ToString();
                    int age = int.Parse(reader.GetValue(2).ToString());
                    //string email = reader.GetValue(3).ToString();
                    s = new Student
                    {
                        StudentID= id,
                        StudentName = name,
                        Age = age
                       
                    };
                    list.Add(s);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
        public List<Student> GetStudentList()
        {
            string SQL = "Select * from Students ";
            List<Student> rs = new List<Student>();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(strConnection);
                SqlCommand command = new SqlCommand(SQL, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Student s = null;
                while (reader.Read())
                {
                    int id = int.Parse(reader.GetValue(0).ToString());
                    string name = reader.GetValue(1).ToString();
                    int age = int.Parse(reader.GetValue(2).ToString());
                    //string email = reader.GetValue(3).ToString();
                    s = new Student()
                    {
                        StudentID = id,
                        StudentName = name,
                        Age = age
                       // Email = email
                    };
                    rs.Add(s);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return rs;
        }
    }
}
