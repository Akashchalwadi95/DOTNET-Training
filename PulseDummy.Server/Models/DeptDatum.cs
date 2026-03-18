using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class DeptDatum
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<UserDatum> UserData { get; set; } = new List<UserDatum>();
}
