using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cebulit.API.Core.Extensions;
using Cebulit.API.Data;
using Cebulit.API.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace Cebulit.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Login == login.ToLower());
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(string login)
        {
            return await _context.Users.AnyAsync(x => x.Login == login);
        }

        public async Task ChangePasswordAsync(User user, byte[] passwordHash, byte[] passwordSalt)
        {
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User.UserTagMatch>> GetTagMatchesAsync(int userId)
        {
            var result = await _context.Users
                .Include(x => x.UserTagMatches)
                .ThenInclude(x => x.Tag)
                .SingleAsync(x => x.Id == userId);
            
            return result.UserTagMatches.ToList();
        }

        public async Task<List<User.UserBuildOrder>> GetOrderedBuilds(int userId)
        {
            var result = await _context.Users
                .Include(x => x.UserBuildOrders)
                .ThenIncludeEverything()
                .SingleAsync(x => x.Id == userId);

            return result.UserBuildOrders.ToList();
        }

        public async Task<List<User.UserGeneratedBuildOrder>> GetOrderedGeneratedBuilds(int userId)
        {
            var result = await _context.Users
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenIncludeEverything()
                .SingleAsync(x => x.Id == userId);

            return result.UserGeneratedBuildOrders.ToList();
        }
        
        public async Task AddBuildOrder(int userId, User.UserBuildOrder buildOrder)
        {
            var user = await _context.Users
                .Include(x => x.UserBuildOrders)
                .SingleAsync(x => x.Id == userId);
            
            user.UserBuildOrders.Add(buildOrder);
            await _context.SaveChangesAsync();        
        }

        public async Task AddGeneratedBuildOrder(int userId, User.UserGeneratedBuildOrder buildOrder)
        {
            var user = await _context.Users
                .Include(x => x.UserGeneratedBuildOrders)
                .SingleAsync(x => x.Id == userId);
            
            user.UserGeneratedBuildOrders.Add(buildOrder);
            await _context.SaveChangesAsync();            }
    }
}