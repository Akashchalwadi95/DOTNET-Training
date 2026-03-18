using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class DepartmentsDetail
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public int? ManagerId { get; set; }

    public virtual ICollection<EmployeesDetail> EmployeesDetails { get; set; } = new List<EmployeesDetail>();

    public virtual EmployeesDetail? Manager { get; set; }
}
