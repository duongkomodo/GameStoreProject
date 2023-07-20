using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class OrderDetail
    {
        public int OrderId
        {
            get; set;
        }
        public int GameId
        {
            get; set;
        }

        [ForeignKey("OrderId")]
        public virtual Order Order
        {
            get; set;
        }
        [ForeignKey("GameId")]
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
