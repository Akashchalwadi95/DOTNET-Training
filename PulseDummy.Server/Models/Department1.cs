using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class Department1
{
    public int Departmentsid { get; set; }

    public string DepartmentName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public string? Description { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual User? EditedByNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
