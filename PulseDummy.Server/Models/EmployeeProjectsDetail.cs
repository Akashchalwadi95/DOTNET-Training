using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class EmployeeProjectsDetail
{
    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public DateOnly AssignedDate { get; set; }

    public virtual EmployeesDetail Employee { get; set; } = null!;

    public virtual ProjectDetail Project { get; set; } = null!;
}
