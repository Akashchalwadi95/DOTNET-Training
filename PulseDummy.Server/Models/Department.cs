using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class Department
{
    public int CompanyDepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;
}
