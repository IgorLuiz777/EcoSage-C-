using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOSAGE.DATA.models.activity.dto
{
    public class TransportActivityRequestDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal KilometersTravelled { get; set; }
    }
}
