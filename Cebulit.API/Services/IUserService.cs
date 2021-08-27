using System.Threading.Tasks;
using Cebulit.API.Dto.Auth;
using Cebulit.API.Params;

namespace Cebulit.API.Services
{
    public interface IUserService
    {
        Task<UserDto> Login(LoginDto dto);
        Task<UserDto> Register(RegisterDto dto);
        Task ChangePassword(int userId, PasswordChangeParams passwordChangeParams);
        Task AddBuildOrder(int userId, BuildOrderParams orderParams);
        Task AddGeneratedBuildOrder(int userId, BuildOrderParams orderParams);
    }
}