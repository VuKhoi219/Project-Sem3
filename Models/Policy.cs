namespace Project_Sem3.Models;

public class Policy
{
    public int Id { get; set; }
    public int PlanId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Liên kết với InsurancePlan
    public InsurancePlan Plan { get; set; } = null!;
}