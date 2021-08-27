using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cebulit.API.Core.Extensions;
using Cebulit.API.Core.Models;
using Cebulit.API.Data;
using Cebulit.API.Dto.Core;
using Cebulit.API.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace Cebulit.API.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly DataContext _context;

        public TagsRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            var result =  await _context.Tags.ToListAsync();
            return result;
        }

        public async Task<List<User.UserTagMatch>> GetForUser(int userId)
        {
            return await _context.Users.GetUserTagMatchesById(userId);
        }

        public async Task SetForUser(int userId, List<TagMatchDto> dtos)
        {
            var user = await _context.Users
                .Include(x => x.UserTagMatches)
                .SingleAsync(x => x.Id == userId);
            await RemoveTagMatches(user);
            
            var allTags = await GetAllAsync();
            var tagMatches = dtos.Select(match => new User.UserTagMatch
            {
                UserId = userId, 
                User = user, 
                MatchLevel = match.MatchLevel, 
                Tag = allTags.Single(x => x.Id == match.Tag.Id)
            }).ToList();
            
            user.UserTagMatches = tagMatches;
            await _context.SaveChangesAsync();
        }

        private async Task RemoveTagMatches(User user)
        {
            if (user.UserTagMatches != null)
            {
                user.UserTagMatches.Clear();
                await _context.SaveChangesAsync();
            }
        }
    }
}