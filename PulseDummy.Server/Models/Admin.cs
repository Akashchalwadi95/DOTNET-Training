using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Title { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string AliasName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int AddressId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual AdminAddress Address { get; set; } = null!;
}
