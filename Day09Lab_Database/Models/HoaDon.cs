using System;
using System.Collections.Generic;

namespace Day09Lab_Database.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string MaHoaDon { get; set; } = null!;

    public string? MaKhachHang { get; set; }

    public DateOnly? NgayHoaDon { get; set; }

    public DateOnly? NgayNhan { get; set; }

    public string? HoTenKhachHang { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public decimal? TongTriGia { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    public virtual KhachHang? MaKhachHangNavigation { get; set; }
}
