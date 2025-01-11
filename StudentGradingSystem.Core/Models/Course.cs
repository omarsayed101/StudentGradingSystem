using System.ComponentModel.DataAnnotations;

namespace StudentGradingSystem.Domain.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
