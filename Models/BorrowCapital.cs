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
    public decimal LoanAmount { get; set; }

    [Required, MaxLength(10)]
    public string Currency { get; set; } = "VND";

    [Required]
    public decimal InterestRate { get; set; }

    public string LoanPurpose { get; set; }

    public DateTime? LoanDate { get; set; }

    [Required]
    public decimal RepaymentAmount { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    public PaymentSchedule PaymentSchedule { get; set; }
    [Required]
    public int CreatedBy { get; set; }

    [ForeignKey("CreatedBy")]
    public User CreatedUser { get; set; }

    [Required]
    public int UpdatedBy { get; set; }

    [ForeignKey("UpdatedBy")]
    public User UpdatedUser { get; set; }
}

public enum PaymentSchedule
{
    Monthly,
    Quarterly,
    Yearly
}
