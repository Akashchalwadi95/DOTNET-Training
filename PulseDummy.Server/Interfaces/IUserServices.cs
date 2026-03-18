using PulseDummy.Server.WebModels;
using System.Threading.Tasks;

namespace PulseDummy.Server.Interfaces
{
    public interface IUserServices
    {
        Task<(bool Success, string Message, List<UserDataDto> Data)> GetUserDataAsync();
    }
}
