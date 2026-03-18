using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class ProductsAppOrder
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<ProductsAppOrderDetail> ProductsAppOrderDetails { get; set; } = new List<ProductsAppOrderDetail>();
}
