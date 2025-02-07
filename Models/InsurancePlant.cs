using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class InsurancePlan
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PartnerId { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    public InsuranceType Type { get; set; }

    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Required]
    public int Duration { get; set; } // Thời gian hiệu lực (tháng)

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Thiết lập quan hệ với Partner
    [ForeignKey("PartnerId")]
    public virtual Partner Partner { get; set; }
}

// Enum cho loại bảo hiểm
public enum InsuranceType
{
    Life,
    Medical,
    Motor,
    Home
}