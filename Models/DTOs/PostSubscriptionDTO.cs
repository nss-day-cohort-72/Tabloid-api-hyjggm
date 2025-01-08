namespace Tabloid.Models.DTOs;

public class PostSubscriptionDTO
{
    public int Id  { get; set; }
    public int UserProfileId  { get; set; }
    public UserProfileDTO UserProfile { get; set; }
    public int PostId  { get; set; }
    public PostDTO Post { get; set; }
    public DateTime DateSubscribed  { get; set; }
}