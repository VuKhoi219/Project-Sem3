using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class Role
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    [Required]
    public int CreatedBy { get; set; }
    [ForeignKey("CreatedBy")]
    public User CreatedUser { get; set; }

    [Required]
    public int UpdatedBy { get; set; }
    [ForeignKey("UpdatedBy")]
    public User UpdatedUser { get; set; }

    [Required]
    public int DeletedBy { get; set; }
    [ForeignKey("DeletedBy")]
    public User DeletedUser { get; set; }
}