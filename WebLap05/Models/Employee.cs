namespace WebLap05.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; } // giois tinh

        public string Phone { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; } // luong
        public string Status { get; set; } // tinh trang hon nhan

        public string Password { get; set; }
    }
}
