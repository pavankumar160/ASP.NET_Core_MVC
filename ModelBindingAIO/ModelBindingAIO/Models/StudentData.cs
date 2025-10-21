namespace ModelBindingAIO.Models
{
    public class StudentData
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class DepartmentData
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class sdData
    {
        public StudentData? sd { get; set; }
        public DepartmentData? dd {  get; set; }
    }
}
