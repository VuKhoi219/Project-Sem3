using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class InsurancePlan
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; }

    [Required]
    public InsuranceType Type { get; set; }

    [Required]
    public InsuranceStatus Status { get; set; }

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [Required]
    public int CreatedBy { get; set; }
    
    [ForeignKey("CreatedBy")]
    public User CreatedUser { get; set; }

    [Required]
    public int UpdatedBy { get; set; }

    [ForeignKey("UpdatedBy")]
    public User UpdatedUser { get; set; }

    public ICollection<InsurancePlanDetail> PlanDetails { get; set; }
}

public enum InsuranceType
{
    Life,
    Health,
    Auto,
    Property
}

public enum InsuranceStatus
{
    Active,
    Inactive
}
