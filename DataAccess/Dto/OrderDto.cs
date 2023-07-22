using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class OrderDto
    {
        [Key]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderTime { get; set; }

        [Range(0, 3)]
        //Unpaid, Pending, Paid
        public int Status { get; set; }
    }
}
