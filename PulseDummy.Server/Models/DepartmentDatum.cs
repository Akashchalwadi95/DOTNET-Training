using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class DepartmentDatum
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<PulseDummyTable> PulseDummyTables { get; set; } = new List<PulseDummyTable>();
}
