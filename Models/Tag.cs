using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models;

public class Tag 
{
    public int Id  { get; set; }
    [Required]
    public string Text  { get; set; }
}