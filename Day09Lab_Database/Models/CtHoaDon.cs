using System;
using System.Collections.Generic;

namespace Day09Lab_Database.Models;

public partial class CtHoaDon
{
    public int Id { get; set; }

    public string? HoaDonId { get; set; }

    public string? SanPhamId { get; set; }

    public int? SoLuongMua { get; set; }

    public decimal? DonGiaMua { get; set; }

    public decimal? ThanhTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual HoaDon? HoaDon { get; set; }

    public virtual SanPham? SanPham { get; set; }
}
