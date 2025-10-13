using System.ComponentModel.DataAnnotations;

namespace Client_SideValidation.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }
    }
}
