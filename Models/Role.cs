using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class Role
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; }

    public DateTime? UpdatedAt { get; set; }

    // Quan hệ 1-N với Users
    public ICollection<User> Users { get; set; }
}
