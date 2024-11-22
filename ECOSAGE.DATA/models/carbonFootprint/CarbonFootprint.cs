using ECOSAGE.DATA.models.activity;

namespace ECOSAGE.DATA.models.carbonFootprint;

public class CarbonFootprint
{
    public int CarbonFootprintId { get; set; }
    
    public User User { get; set; }
    
    public int UserId { get; set; }

    public DateTime TimeStamp { get; set; }

    public List<Activity> Activities { get; set; } = new List<Activity>();

    public decimal TotalEmission { get; set; }

    public CarbonFootprint()
    {
        TimeStamp = DateTime.Now;
    }
}