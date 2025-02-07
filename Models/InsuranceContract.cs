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

    [Required]
    public int PlanId { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Required]
    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    [Required]
    public ContractStatus Status { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Premium { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Thiết lập quan hệ với User và Plan
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("PlanId")]
    public virtual InsurancePlan Plan { get; set; }
}

// Enum cho trạng thái hợp đồng bảo hiểm
public enum ContractStatus
{
    Active,
    Expired,
    Pending,
    Cancelled
}
