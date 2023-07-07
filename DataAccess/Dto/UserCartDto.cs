using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class UserCartDto
    {
        public User User { get; set; }
        public string UserId { get; set; }
        public int GameId
        {
            get; set;
        }
        public virtual Game Game
        {
            get; set;
        }
        public float Price
        {
            get; set;
        }
        public int Quantity
        {
            get; set;
        }


    }
}
