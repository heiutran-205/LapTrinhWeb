using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Day09Lab_Database.Models;

public partial class Day09QuanLyBanHangContext : DbContext
{
    public Day09QuanLyBanHangContext()
    {
    }

    public Day09QuanLyBanHangContext(DbContextOptions<Day09QuanLyBanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CtHoaDon> CtHoaDons { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<QuanTri> QuanTris { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HIEU;Database=Day09_QuanLyBanHang;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CtHoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CT_HOA_D__3214EC272B55A927");

            entity.ToTable("CT_HOA_DON");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGiaMua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HoaDonId)
                .HasMaxLength(20)
                .HasColumnName("HoaDonID");
            entity.Property(e => e.SanPhamId)
                .HasMaxLength(20)
                .HasColumnName("SanPhamID");
            entity.Property(e => e.ThanhTien)
                .HasComputedColumnSql("([SoLuongMua]*[DonGiaMua])", true)
                .HasColumnType("decimal(29, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(20);

            entity.HasOne(d => d.HoaDon).WithMany(p => p.CtHoaDons)
                .HasPrincipalKey(p => p.MaHoaDon)
                .HasForeignKey(d => d.HoaDonId)
                .HasConstraintName("FK_CTHOADON_HOADON");

            entity.HasOne(d => d.SanPham).WithMany(p => p.CtHoaDons)
                .HasPrincipalKey(p => p.MaSanPham)
                .HasForeignKey(d => d.SanPhamId)
                .HasConstraintName("FK_CTHOADON_SANPHAM");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HOA_DON__3214EC275D49CC25");

            entity.ToTable("HOA_DON");

            entity.HasIndex(e => e.MaHoaDon, "UQ__HOA_DON__835ED13A7D646EFB").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(100);
            entity.Property(e => e.MaHoaDon).HasMaxLength(20);
            entity.Property(e => e.MaKhachHang).HasMaxLength(20);
            entity.Property(e => e.TongTriGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(20);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDons)
                .HasPrincipalKey(p => p.MaKhachHang)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK_HOADON_KHACHHANG");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KHACH_HA__3214EC27E99CFB62");

            entity.ToTable("KHACH_HANG");

            entity.HasIndex(e => e.MaKhachHang, "UQ__KHACH_HA__88D2F0E494494981").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTenKhachHang).HasMaxLength(100);
            entity.Property(e => e.MaKhachHang).HasMaxLength(20);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(20);
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOAI_SAN__3214EC2758899333");

            entity.ToTable("LOAI_SAN_PHAM");

            entity.HasIndex(e => e.MaLoai, "UQ__LOAI_SAN__730A5758F5F61981").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MaLoai).HasMaxLength(20);
            entity.Property(e => e.TenLoai).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(20);
        });

        modelBuilder.Entity<QuanTri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QUAN_TRI__3214EC271DF3303B");

            entity.ToTable("QUAN_TRI");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TaiKhoan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(20);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SAN_PHAM__3214EC274D3E363D");

            entity.ToTable("SAN_PHAM");

            entity.HasIndex(e => e.MaSanPham, "UQ__SAN_PHAM__FAC7442C65ACC159").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.MaLoai).HasMaxLength(20);
            entity.Property(e => e.MaSanPham).HasMaxLength(20);
            entity.Property(e => e.TenSanPham).HasMaxLength(200);
            entity.Property(e => e.TrangThai).HasMaxLength(20);

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.SanPhams)
                .HasPrincipalKey(p => p.MaLoai)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_SANPHAM_LOAI");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
