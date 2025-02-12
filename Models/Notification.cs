using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class Notification
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; } = false;
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
}