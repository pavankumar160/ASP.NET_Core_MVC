namespace NavigationalProps.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string? DeptName { get; set; }

        // Navigational Property
        public List<Student>? students { get; set; } = new List<Student>();

    }
}
