using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class TodoUser
{
    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
