using System;
using System.Collections.Generic;

namespace PulseDummy.Server.Models;

public partial class User
{
    public int Usersid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? Country { get; set; }

    public string? PhoneNumber { get; set; }

    public bool Gender { get; set; }

    public bool? IsActive { get; set; }

    public decimal Salary { get; set; }

    public string? Image { get; set; }

    public int Departmentsid { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? EditedBy { get; set; }

    public DateTime? EditedOn { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<Department> DepartmentCreatedByNavigations { get; set; } = new List<Department>();

    public virtual ICollection<Department> DepartmentEditedByNavigations { get; set; } = new List<Department>();

    public virtual Department Departments { get; set; } = null!;

    public virtual User? EditedByNavigation { get; set; }

    public virtual ICollection<User> InverseCreatedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<User> InverseEditedByNavigation { get; set; } = new List<User>();

    public virtual ICollection<UserFamily> UserFamilies { get; set; } = new List<UserFamily>();

    public virtual ICollection<UserFile> UserFileCreatedByNavigations { get; set; } = new List<UserFile>();

    public virtual ICollection<UserFile> UserFileEditedByNavigations { get; set; } = new List<UserFile>();

    public virtual ICollection<UserFile> UserFileUsers { get; set; } = new List<UserFile>();

    public virtual ICollection<UserHobbiesBridge> UserHobbiesBridges { get; set; } = new List<UserHobbiesBridge>();
}
