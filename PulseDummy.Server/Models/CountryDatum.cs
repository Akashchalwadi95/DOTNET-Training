using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class CountryDatum
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<UserDatum> UserData { get; set; } = new List<UserDatum>();
}
