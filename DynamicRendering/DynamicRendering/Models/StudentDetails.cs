namespace DynamicRendering.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Department { get; set; }

        public static List<Student> getStudents()
        {
            List<Student> studentDetails = new List<Student>();

            studentDetails.AddRange( new List<Student>
            {
                new Student { Id = 1, Name = "Pavan", Age = 22, Department = "DS" },
                new Student { Id = 2, Name = "Vishnu", Age = 23, Department = "Civil"},
                new Student {Id = 3, Name = "Pooja", Age = 21, Department = "AIML"}
            });

            return studentDetails;
        }

    }
}
