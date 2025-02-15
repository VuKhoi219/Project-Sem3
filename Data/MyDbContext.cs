using Microsoft.EntityFrameworkCore;
using Project_Sem3.Models;

namespace Project_Sem3.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<InsurancePlan> InsurancePlans { get; set; }
    public DbSet<InsurancePlanDetail> InsurancePlanDetails { get; set; }
    public DbSet<InsuranceContract> InsuranceContracts { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<BorrowCapital> BorrowCapitals { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Thiết lập quan hệ cho User - Role (1:N)
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

        // Thiết lập quan hệ CreatedBy & UpdatedBy cho các bảng
        modelBuilder.Entity<InsurancePlan>()
            .HasOne(p => p.CreatedUser)
            .WithMany()
            .HasForeignKey(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InsurancePlan>()
            .HasOne(p => p.UpdatedUser)
            .WithMany()
            .HasForeignKey(p => p.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InsurancePlanDetail>()
            .HasOne(d => d.CreatedUser)
            .WithMany()
            .HasForeignKey(d => d.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InsurancePlanDetail>()
            .HasOne(d => d.UpdatedUser)
            .WithMany()
            .HasForeignKey(d => d.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InsuranceContract>()
            .HasOne(c => c.CreatedUser)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InsuranceContract>()
            .HasOne(c => c.UpdatedUser)
            .WithMany()
            .HasForeignKey(c => c.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.User)   // Payment có một User
            .WithMany()            // Không cần khai báo nhiều Payment trong User
            .HasForeignKey(p => p.UserId)  
            .OnDelete(DeleteBehavior.Restrict); // Tránh "multiple cascade paths"
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.CreatedUser)
            .WithMany()
            .HasForeignKey(p => p.CreatedBy)
            .OnDelete(DeleteBehavior.NoAction); 
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.UpdatedUser)
            .WithMany()
            .HasForeignKey(p => p.UpdatedBy)
            .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<BorrowCapital>()
            .HasOne(b => b.CreatedUser)
            .WithMany()
            .HasForeignKey(b => b.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BorrowCapital>()
            .HasOne(b => b.UpdatedUser)
            .WithMany()
            .HasForeignKey(b => b.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.CreatedUser)
            .WithMany()
            .HasForeignKey(n => n.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.UpdatedUser)
            .WithMany()
            .HasForeignKey(n => n.UpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}