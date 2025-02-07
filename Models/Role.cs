using Microsoft.AspNetCore.Identity;

namespace Project_Sem3.Models;

public class Role : IdentityRole
{
    public int Id { get; set; }
    public string Destination { get; set; }
}