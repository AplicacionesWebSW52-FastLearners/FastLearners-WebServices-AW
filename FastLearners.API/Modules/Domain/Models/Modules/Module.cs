using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FastLearners.API.Organizations.Domain.Models;

namespace FastLearners.API.Modules.Domain.Models.Modules;

public class Module
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required] [StringLength(20)] public string Name { get; set; }
    [Required] [StringLength(20)] public string Description { get; set; }
    [Required]  public int Content { get; set; }
    
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public DateTime UpdatedAt { get; set; }
}