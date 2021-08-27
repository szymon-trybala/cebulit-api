using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.API.Models.Products.PcParts;
using Cebulit.API.Params;

namespace Cebulit.API.Repositories
{
    public interface IPcPartsRepository
    {
        public Task<List<Build>> GetAllBuildsAsync();
        public Task<List<Build>> GetRandomAsync(int amount);
        public Task<List<Build>> GetWithTagsAsync(List<string> tags);
        public Task<double> GetLowestPriceAsync();
        public Task<double> GetHighestPriceAsync();
        public Task<Dictionary<string, List<Processor>>> GetGroupedProcessorsAsync();
        public Task<List<int>> GetRamCapacitiesAsync();
        public Task<Dictionary<string, List<GraphicsCard>>> GetGroupedGraphicsCardsAsync();
        public Task<List<int>> GetStorageCapacities();
        public Task<Dictionary<string, List<Case>>> GetGroupedCasesAsync();
        Task<List<Build>> GetFiltered(BuildsFiltersParams filters);
        Task<Build> GetBuildByIdAsync(int id);
    }
}