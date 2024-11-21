using ECOSAGE.DATA.models.carbonFootprint;

namespace ECOSAGE.DATA.models.activity;

// TODO: CALCULAR EMISSÃO
public class Activity
{
    public int ActivityId { get; set; }
    
    public User User { get; set; }
    
    public int UserId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public string Category { get; set; }
    
    public decimal Emission { get; set; }
    
    public int CarbonFootprintId { get; set; }
    public CarbonFootprint CarbonFootprint { get; set; }
}