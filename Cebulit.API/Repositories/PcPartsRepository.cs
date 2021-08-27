using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cebulit.API.Core.Extensions;
using Cebulit.API.Data;
using Cebulit.API.Models.Products.PcParts;
using Cebulit.API.Params;
using Microsoft.EntityFrameworkCore;

namespace Cebulit.API.Repositories
{
    public class PcPartsRepository : IPcPartsRepository
    {
        private readonly DataContext _context;

        public PcPartsRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<Build>> GetAllBuildsAsync()
        {
            var builds = await _context.Builds.IncludePartsAndToListAsync();
            return builds;
        }

        public async Task<List<Build>> GetRandomAsync(int amount)
        {
            var buildsLength = await _context.Builds.CountAsync();
            var random = new Random();
            var maxToSkip = buildsLength - 5;
            var builds = await _context.Builds
                .OrderBuilds("name")
                .Skip(random.Next(0, maxToSkip))
                .Take(5)
                .IncludePartsAndToListAsync();

            return builds;
        }

        public async Task<List<Build>> GetWithTagsAsync(List<string> tags)
        {
            var builds = await _context.Builds.Where(
                    x => x.BuildTagMatches.Any(y =>
                        tags.Contains(y.Tag.Name)))
                .IncludeEverythingAndToListAsync();
            return builds;
        }

        public async Task<double> GetLowestPriceAsync()
        {
            var allPrices = await _context.Builds.Select(x => x.Price).ToListAsync();
            return allPrices.Min();
        }

        public async Task<double> GetHighestPriceAsync()
        {
            var allPrices = await _context.Builds.Select(x => x.Price).ToListAsync();
            return allPrices.Max();
        }

        public async Task<Dictionary<string, List<Processor>>> GetGroupedProcessorsAsync()
        {
            var cpuNames = await _context.Processors
                .OrderBy(x => x.Name)
                .ToListAsync();

            return cpuNames
                .GroupBy(x => x.Brand)
                .GroupToDictionary();
        }

        public async Task<List<int>> GetRamCapacitiesAsync()
        {
            var capacities = await _context.Memory
                .OrderBy(x => x.Capacity)
                .Select(x => x.Capacity)
                .Distinct()
                .ToListAsync();

            return capacities;
        }

        public async Task<Dictionary<string, List<GraphicsCard>>> GetGroupedGraphicsCardsAsync()
        {
            var gpuNames = await _context.GraphicsCards
                .OrderBy(x => x.Name)
                .ToListAsync();

            return gpuNames
                .GroupBy(x => x.Brand)
                .GroupToDictionary();
        }

        public async Task<List<int>> GetStorageCapacities()
        {
            var capacities = await _context.Storage
                .OrderBy(x => x.Capacity)
                .Select(x => x.Capacity)
                .Distinct()
                .ToListAsync();

            return capacities;
        }

        public async Task<Dictionary<string, List<Case>>> GetGroupedCasesAsync()
        {
            var caseNames = await _context.Cases
                .OrderBy(x => x.Name)
                .ToListAsync();

            return caseNames
                .GroupBy(x => x.Brand)
                .GroupToDictionary();
        }

        public async Task<List<Build>> GetFiltered(BuildsFiltersParams filters)
        {
            var builds = await _context.Builds
                .WhereIf(filters.MinPrice.HasValue, x => x.Price >= filters.MinPrice.Value)
                .WhereIf(filters.MaxPrice.HasValue, x => x.Price <= filters.MaxPrice.Value)
                .WhereIf(filters.ProcessorIds?.Any() ?? false, x => filters.ProcessorIds.Contains(x.ProcessorId))
                .WhereIf(filters.GraphicsCardIds?.Any() ?? false, x => x.GraphicsCardId.HasValue && filters.GraphicsCardIds.Contains(x.GraphicsCardId.Value))
                .WhereIf(filters.CaseIds?.Any() ?? false, x => filters.CaseIds.Contains(x.CaseId))
                .WhereIf(filters.RamCapacities?.Any() ?? false, x => filters.RamCapacities.Contains(x.Memory.Capacity))
                .WhereIf(filters.StorageCapacities?.Any() ?? false,
                    x => x.Storage.Any(y => filters.StorageCapacities.Contains(y.Capacity)))
                .OrderBuilds(filters.OrderBy)
                .IncludeEverythingAndToListAsync();

            return builds;
        }

        public async Task<Build> GetBuildByIdAsync(int id)
        {
            var result = await _context.Builds
                .SingleAsync(x => x.Id == id);

            return result;
        }
    }
}