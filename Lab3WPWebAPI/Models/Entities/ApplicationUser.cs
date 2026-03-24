using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab3WPWebAPI.Models.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Profile { get; set; } = String.Empty;
    [NotMapped] // does not store into database
    public ICollection<string> Roles { get; set; } = new List<string>();

    public bool HasRole(string rolename) 
    {
        // if (rolename == null) 
        // {
        //     return false;
        // }
        return Roles.Contains(rolename);
    }


}

