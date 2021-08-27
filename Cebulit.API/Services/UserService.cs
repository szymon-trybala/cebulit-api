using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Cebulit.API.Dto.Auth;
using Cebulit.API.Exceptions.Auth;
using Cebulit.API.Models.Auth;
using Cebulit.API.Params;
using Cebulit.API.Repositories;

namespace Cebulit.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPcPartsRepository _pcPartsRepository;
        private readonly IUserBuildsRepository _userBuildsRepository;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository, IPcPartsRepository pcPartsRepository, IUserBuildsRepository userBuildsRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _pcPartsRepository = pcPartsRepository;
            _userBuildsRepository = userBuildsRepository;
            _tokenService = tokenService;
        }
        
        public async Task<UserDto> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByLoginAsync(dto.Login);
            if (user == null)
                throw new UnauthorizedException("Niepoprawny login");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var newHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            if (!HashesAreEqual(newHash, user.PasswordHash))
                throw new UnauthorizedException("Niepoprawne hasło");

            return new UserDto
            {
                Id = user.Id,
                Login = user.Login,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<UserDto> Register(RegisterDto dto)
        {
            if (await _userRepository.UserExistsAsync(dto.Login))
                throw new UnauthorizedException("Ten login jest już zajęty");
            
            using var hmac = new HMACSHA512();
            var user = new User
            {
                Login = dto.Login,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password)),
                PasswordSalt = hmac.Key
            };

            await _userRepository.AddAsync(user);
            return new UserDto
            {
                Id = user.Id,
                Login = user.Login,
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task ChangePassword(int userId, PasswordChangeParams passwordChangeParams)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UnauthorizedException("Brak użytkownika");
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            
            var currentPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordChangeParams.CurrentPassword));
            if (!HashesAreEqual(currentPasswordHash, user.PasswordHash))
                throw new UnauthorizedException("Niepoprawne hasło");

            var newPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordChangeParams.NewPassword));
            await _userRepository.ChangePasswordAsync(user, newPasswordHash, hmac.Key);
        }

        public async Task AddBuildOrder(int userId, BuildOrderParams orderParams)
        {
            var build = await _pcPartsRepository.GetBuildByIdAsync(orderParams.BuildId);

            var userBuildOrder = new User.UserBuildOrder
            {
                UserId = userId,
                BuildId = build.Id,
                Price = build.Price,
            };
            await _userRepository.AddBuildOrder(userId, userBuildOrder);
        }

        public async Task AddGeneratedBuildOrder(int userId, BuildOrderParams orderParams)
        {
            var build = await _userBuildsRepository.GetByIdAsync(orderParams.BuildId);

            var userBuildOrder = new User.UserGeneratedBuildOrder
            {
                UserId = userId,
                UserGeneratedBuildId = build.Id,
                Price = build.Price,
            };
            await _userRepository.AddGeneratedBuildOrder(userId, userBuildOrder);
        }

        private bool HashesAreEqual(byte[] newHash, byte[] existingHash)
        {
            for (var i = 0; i < newHash.Length; i++)
            {
                if (newHash[i] != existingHash[i])
                    return false;
            }

            return true;
        }
    }
}