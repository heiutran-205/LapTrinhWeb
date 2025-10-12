using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09_CodeFirst.Models.DataModels
{
    public class HoaDon
    {
        [Key]
        public int HoaDonID { get; set; }

        [Required]
        public DateTime NgayLap { get; set; }

        [Required]
        public decimal TongTien { get; set; }

        [Required]
        public string TrangThai { get; set; } = string.Empty;

        // Liên kết
        public int KhachHangID { get; set; }
        public KhachHang? KhachHang { get; set; }
    }
}
