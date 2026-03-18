using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class HobbiesBridgeDatum
{
    public int UserHobbyId { get; set; }

    public int? UserId { get; set; }

    public int? HobbyId { get; set; }

    public virtual HobbyDatum? Hobby { get; set; }

    public virtual UserDatum? User { get; set; }
}
