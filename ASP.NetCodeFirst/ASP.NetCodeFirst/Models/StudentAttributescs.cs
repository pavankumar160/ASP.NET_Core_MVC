using System.ComponentModel.DataAnnotations;

namespace ASP.NetCodeFirst.Models
{
    public class StudentDetails
    {
        [Key]  // Primary Key
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        [MaxLength(100)]
        public string Department { get; set; }
    }
}
