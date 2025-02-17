using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string FullName { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MaxLength(255)]
    public string Password { get; set; }

    [Required]
    [MaxLength(10)]
    public string Phone { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    [MaxLength(12)]
    public string CitizenIdentificationCard { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    public UserStatus Status { get; set; } = UserStatus.Inactive;

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

    [Required]
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role Role { get; set; }
}

public enum Gender
{
    Male,
    Female
}

public enum UserStatus
{
    Inactive = 0,
    Active = 1,
    Banned = -1
}
