using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessObject.Models
{
    public class User
    {
 
        [Key]
        public int UserId { get; set; }
        public string? FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        [RegularExpression("^\\(?([0-9]{3})\\)?[-.\\s]?([0-9]{3})[-.\\s]?([0-9]{4})$/")]
        public string? PhoneNumber { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
