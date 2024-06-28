using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FastLearners.API.Organizations.Domain.Models;

public class Organization
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required] [StringLength(20)] public string Name { get; set; }
    [Required] [StringLength(20)] public string Description { get; set; }
    [Required] [StringLength(20)] public string TopicName { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public DateTime UpdatedAt { get; set; }
    
}