using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessObject.Models
{
    public class Order
    {

        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime OrderTime { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [Range(0,3)]
        //Unpaid, Pending, Paid
        public int Status { get; set; }

    }
}
