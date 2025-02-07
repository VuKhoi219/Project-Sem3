using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class InsurancePlan
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(255)]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public decimal Premium { get; set; } // Phí bảo hiểm hàng tháng

    [Required]
    public decimal CoverageAmount { get; set; } // Số tiền bảo hiểm chi trả

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Quan hệ
    public ICollection<InsuranceContract> InsuranceContracts { get; set; }
}