using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class InsurancePlan
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; } // Life, Medical, Motor, Home
    public string Description { get; set; }
    public decimal CoverageAmount { get; set; } // Số tiền bảo hiểm
    public int Premium  { get; set; } // Thời gian bảo hiểm (tháng/năm)
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<InsuranceContract> InsuranceContracts { get; set; }

}