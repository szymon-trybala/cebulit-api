using System.Threading.Tasks;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Repositories
{
    public interface IUserBuildsRepository
    {
        Task<UserBuild> GetByIdAsync(int id);
        Task<UserBuild> GenerateBuildForUserAsync(int userId);
        Task AddBuildAsync(UserBuild build);
        Task<UserBuild> GetEqualOrDefaultAsync(UserBuild build);
    }
}