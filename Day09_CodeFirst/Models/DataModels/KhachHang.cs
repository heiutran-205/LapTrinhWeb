using System.ComponentModel.DataAnnotations;

namespace Day09_CodeFirst.Models.DataModels
{
    public class KhachHang
    {
        [Key]
        public int KhachHangID { get; set; }

        [Required, StringLength(100)]
        public string HoTenKhachHang { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string MatKhau { get; set; } = string.Empty;

        [Required]
        public string DiaChi { get; set; } = string.Empty;

        [Required]
        public string DienThoai { get; set; } = string.Empty;

        [Required]
        public string TrangThai { get; set; } = string.Empty;

        public ICollection<HoaDon>? HoaDons { get; set; }
    }
}
