using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Sem3.Models;

public class Notification
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public string Message { get; set; }

    [Required]
    public string Status { get; set; } = "Unread"; // Unread, Read

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}