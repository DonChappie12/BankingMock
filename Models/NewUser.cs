using System.ComponentModel.DataAnnotations;

namespace banking.Models
{
    public class NewUser
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

        [Required(ErrorMessage="Must provide a Password")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*)(?=.*[$@$!%*#?&])[A-Za-z$@$!%*#?&].*$", ErrorMessage="Password must have at least one letter, number and special character")]
        public string Password { get ; set; }
        
        [Required(ErrorMessage="Must confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Passwords must match")]
        public string ConfirmPassword { get ; set; }
    }
}