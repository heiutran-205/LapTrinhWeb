using System;
using System.Collections.Generic;

namespace Day09Lab_Database.Models;

public partial class LoaiSanPham
{
    public int Id { get; set; }

    public string MaLoai { get; set; } = null!;

    public string? TenLoai { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
