using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class Claim
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ContractId { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ClaimAmount { get; set; }

    public string Description { get; set; }

    [Required]
    public ClaimStatus Status { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Thiết lập quan hệ với User và InsuranceContract
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("ContractId")]
    public virtual InsuranceContract Contract { get; set; }
}

// Enum cho trạng thái yêu cầu bồi thường
public enum ClaimStatus
{
    Pending,
    Approved,
    Rejected
}