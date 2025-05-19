using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trelite.Data.Models;
[Table("Roles",Schema ="Lookup")]
public class Role
{
    public short RoleId { get; set; }
    public required string Name { get; set; }
    public bool? Active { get; set; }
    [Required]
    public DateTime Dc { get; set; }
    public DateTime? Dd { get; set; }
    [Required]
    public DateTime Lu { get; set; }
    public ICollection<User> Users { get; set; } = new List<User>();
}
