using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class SignUpInputDto
    {
        [Required]
        public string FirstName { get; set;  } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Phone]
        public string? PhoneNumber { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }

    public class SignUpOutputDto
    {

        public string Result { get; set; } = null!;

        public List<string> PasswordValidates { get; set; } = new List<string>();
    }
}
