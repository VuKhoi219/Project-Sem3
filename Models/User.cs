using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; }

    [Required, MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    [Required, MaxLength(255)]
    public string Password { get; set; }

    [Required, MaxLength(10)]
    public string Phone { get; set; }

    [Required]
    public Gender  Sex { get; set; } // Enum: Male, Female

    [Required, MaxLength(12)]
    public string CCCD { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [Required]
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    // Quan hệ 1-N

    public ICollection<InsuranceContract> InsuranceContracts { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<BorrowCapital> BorrowCapitals { get; set; }
    public ICollection<Notification> Notifications { get; set; }
    
}

public enum Gender
{
    Male,
    Female
}

