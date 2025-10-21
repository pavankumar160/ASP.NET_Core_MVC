using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class StudentData
    {
        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string? Name { get; set; }
    }
}
