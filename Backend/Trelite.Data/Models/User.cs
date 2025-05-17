using System;
using System.ComponentModel.DataAnnotations;

namespace Trelite.Data.Models;

public class User
{
    [Key]
    [Required]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public short? UserId { get; set; }
    [Required(ErrorMessage ="Please enter a user name")]
    public required string UserName { get; set; }
    [Required(ErrorMessage ="Please enter a email")]
    public required string Email { get; set; }
    [Required(ErrorMessage ="Please enter a password")]
    public required string PasswordHash { get; set; }
    [Required]
    public short RV { get; set; }
    [Required]
    public bool IsAdmin { get; set; }
    public bool? Active { get; set; }
    [Required]
    public DateTime Dc { get; set; }
    public DateTime? Dd { get; set; }
    [Required]
    public DateTime Lu { get; set; } 
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
