using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class AdminAddress
{
    public int AddressId { get; set; }

    public string HouseNo { get; set; } = null!;

    public string HouseName { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public string Landmark { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Pincode { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();
}
