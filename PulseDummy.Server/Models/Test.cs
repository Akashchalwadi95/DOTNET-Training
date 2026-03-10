using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class Test
{
    public string Id { get; set; } = null!;

    public string VesselName { get; set; } = null!;

    public string TestName { get; set; } = null!;

    public string TestType { get; set; } = null!;

    public string? OtherValue { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
