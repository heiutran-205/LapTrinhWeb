using System;
using System.Collections.Generic;

namespace Day09Lab_Database.Models;

public partial class Publisher1
{
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Book1> Book1s { get; set; } = new List<Book1>();
}
