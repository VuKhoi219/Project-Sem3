using Microsoft.EntityFrameworkCore;
using Project_Sem3.Models;

namespace Project_Sem3.Data;

public class MyDbContext : DbContext
{

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Partner> Partners { get; set; }
    public DbSet<InsurancePlan> InsurancePlans { get; set; }
    public DbSet<InsuranceContract> InsuranceContracts { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Payment> Payments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role) // User có một Role (Navigation Property Role trong User)
            .WithMany()         // Role có thể có nhiều Users (không có Navigation Property ngược lại trong Role - có thể thêm nếu cần)
            .HasForeignKey(u => u.RoleId) // Khóa ngoại là RoleId trong bảng Users
            .OnDelete(DeleteBehavior.Restrict); 

        // Cấu hình ràng buộc khóa ngoại cho Claim -> User với ON DELETE NO ACTION
        modelBuilder.Entity<Claim>()
            .HasOne(c => c.User)
            .WithMany() // Hoặc .WithMany(u => u.Claims) nếu bạn có Navigation Property ngược lại trong User
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction) // Chỉ định ON DELETE NO ACTION
            .IsRequired(); // If UserId is Required as per your model

        // Tương tự cho ON UPDATE NO ACTION (mặc định là NO ACTION, nhưng có thể chỉ định rõ ràng)
        modelBuilder.Entity<Claim>()
            .HasOne(c => c.User)
            .WithMany() // Hoặc .WithMany(u => u.Claims)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction) // Keep ON DELETE NO ACTION
            .IsRequired(); // If UserId is Required as per your model
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.User)
            .WithMany() // Or .WithMany(u => u.Payments) if you have a navigation property in User
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired(); // If UserId is Required in Payment model

        // **Quan trọng:** Kiểm tra và cấu hình tương tự cho các ràng buộc khóa ngoại khác trong DbContext của bạn
        // để đảm bảo không có chu trình cascade hoặc nhiều đường dẫn cascade không mong muốn.
    }

}