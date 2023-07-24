using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class OrderDetailDto
    {

        public int OrderId
        {
            get; set;
        }

        public virtual DisplayGameDto Game
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
        public List<GameKeyDto> Keys
        {
            get; set;
        }
    }
}
