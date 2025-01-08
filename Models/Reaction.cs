using System.ComponentModel.DataAnnotations;

namespace Tabloid.Models;

public class Reaction
{
    public int Id  { get; set; }
    [Required]
    public string Text  { get; set; }
    [Required]
    public string Icon  { get; set; }

}