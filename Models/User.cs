using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class User 
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; }

    [Required, EmailAddress, MaxLength(255)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    public string Address { get; set; }

    public string CompanyName { get; set; }  // Nếu là đối tác

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Quan hệ
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<InsuranceContract> InsuranceContracts { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Claim> Claims { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}

