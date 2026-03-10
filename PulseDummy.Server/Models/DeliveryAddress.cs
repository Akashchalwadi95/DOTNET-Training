using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class DeliveryAddress
{
    public int DeliveryAddressId { get; set; }

    public int CustomerId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}
