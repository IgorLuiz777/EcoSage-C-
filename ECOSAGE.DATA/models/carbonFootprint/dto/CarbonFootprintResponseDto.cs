using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOSAGE.DATA.models.carbonFootprint.dto
{
    public class CarbonFootprintResponseDto
    {
        public int CarbonFootprintId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal TotalEmission { get; set; }
        public List<ActivityResponseDto> Activities { get; set; } = new List<ActivityResponseDto>();
    }

    public class ActivityResponseDto
    {
        public int ActivityId { get; set; }
        public string Name { get; set; }
        public decimal Emission { get; set; }
    }
}
