using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Project_Sem3.Models;

public class InsuranceContract
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } // Active, Expired, Cancelled
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public InsurancePlan Plan { get; set; }
    // Mối quan hệ với Payments
    public ICollection<Payment> Payments { get; set; }

    // Mối quan hệ với Claims
    public ICollection<Claim> Claims { get; set; }
}