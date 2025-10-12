using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09_CodeFirst.Models.DataModels
{
    public class SanPham
    {
        [Key]
        public int SanPhamID { get; set; }

        [Required, StringLength(100)]
        public string TenSanPham { get; set; } = string.Empty;

        [Required]
        public string HinhAnh { get; set; } = string.Empty;

        [Required]
        public string MaLoai { get; set; } = string.Empty;

        [Required]
        public string TrangThai { get; set; } = string.Empty;

        public ICollection<HoaDon>? CTHoaDons { get; set; }
    }
}
