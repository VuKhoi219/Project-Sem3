using System.Collections.Immutable;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Project_Sem3.Data;
using Project_Sem3.Helper;

// using Project_Sem3.Repository;
// using Project_Sem3.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbContext>(options => // Program.cs
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

Env.Load();  // Đảm bảo rằng file .env đã được tải
// Thêm dịch vụ vào container DI (Dependency Injection)
builder.Services.AddSingleton<EmailSettings>(options =>
{
    return new EmailSettings
    {
        Host = Environment.GetEnvironmentVariable("HOST"),
        Port = int.Parse(Environment.GetEnvironmentVariable("PORT")),
        UserName = Environment.GetEnvironmentVariable("USERNAME"),
        Password = Environment.GetEnvironmentVariable("PASSWORD"),
        FromEmail = Environment.GetEnvironmentVariable("FROM_EMAIL"),  // Sử dụng FROM_EMAIL từ môi trường
        FromName = Environment.GetEnvironmentVariable("FROM_NAME"),
        EnableSsl = bool.Parse(Environment.GetEnvironmentVariable("ENABLE_SSL"))
    };
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipelin
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

