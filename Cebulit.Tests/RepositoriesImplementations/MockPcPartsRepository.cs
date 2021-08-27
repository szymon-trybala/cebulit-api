using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cebulit.API.Models.Products.PcParts;
using Cebulit.API.Params;
using Cebulit.API.Repositories;

namespace Cebulit.Tests.RepositoriesImplementations
{
    public class MockPcPartsRepository : IPcPartsRepository
    {
        public readonly MockData Data = new MockData();
        
        public Task<List<Build>> GetAllBuildsAsync()
        {
            return Task.FromResult(Data.MockBuilds);
        }

        public Task<List<Build>> GetRandomAsync(int amount)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Build>> GetWithTagsAsync(List<string> tags)
        {
            return Task.FromResult(Data.MockBuilds.Where(x =>
                x.BuildTagMatches.Any(y => tags.Contains(y.Tag.Name))).ToList());
        }

        public Task<double> GetLowestPriceAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<double> GetHighestPriceAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Dictionary<string, List<Processor>>> GetGroupedProcessorsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<int>> GetRamCapacitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Dictionary<string, List<GraphicsCard>>> GetGroupedGraphicsCardsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<int>> GetStorageCapacities()
        {
            throw new System.NotImplementedException();
        }

        public Task<Dictionary<string, List<Case>>> GetGroupedCasesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Build>> GetFiltered(BuildsFiltersParams filters)
        {
            throw new System.NotImplementedException();
        }

        public Task<Build> GetBuildByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}