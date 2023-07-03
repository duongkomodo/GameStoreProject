using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class DisplayGameDto
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } // description
        public string? TechReq { get; set; } // technical requirements
        public string? Image { get; set; }
        public bool IsAvailable { get; set; } = false;
        public int Quantity { get; set; }
        public string Discount { get; set; }
        public string Price { get; set; }
        public string SalePrice { get; set; }
        public int? CategoryId { get; set; }
        public virtual CategoryDto? Category { get; set; }  // category the game belongs to
    }
}
