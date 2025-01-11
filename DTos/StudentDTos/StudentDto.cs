using System.ComponentModel.DataAnnotations;

namespace DTos.StudentDto
{
    public class StudentDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateOnly DateofBirth { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
