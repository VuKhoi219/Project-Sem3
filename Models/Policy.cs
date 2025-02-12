namespace Project_Sem3.Models;

public class Policy
{
    public int Id { get; set; }
    public int PlanId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public InsurancePlan Plan { get; set; }
}