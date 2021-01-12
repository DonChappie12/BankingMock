using System.ComponentModel.DataAnnotations;

namespace banking.Models
{
    public class EditUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public string DateOfBirth { get; set; }
        
        [Required(ErrorMessage="Must provide Email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get ; set; }
    }
}