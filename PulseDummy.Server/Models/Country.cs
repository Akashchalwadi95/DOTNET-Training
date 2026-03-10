using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string CountryCode { get; set; } = null!;
}
