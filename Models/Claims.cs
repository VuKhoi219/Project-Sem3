using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class Claim
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public int ContractId { get; set; }
    public InsuranceContract Contract { get; set; }

    [Required]
    public decimal ClaimAmount { get; set; }

    [Required]
    public string ClaimStatus { get; set; } = "Pending"; // Pending, Approved, Rejected

    public DateTime ClaimDate { get; set; } = DateTime.UtcNow;
}