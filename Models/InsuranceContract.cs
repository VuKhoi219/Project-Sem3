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
    [ForeignKey("UserId")]
    public User User { get; set; }

    [Required]
    public int PlanId { get; set; }

    [ForeignKey("PlanId")]
    public InsurancePlan InsurancePlan { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public ContractStatus Status { get; set; }
    
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
}

public enum ContractStatus
{
    Pending,
    Active,
    Expired,
    Cancelled
}
