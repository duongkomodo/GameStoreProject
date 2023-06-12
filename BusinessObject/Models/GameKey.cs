using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class GameKey
    {
        [Key]
        public string Code { get; set; }

        [Key]
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }
        public DateTime? ExpirationDate { get; set; }

    }
}
