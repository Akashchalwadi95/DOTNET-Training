using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class CompanyDepartment
{
    public int CompanyDepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<PulseDummyTable> PulseDummyTables { get; set; } = new List<PulseDummyTable>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
