using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class EmployeesDetail
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }

    public DateOnly HireDate { get; set; }

    public virtual DepartmentsDetail Department { get; set; } = null!;

    public virtual ICollection<DepartmentsDetail> DepartmentsDetails { get; set; } = new List<DepartmentsDetail>();
}
