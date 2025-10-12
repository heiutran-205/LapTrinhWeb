using System.ComponentModel.DataAnnotations;

namespace WebLap05.Models
{
    public class Login
    {
        public string employeeName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
