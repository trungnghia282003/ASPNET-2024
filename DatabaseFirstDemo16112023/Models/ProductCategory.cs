using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo16112023.Models;

public partial class ProductCategory
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
