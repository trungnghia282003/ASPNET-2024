using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo16112023.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime DateBuy { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<OrdersDetail> OrdersDetails { get; set; } = new List<OrdersDetail>();

    public virtual User User { get; set; } = null!;
}
