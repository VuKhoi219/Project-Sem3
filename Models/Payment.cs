using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }

    [Required]
    public int ContractId { get; set; }
    [ForeignKey("ContractId")]
    public InsuranceContract InsuranceContract { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    [Required]
    public PaymentStatus Status { get; set; }

    [MaxLength(255)]
    public string ImageUrl { get; set; }

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

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed
}