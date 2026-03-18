using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class ProjectDetail
{
    public int ProjectId { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}
