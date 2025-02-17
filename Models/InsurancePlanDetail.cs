using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class InsurancePlanDetail
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PlanId { get; set; }
    [ForeignKey("PlanId")]
    public InsurancePlan InsurancePlan { get; set; }

    public int TermYears { get; set; }
        
    [MaxLength(50)]
    public string AgeGroup { get; set; }

    public string Beneficiaries { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Premium { get; set; }

    [Column(TypeName = "decimal(15,2)")]
    public decimal CoverageAmount { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Deductible { get; set; }

    public int Duration { get; set; }

    [Column(TypeName = "decimal(5,2)")]
    public decimal RiskFactor { get; set; }

    [MaxLength(100)]
    public string Region { get; set; }

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
