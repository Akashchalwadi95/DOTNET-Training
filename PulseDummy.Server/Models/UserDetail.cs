using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class UserDetail
{
    public int UserDetailsId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int Age { get; set; }

    public int CompanyDepartmentId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual CompanyDepartment CompanyDepartment { get; set; } = null!;
}
