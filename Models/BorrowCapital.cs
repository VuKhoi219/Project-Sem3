using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class BorrowCapital
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal LoanAmount { get; set; }

    [MaxLength(10)]
    public string Currency { get; set; } = "VND";  // Default is VND

    [Required]
    [Column(TypeName = "decimal(5,2)")]
    public decimal InterestRate { get; set; }

    [MaxLength(255)]
    public string LoanPurpose { get; set; }

    public DateTime LoanDate { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal RepaymentAmount { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public PaymentSchedule PaymentSchedule { get; set; }

    [MaxLength(100)]
    public string BankTransactionId { get; set; }

    public BankStatus BankStatus { get; set; }

    public CapitalStatus Status { get; set; }

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

public enum PaymentSchedule
{
    Monthly,
    Quarterly,
    Yearly
}

public enum BankStatus
{
    Pending,
    Approved,
    Rejected,
    Processing
}

public enum CapitalStatus
{
    Pending,
    Active,
    Overdue,
    Closed
}