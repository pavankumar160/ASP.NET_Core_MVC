using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Demo.Models
{
    public class Student
    {
        // Properties represent table columns
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        // Static method to get all students from DB
        public static List<Student> GetAllStudents(string connectionString)
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT Id, Name, Age FROM Students";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(2)
                    });
                }
            }

            return students;
        }
    }
}

