using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.API.Models.Auth;
using Cebulit.API.Repositories;

namespace Cebulit.Tests.RepositoriesImplementations
{
    public class MockUsersRepository : IUserRepository
    {
        public Task<User> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByLoginAsync(string login)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExistsAsync(string login)
        {
            throw new System.NotImplementedException();
        }

        public Task ChangePasswordAsync(User user, byte[] passwordHash, byte[] passwordSalt)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<User.UserTagMatch>> GetTagMatchesAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<User.UserBuildOrder>> GetOrderedBuilds(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task AddBuildOrder(int userId, User.UserBuildOrder buildOrder)
        {
            throw new System.NotImplementedException();
        }

        public Task AddGeneratedBuildOrder(int userId, User.UserGeneratedBuildOrder buildOrder)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<User.UserGeneratedBuildOrder>> GetOrderedGeneratedBuilds(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}