using Day08Lab_Code_Firrst.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    [Table("Books")]
    public class Book
    {
        [DisplayName("Mã sách")]
        [StringLength(10)]
        public string BookId { get; set; }

        [DisplayName("Tên sách")]
        [StringLength(200)]
        public string Title { get; set; }

        [DisplayName("Tác giả")]
        [StringLength(100)]
        public string Author { get; set; }

        [DisplayName("Năm xuất bản")]
        public int? Release { get; set; }

        [DisplayName("Giá")]
        public double? Price { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Hình ảnh")]
        public string Picture { get; set; }

        [DisplayName("Mã nhà xuất bản")]
        public int? PublisherId { get; set; }

        [DisplayName("Mã loại")]
        public int? CategoryId { get; set; }

        // Quan hệ với Category và Publisher
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
    }
}
