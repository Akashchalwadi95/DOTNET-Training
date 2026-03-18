using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class ProductsDatum
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public string? Image { get; set; }

    public decimal? RatingRate { get; set; }

    public int? RatingCount { get; set; }
}
