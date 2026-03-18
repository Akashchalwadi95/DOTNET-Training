using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserRole
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public DateTime AssignedAt { get; set; }

    public int? AssignedByUserId { get; set; }

    public virtual ProductAppUser? AssignedByUser { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ProductAppUser User { get; set; } = null!;
}
