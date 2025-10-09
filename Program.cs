using Day08Lab_Code_Firrst.Models.BusinessModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Cấu hình MVC
builder.Services.AddControllersWithViews();

// Kết nối đến SQL Server
builder.Services.AddDbContext<BookManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreString")));

var app = builder.Build();

// Cấu hình pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Cấu hình route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
