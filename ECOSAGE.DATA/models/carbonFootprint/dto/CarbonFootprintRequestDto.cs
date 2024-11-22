using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOSAGE.DATA.models.carbonFootprint.dto
{
    public class CarbonFootprintRequestDto
    {
        public int UserId { get; set; }
        public List<int> ActivityIds { get; set; } = new List<int>();
    }
}
