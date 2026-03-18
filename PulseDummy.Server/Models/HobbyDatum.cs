using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class HobbyDatum
{
    public int HobbyId { get; set; }

    public string HobbyName { get; set; } = null!;

    public virtual ICollection<HobbiesBridgeDatum> HobbiesBridgeData { get; set; } = new List<HobbiesBridgeDatum>();
}
