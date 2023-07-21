using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class UserDto:BaseDto
    {
        public string Id { get; set; } = null!;
        public string? FullName { get; set; } = null!;
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; }
        private string avatar;
        public string Avatar
        {
            get
            {
                return avatar;
            }
            set
            {
                avatar = value;
                OnPropertyChanged("Avatar");
            }
        }
        public DateTime? JoinDate { get; set; }
        public string? Address { get; set; }

    }
}
