using PulseDummy.Server.Context;
using PulseDummy.Server.WebModels;
using PulseDummy.Server.Models;
using PulseDummy.Server.Interfaces;

namespace PulseDummy.Server.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly TrainingEdotContext _context;
        public AuthServices(TrainingEdotContext context)
        {
            _context = context;
        }

        public async Task<(bool Success, string Message)> RegisterAsync(PulseDummyTableDto model)
        {
            if (_context.PulseDummyTables.Any(x => x.Email == model.Email))
            {
                return (false, "Email already exists");
            }

            if (string.IsNullOrWhiteSpace(model.FirstName))
            {
                return (false, "FirstName is Required");
            }
            if (string.IsNullOrWhiteSpace(model.LastName))
            {
                return (false, "LastName is Required");
            }
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return (false, "Email is Required");
            }
            if (string.IsNullOrWhiteSpace(model.Password))
            {
                return (false, "Password is Required");
            }
            if (string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                return (false, "PhoneNumber is Required");
            }
            if (model.Age == null)
            {
                return (false, "Age is Required");
            }

            if (model.Age > 150 || model.Age < 0)
            {
                return (false, "Age should be positive and less than 150 years");
            }

            // Map Webmodel to Entity
            var entity = new PulseDummy.Server.Models.PulseDummyTable
            {
                Email = model.Email,
                Password = model.Password,
                CreatedOn = DateTime.UtcNow,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Age = model.Age,
                DepartmentId = model.DepartmentId
            };

            try
            {
                _context.PulseDummyTables.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return (false, $"An error occured while saving data {ex.Message}");
            }

            return (true, "Registration Success");
        }

        public async Task<(bool Success, string Message)> LoginAsync(LoginDto model)
        {
            var user = _context.PulseDummyTables.FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
                return (false, "Invalid Email or Password");

            if (user.Password != model.Password)
                return (false, "Invalid Password");

            return (true, "Login Success");

        }
    }
}

