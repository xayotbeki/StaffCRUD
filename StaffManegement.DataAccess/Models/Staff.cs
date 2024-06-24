using System.ComponentModel.DataAnnotations;

namespace StaffManagement.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage = "email to'g'ri kiriting!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Department")]
        public Departmenst? Department { get; set; }

        public string PhotoFilePath { get; set; }
    }
}
