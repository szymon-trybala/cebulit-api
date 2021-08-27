using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.API.Core.Models;
using Cebulit.API.Dto.Core;
using Cebulit.API.Models.Auth;

namespace Cebulit.API.Repositories
{
    public interface ITagsRepository
    {
        public Task<List<Tag>> GetAllAsync();
        public Task<List<User.UserTagMatch>> GetForUser(int userId);
        public Task SetForUser(int userId, List<TagMatchDto> dtos);
    }
}