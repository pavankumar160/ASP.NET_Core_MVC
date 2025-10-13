namespace NavigationalProps.Models
{
    public class Student
    {
        public int SId { get; set; }
        public string? Name { get; set; }


        // Each student belongs to one department
        public Department? Department { get; set; }   //  Navigational property

    }
}
