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

    [Required]
    public decimal Premium { get; set; }

    [Required]
    public decimal CoverageAmount { get; set; }

    [Required]
    public decimal Deductible { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required, MaxLength(50)]
    public string AgeGroup { get; set; }

    public decimal RiskFactor { get; set; }

    [Required, MaxLength(100)]
    public string Region { get; set; }

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
}
