using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserHist
{
    public int UserHistId { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = null!;

    public DateTime? LogDate { get; set; }
}
