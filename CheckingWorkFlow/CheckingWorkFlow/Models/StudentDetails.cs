using Microsoft.Data.SqlClient;

namespace CheckingWorkFlow.Models
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Department { get; set; }

        public static List<StudentDetails> getStudent(string connectionString, int? Id)
        {
            List<StudentDetails> student = new List<StudentDetails>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //Console.WriteLine(Id);

                if (Id.HasValue)
                {
                    string query = "select* from studentTable t1 where t1.Id = @Id";
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", Id.Value);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student.Add(new StudentDetails
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Department = reader.GetString(3)
                            });
                        }

                    }
                }
            }

            return student;
        }
    }

}