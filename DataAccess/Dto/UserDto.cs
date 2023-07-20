using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class UserDto
    {
        public string? FullName { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        [Phone]
        public string? PhoneNumber { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? Address { get; set; }

    }
}
