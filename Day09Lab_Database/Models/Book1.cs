using System;
using System.Collections.Generic;

namespace Day09Lab_Database.Models;

public partial class Book1
{
    public string BookId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int? Release { get; set; }

    public double? Price { get; set; }

    public string Description { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public int? PublisherId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Publisher1? Publisher { get; set; }
}
