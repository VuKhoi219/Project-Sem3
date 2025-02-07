using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class User 
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Phone]
    public string Phone { get; set; }
    
    [Required]
    public int RoleId { get; set; }
    public Role Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}