using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo16112023.Models;

public partial class Product
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string Avatar { get; set; } = null!;

    public int UserId { get; set; }

    public DateTime DateUpdate { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool Status { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();

    public virtual User User { get; set; } = null!;
}
