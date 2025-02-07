using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class Payment
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ContractId { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }

    [Required]
    public PaymentMethod PaymentMethod { get; set; }

    [Required]
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    [Required]
    public PaymentStatus Status { get; set; }

    // Khai báo quan hệ với User và Contract
    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("ContractId")]
    public virtual InsuranceContract Contract { get; set; }
}

// Enum cho phương thức thanh toán
public enum PaymentMethod
{
    CreditCard,
    BankTransfer,
    Momo,
    PayPal
}

// Enum cho trạng thái thanh toán
public enum PaymentStatus
{
    Success,
    Failed,
    Pending
}