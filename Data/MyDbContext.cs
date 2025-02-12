using Microsoft.EntityFrameworkCore;
using Project_Sem3.Models;

namespace Project_Sem3.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<InsurancePlan> InsurancePlans { get; set; }
    public DbSet<Policy> Policies { get; set; }
    public DbSet<InsuranceContract> InsuranceContracts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Thiết lập quan hệ nhiều - nhiều giữa User và Role
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // Các quan hệ khác
        modelBuilder.Entity<InsuranceContract>()
            .HasOne(ic => ic.User)
            .WithMany(u => u.InsuranceContracts)
            .HasForeignKey(ic => ic.UserId);

        modelBuilder.Entity<InsuranceContract>()
            .HasOne(ic => ic.Plan)
            .WithMany(p => p.InsuranceContracts)
            .HasForeignKey(ic => ic.PlanId);

        // Mối quan hệ giữa User và Payments
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.User)
            .WithMany(u => u.Payments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Contract)
            .WithMany(ic => ic.Payments)
            .HasForeignKey(p => p.ContractId);

        // Mối quan hệ giữa User và Claims
        modelBuilder.Entity<Claim>()
            .HasOne(c => c.User)
            .WithMany(u => u.Claims)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Claim>()
            .HasOne(c => c.Contract)
            .WithMany(ic => ic.Claims)
            .HasForeignKey(c => c.ContractId);
    }
}