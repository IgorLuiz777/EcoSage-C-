using System.ComponentModel.DataAnnotations;
using ECOSAGE.DATA.models.activity;
using ECOSAGE.DATA.models.carbonFootprint;
using static BCrypt.Net.BCrypt;

namespace ECOSAGE.DATA.models;

public class User
{
    public int UserId { get; set; }
    
    public string Name { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public ICollection<Activity> Activities { get; set; }
    
    public ICollection<CarbonFootprint> CarbonFootprints { get; set; }

    public User(string password)
    {
        var hashedPass =  HashPassword(password);
        Password = hashedPass;
    }
}