using Cebulit.API.Models.Auth;

namespace Cebulit.API.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}