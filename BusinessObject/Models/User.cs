using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessObject.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;

        [Phone]
        public string? PhoneNumber { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string? Address { get; set; }
        public DateTime? JoinDate { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
        public virtual UserCart UserCart { get; set; }
        public virtual ICollection<UserFavoriteGame> FavoriteGames { get; set; }


    }
}
