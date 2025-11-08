using Microsoft.EntityFrameworkCore;
using Day09Lab_Database.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Thêm connection string và DbContext trước khi build
var connectionString = builder.Configuration.GetConnectionString("Day09_QuanLyBanHangConnectionString");

builder.Services.AddDbContext<Day09QuanLyBanHangContext>(options =>
    options.UseSqlServer(connectionString));

// ✅ Thêm MVC
builder.Services.AddControllersWithViews();

// ✅ Bây giờ mới build
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
