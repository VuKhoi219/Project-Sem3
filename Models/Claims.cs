using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class Claim
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ContractId { get; set; }
    public DateTime ClaimDate { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public string Status { get; set; } // Pending, Approved, Rejected
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    
    public InsuranceContract Contract { get; set; }
}