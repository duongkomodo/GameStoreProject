using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class Game
    {
        public Game()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } // description
        public string? TechReq { get; set; } // technical requirements
        public string? Image { get; set; }
        public bool IsAvailable { get; set; } = false;
        public int Quantity { get; set; }
        public ushort Price { get; set; }
        public virtual ICollection<GameKey> Keys { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }  // category the game belongs to
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
