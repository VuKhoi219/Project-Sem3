using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class Role 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<UserRole> UserRoles { get; set; }
}