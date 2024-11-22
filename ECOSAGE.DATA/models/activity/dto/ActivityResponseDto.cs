using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOSAGE.DATA.models.activity.dto
{
    public class ActivityResponseDto
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Emission { get; set; }
        public int? CarbonFootprintId { get; set; }
    }
}
