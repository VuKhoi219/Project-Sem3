using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class User 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Claim> Claims { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<InsurancePlan> InsurancePlans { get; set; }
    public ICollection<InsuranceContract> InsuranceContracts { get; set; }



}

