using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserHobbiesBridge
{
    public int UserHobbiesBridge1 { get; set; }

    public int UserId { get; set; }

    public int HobbyId { get; set; }

    public virtual Hobby Hobby { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
