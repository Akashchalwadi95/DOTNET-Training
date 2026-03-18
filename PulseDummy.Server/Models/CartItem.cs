using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class CartItem
{
    public int CartId { get; set; }

    public string UserName { get; set; } = null!;

    public int ProductId { get; set; }

    public string? ProductTitle { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? AddedDate { get; set; }
}
