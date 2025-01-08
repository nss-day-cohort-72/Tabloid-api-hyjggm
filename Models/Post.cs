using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models;

public class Post 
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public UserProfile UserProfile  { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category Category  { get; set; } 
    public string HeaderImg { get; set; }
    public bool ApprovedByAdmin { get; set; }
    public List<Comment> Comments  { get; set; } = new List<Comment>();
    public List<PostTag> PostTags  { get; set; } = new List<PostTag>();
    public List<PostReaction> PostReactions  { get; set; } = new List<PostReaction>();
    public List<PostSubscription> PostSubscriptions {get; set;} = new List<PostSubscription>();


}