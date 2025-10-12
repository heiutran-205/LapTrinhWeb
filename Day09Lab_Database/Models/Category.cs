using System;
using System.Collections.Generic;

namespace Day09Lab_Database.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Book1> Book1s { get; set; } = new List<Book1>();
}
