using Microsoft.Data.SqlClient;

namespace ASP.NetGetRequestDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }

        public static List<Student> getAllStudents(string connectionString)
        {
            List<Student> students = new List<Student> ();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query1 = "select* from students";
                conn.Open();

                Console.WriteLine("Connection Established Successfully");

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                SqlDataReader reader = cmd1.ExecuteReader();

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

        public static List<Student> getStudent(string connectionString)
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query1 = "select* from students where Id = 1";
                conn.Open();

                Console.WriteLine("Connection Established Successfully");

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                SqlDataReader reader = cmd1.ExecuteReader();

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
