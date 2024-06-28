namespace FastLearners.API.Users.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [StringLength(20)]
    public string FirstName { get; set; }
    
    [Required]
    [StringLength(20)]
    public string LastName { get; set; }
    
    [Required]
    [StringLength(20)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(20)]
    public string Password { get; set; }
    
    [Required]
    public EMembershipId MembershipId { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public DateTime UpdatedAt { get; set; }
}

public enum EMembershipId
{
    Basic = 1,
    Regular = 2,
    Pro = 3
}

