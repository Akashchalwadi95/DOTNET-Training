using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class TodoDatum
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; }
}
