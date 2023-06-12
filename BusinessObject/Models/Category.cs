using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } // unique ID
        public string Name { get; set; }    // category name
        public string Desc { get; set; }    // category description
        public virtual ICollection<Game> Games { get; set; }
    }
}
