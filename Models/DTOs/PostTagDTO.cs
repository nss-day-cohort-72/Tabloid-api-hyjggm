namespace Tabloid.Models.DTOs;


public class PostTagDTO
{
    public int Id  { get; set; }
    public int PostId  { get; set; }
    public PostDTO Post { get; set; }
    public int TagId  { get; set; }
    public TagDTO Tag { get; set; }

}