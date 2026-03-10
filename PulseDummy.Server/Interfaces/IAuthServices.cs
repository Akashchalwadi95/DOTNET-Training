using PulseDummy.Server.Models;
using PulseDummy.Server.WebModels;
using System.Threading.Tasks;

namespace PulseDummy.Server.Interfaces
{
    public interface IAuthServices
    {
        Task<(bool Success, string Message)> RegisterAsync(PulseDummyTableDto model);

        Task<(bool Success, string Message)> LoginAsync(LoginDto model);
    }
}