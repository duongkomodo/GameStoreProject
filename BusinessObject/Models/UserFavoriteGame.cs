using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class UserFavoriteGame
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        
        public string UserId { get; set; }


        [ForeignKey("GameId")]
        public Game Game { get; set; }
  
        public int GameId { get; set; }
    }
}
