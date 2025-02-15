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
    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    [Required]
    public PaymentStatus Status { get; set; }

    public string ImageUrl { get; set; }
    [Required]
    public int CreatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    public User? CreatedUser { get; set; }

    [Required]
    public int UpdatedBy { get; set; }

    [ForeignKey("UpdatedBy")]
    public User UpdatedUser { get; set; }
}

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed
}
