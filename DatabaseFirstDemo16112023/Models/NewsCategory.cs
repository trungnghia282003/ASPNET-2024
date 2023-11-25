using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo16112023.Models;

public partial class NewsCategory
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
