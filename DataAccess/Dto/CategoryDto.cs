using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; } // unique ID
        public string Name { get; set; }    // category name
        public string Desc { get; set; }    // category description
    }
}
