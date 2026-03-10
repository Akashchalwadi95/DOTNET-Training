using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class Hobby
{
    public int HobbyId { get; set; }

    public string HobbyName { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<UserHobbiesBridge> UserHobbiesBridges { get; set; } = new List<UserHobbiesBridge>();
}
