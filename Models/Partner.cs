using System.ComponentModel.DataAnnotations;

namespace Project_Sem3.Models;

public class Partner 
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Required]
    [StringLength(255)]
    [EmailAddress]
    public string Email { get; set; }

    [StringLength(20)]
    public string Phone { get; set; }

    [Required]
    [StringLength(255)]
    public string CompanyName { get; set; }

    public string Address { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}