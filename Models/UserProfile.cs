using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Models;
public class UserProfile
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [NotMapped]
    public string UserName { get; set; }

    [NotMapped]
    public string Email { get; set; }

    public DateTime CreateDateTime { get; set; }

    [DataType(DataType.Url)]
    [MaxLength(255)]
    public string ImageLocation { get; set; }

    [NotMapped]
    public List<string> Roles { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }

    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }
    public bool IsDeactivated {get ; set;} // New property to track deactivation

    public List<Post> Posts {get; set;} = new List<Post>();
    public List<PostSubscription> PostSubscriptions {get; set;} = new List<PostSubscription>();
}