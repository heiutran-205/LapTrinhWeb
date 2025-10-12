using System.ComponentModel.DataAnnotations;

namespace Day09_CodeFirst.Models.DataModels
{
    public class QuanTri
    {
        [Key]
        public int QuanTriID { get; set; }

        [Required]
        public string TaiKhoan { get; set; } = string.Empty;

        [Required]
        public string MatKhau { get; set; } = string.Empty;

        [Required]
        public string TrangThai { get; set; } = string.Empty;
    }
}
