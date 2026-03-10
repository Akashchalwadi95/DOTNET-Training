using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class Report
{
    public string Id { get; set; } = null!;

    public string TestId { get; set; } = null!;

    public string ReportType { get; set; } = null!;

    public DateOnly ReportDate { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Test Test { get; set; } = null!;
}
