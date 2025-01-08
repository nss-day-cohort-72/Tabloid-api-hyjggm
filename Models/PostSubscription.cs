namespace Tabloid.Models;

public class PostSubscription
{
    public int Id  { get; set; }
    public int UserProfileId  { get; set; }
    public UserProfile UserProfile { get; set; } 
    public int PostId  { get; set; }
    public Post Post { get; set; }
    public DateTime DateSubscribed  { get; set; }
}