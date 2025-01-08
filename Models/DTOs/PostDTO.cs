namespace Tabloid.Models.DTOs;

public class PostDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateCreated { get; set; }
    public int UserProfileId { get; set; }
    public UserProfileDTO UserProfile  { get; set; }
    public int CategoryId { get; set; }
    public CategoryDTO Category  { get; set; } 
    public string HeaderImg { get; set; }
    public bool ApprovedByAdmin { get; set; }
    public List<CommentDTO> Comments  { get; set; } = new List<CommentDTO>();
    public List<PostTagDTO> PostTags  { get; set; } = new List<PostTagDTO>();
    public List<PostReactionDTO> PostReactions  { get; set; } = new List<PostReactionDTO>();
    public List<PostSubscriptionDTO> postSubscriptions  { get; set; } = new List<PostSubscriptionDTO>(); 

}