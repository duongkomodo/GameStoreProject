using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto
{
    public class BaseOutputDto
    {
        public BaseOutputDto()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
        public string Status { get; set; }
    }
}
