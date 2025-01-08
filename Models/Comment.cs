using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models;

public class Comment
{
    public int Id { get; set; }
    [Required]
    public int PostId { get; set; }
    public Post Post { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    [Required]
    public string Text { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
}