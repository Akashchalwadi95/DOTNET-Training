namespace PulseDummy.Server.WebModels
{
    public class UserDataDto
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int DepartmentId { get; set; }

        //Department Field
        public string DepartmentName { get; set; } = null!;
    }
}
