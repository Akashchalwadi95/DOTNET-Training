using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserFamily
{
    public int UserfamilyId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Contact { get; set; } = null!;

    public string Relation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
