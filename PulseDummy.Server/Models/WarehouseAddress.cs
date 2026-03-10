using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class WarehouseAddress
{
    public int WarehouseId { get; set; }

    public string? WarehouseName { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}
