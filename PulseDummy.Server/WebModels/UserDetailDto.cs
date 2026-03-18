namespace PulseDummy.Server.WebModels
{
    public class UserDetailDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? CreatedOn { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
        public int Age { get; set; }
        public int DepartmentId { get; set; }

    }
}
