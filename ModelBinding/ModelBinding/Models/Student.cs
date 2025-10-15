namespace ModelBinding.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class Student_Department
    {
        public Student? student {  get; set; }
        public Department? department { get; set; }
    }
}
