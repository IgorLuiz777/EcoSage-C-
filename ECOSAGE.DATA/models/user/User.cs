using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECOSAGE.DATA.models.activity;
using ECOSAGE.DATA.models.carbonFootprint;
using static BCrypt.Net.BCrypt;

namespace ECOSAGE.DATA.models;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Password { get; set; }

    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    public ICollection<CarbonFootprint> CarbonFootprints { get; set; } = new List<CarbonFootprint>();
}
