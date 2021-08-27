using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.API.Models.Auth;

namespace Cebulit.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByLoginAsync(string login);
        Task AddAsync(User user);
        Task<bool> UserExistsAsync(string login);
        Task ChangePasswordAsync(User user, byte[] passwordHash, byte[] passwordSalt);
        Task<List<User.UserTagMatch>> GetTagMatchesAsync(int userId);
        Task<List<User.UserBuildOrder>> GetOrderedBuilds(int userId);
        Task AddBuildOrder(int userId, User.UserBuildOrder buildOrder);
        Task AddGeneratedBuildOrder(int userId, User.UserGeneratedBuildOrder buildOrder);
        Task<List<User.UserGeneratedBuildOrder>> GetOrderedGeneratedBuilds(int userId);

    }
}