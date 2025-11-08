using System;
using System.Collections.Generic;

namespace Day09Lab_Database.Models;

public partial class Category1
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
