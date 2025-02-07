using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Project_Sem3.Models;

public class InsuranceContract
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public int PlanId { get; set; }
    public InsurancePlan Plan { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public string Status { get; set; } = "Active"; // Active, Expired, Cancelled

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Quan hệ
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Claim> Claims { get; set; }
}