using System.Threading.Tasks;
using HotelsApi.Models;

namespace HotelsApi.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO userDTO);
        Task<string> CreateToken();

    }
}