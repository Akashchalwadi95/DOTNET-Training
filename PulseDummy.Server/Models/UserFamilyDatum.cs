using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserFamilyDatum
{
    public int FamilyId { get; set; }

    public int? UserId { get; set; }

    public string? MemberName { get; set; }

    public string? Relation { get; set; }

    public int? Age { get; set; }

    public virtual UserDatum? User { get; set; }
}
