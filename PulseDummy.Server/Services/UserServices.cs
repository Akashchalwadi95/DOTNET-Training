using PulseDummy.Server.Models;
using PulseDummy.Server.WebModels;
using PulseDummy.Server.Interfaces;
using PulseDummy.Server.Context;
using Microsoft.EntityFrameworkCore;

namespace PulseDummy.Server.Services
{
    public class UserServices : IUserServices
    {
        private readonly TrainingEdotContext _context;
        public UserServices(TrainingEdotContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message, List<UserDataDto> Data)> GetUserDataAsync()
        {
            var users = await _context.UserDetails.Include(u=> u.CompanyDepartment).Select(u => new UserDataDto
            {
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                DepartmentId = u.CompanyDepartment.CompanyDepartmentId,
                DepartmentName = u.CompanyDepartment.DepartmentName
            }).ToListAsync();

            if(users.Count == 0)
            {
                return (false, "No users found", new List<UserDataDto>());
            }

            return (true, "Users fetched successfully", users);
        }
    }
}
