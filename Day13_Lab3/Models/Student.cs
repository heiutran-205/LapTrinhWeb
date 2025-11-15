using System.ComponentModel.DataAnnotations;

namespace Day13_Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên bắt buộc phải được nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ và tên phải từ 4 đến 100 ký tự")]
        [Display(Name = "Họ và tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email bắt buộc phải được nhập")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [RegularExpression(@".*@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, số và ký tự đặc biệt")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Mật khẩu bắt buộc phải được nhập")]
        [Display(Name = "Mật khẩu")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Ngành học bắt buộc phải được chọn")]
        [Display(Name = "Ngành học")]
        public Branch? Branch { get; set; }
        [Required(ErrorMessage = "Giới tính bắt buộc phải được chọn")]
        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; }
        [Required(ErrorMessage = "Chính quy bắt buộc phải được chọn")]
        [Display(Name = "Chính quy")]
        public bool IsRegular { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ bắt buộc phải được nhập")]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }
        [Range(typeof(DateTime), "1/1/1900", "12/31/2025", ErrorMessage = "DateOfBorth phải nằm trong khoảng 1/1/1900 đến 12/31/2025")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh bắt buộc phải được nhập/chọn")]
        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBorth { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập điểm")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        [Display(Name = "Điểm trung bình")]
        public double Grade { get; set; }
        public string? Avatar { get; set; }
    }
}
