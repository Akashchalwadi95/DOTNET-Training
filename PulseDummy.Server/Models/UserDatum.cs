using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserDatum
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? ContactNumber { get; set; }

    public decimal? Salary { get; set; }

    public int? DepartmentId { get; set; }

    public int? CountryId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual CountryDatum? Country { get; set; }

    public virtual DeptDatum? Department { get; set; }

    public virtual ICollection<FileUpload> FileUploads { get; set; } = new List<FileUpload>();

    public virtual ICollection<HobbiesBridgeDatum> HobbiesBridgeData { get; set; } = new List<HobbiesBridgeDatum>();

    public virtual ICollection<UserFamilyDatum> UserFamilyData { get; set; } = new List<UserFamilyDatum>();
}
