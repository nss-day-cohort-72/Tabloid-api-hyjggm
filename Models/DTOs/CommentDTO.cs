namespace Tabloid.Models.DTOs;

public class CommentDTO
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public PostDTO Post { get; set; } 
    public int UserProfileId { get; set; }
    public UserProfileDTO UserProfile { get; set; }
    public string Text { get; set; }
    public DateTime DateCreated { get; set; }
}