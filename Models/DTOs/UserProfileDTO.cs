namespace Tabloid.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime CreateDateTime { get; set; }
    public string ImageLocation { get; set; }
    public List<string> Roles { get; set; }
    public string IdentityUserId { get; set; }
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
    }

      public List<PostDTO> Posts {get; set;} = new List<PostDTO>();
       public List<PostSubscriptionDTO> PostSubscriptions {get; set;} = new List<PostSubscriptionDTO>();
}