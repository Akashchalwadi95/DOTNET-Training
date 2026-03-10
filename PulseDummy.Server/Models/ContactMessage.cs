using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class ContactMessage
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedAt { get; set; }
}
