using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class ProductsAppOrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string? Title { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ProductsAppOrder Order { get; set; } = null!;
}
