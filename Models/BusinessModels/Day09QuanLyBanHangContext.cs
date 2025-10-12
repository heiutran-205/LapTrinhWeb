using Microsoft.EntityFrameworkCore;
using Day09_CodeFirst.Models.DataModels;

namespace Day09_CodeFirst.Models.BusinessModels
{
    public class Day09QuanLyBanHangContext : DbContext
    {
        public Day09QuanLyBanHangContext(DbContextOptions<Day09QuanLyBanHangContext> options)
            : base(options)
        {
        }

        // ✅ Thêm constructor mặc định cho lệnh migration
        public Day09QuanLyBanHangContext()
        {
        }

        public DbSet<SanPham> SanPhams { get; set; } = default!;
        public DbSet<HoaDon> HoaDons { get; set; } = default!;
        public DbSet<KhachHang> KhachHangs { get; set; } = default!;
        public DbSet<QuanTri> QuanTris { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // 🔗 Kết nối trực tiếp khi chạy migration
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Day09_QuanLyBanHang;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
