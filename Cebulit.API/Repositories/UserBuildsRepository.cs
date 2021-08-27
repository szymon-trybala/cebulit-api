using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cebulit.API.Core.Models;
using Cebulit.API.Data;
using Cebulit.API.Models.Auth;
using Cebulit.API.Models.Products.PcParts;
using Microsoft.EntityFrameworkCore;

namespace Cebulit.API.Repositories
{
    public class UserBuildsRepository : IUserBuildsRepository
    {        
        private readonly DataContext _context;

        public UserBuildsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserBuild> GetByIdAsync(int id)
        {
            return await _context.UserBuilds.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserBuild> GenerateBuildForUserAsync(int userId)
        {
            var user = await _context.Users.Include(x => x.UserTagMatches).SingleAsync(x => x.Id == userId);
            var generatedBuild = await CreateBuildForUser(user);

            var existing = await GetEqualOrDefaultAsync(generatedBuild);
            if (existing != null) return existing;
            
            await AddBuildAsync(generatedBuild);
            return generatedBuild;
        }

        public async Task AddBuildAsync(UserBuild build)
        {
            await _context.UserBuilds.AddAsync(build);
            await _context.SaveChangesAsync();        
        }

        public async Task<UserBuild> GetEqualOrDefaultAsync(UserBuild build)
        {
            var foundBuild = await _context.UserBuilds
                .Where(x => x.UserId == build.User.Id)
                .Where(x => Math.Abs(x.Price - build.Price) < 1)
                .Where(x => x.Name == build.Name)
                .Where(x => x.ProcessorId == build.Processor.Id)
                .Where(x => x.MotherboardId == build.Motherboard.Id)
                .Where(x => x.MemoryId == build.Memory.Id)
                .Where(x => x.GraphicsCardId == build.GraphicsCard.Id)
                .Where(x => x.PowerSupplyId == build.PowerSupply.Id)
                .Where(x => x.CaseId == build.Case.Id)
                .FirstOrDefaultAsync();

            return foundBuild;
        }
        
        private async Task<UserBuild> CreateBuildForUser(User user)
        {
            var userTagMatches = user.UserTagMatches.ToList();
            
            var cpu = await GetProcessorForUser(userTagMatches);
            var mobo = await GetMotherboardForUser(userTagMatches, cpu.Socket);
            var memory = await GetMemoryForUser(userTagMatches, mobo.MemorySlots);
            var gpu = await GetGraphicsCardForUser(userTagMatches);
            var storage = await GetStorageForUser(userTagMatches);
            var powerSupply = await GetPowerSupplyForUser(userTagMatches);
            var computerCase = await GetCaseForUser(userTagMatches, mobo.FormFactor);
            
            var newBuild = new UserBuild
            {
                Processor = cpu,
                Motherboard = mobo,
                Storage = new List<Storage> {storage},
                Memory = memory,
                GraphicsCard = gpu,
                PowerSupply = powerSupply,
                Case = computerCase,
                User = user,
                Price = 0,
                GeneratedAt = DateTime.Now,
            };
            newBuild.Price = CalculatePriceForBuild(newBuild);
            newBuild.Name = GetNameForUserBuild(newBuild);

            return newBuild;
        }

        private double CalculatePriceForBuild(UserBuild build)
        {
            var basePrice = build.Processor.Price + build.Motherboard.Price + build.Memory.Price +
                        build.Storage.Sum(x => x.Price) + build.PowerSupply.Price + build.Case.Price;
            return Math.Ceiling(basePrice / 10.0) * 10;
        }
        
        private string GetNameForUserBuild(UserBuild build)
        {
            var sb = new StringBuilder();
            sb.Append($"{build.Processor.Name}/");
            sb.Append($"{build.Memory.Capacity}/");
            sb.Append($"{build.GraphicsCard.Name}/");
            foreach (var st in build.Storage)
            {
                sb.Append($"{st.Capacity}GB/");
            }

            return sb.ToString();
        }

        private async Task<Processor> GetProcessorForUser(List<User.UserTagMatch> userTagMatches)
        {
            if (userTagMatches == null)
                return await _context.Processors.FirstAsync();

            var allCpus = await _context.Processors
                .Include(x => x.ProcessorTagMatches)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
            
            var mostMatchingCpus = allCpus.Select(x => new
                {
                    processor = x,
                    tagsMatch = CalculatePcPartTagMatch(x.ProcessorTagMatches, userTagMatches)
                })
                .OrderByDescending(x => x.tagsMatch)
                .Take(3)
                .ToArray();

            var random = new Random();
            return mostMatchingCpus[random.Next(0, 3)].processor;
        }

        private async Task<Motherboard> GetMotherboardForUser(List<User.UserTagMatch> userTagMatches, string socket)
        {
            if (userTagMatches == null)
                return await _context.Motherboards
                    .Where(x => x.Socket == socket)
                    .FirstAsync();

            var allMobos = await _context.Motherboards
                .Include(x => x.MotherboardTagMatches)
                .ThenInclude(x => x.Tag)
                .Where(x => x.Socket == socket)
                .ToListAsync();
            
            return allMobos.Select(x => new
                {
                    motherboard = x,
                    tagsMatch = CalculatePcPartTagMatch(x.MotherboardTagMatches, userTagMatches)
                })
                .OrderByDescending(x => x.tagsMatch)
                .First()
                .motherboard;
        }

        private async Task<Memory> GetMemoryForUser(List<User.UserTagMatch> userTagMatches, int maxMemorySlots)
        {
            if (userTagMatches == null)
                return await _context.Memory
                    .Where(x => x.Modules <= maxMemorySlots )
                    .FirstAsync();

            var allMemories = await _context.Memory
                .Include(x => x.MemoryTagMatches)
                .ThenInclude(x => x.Tag)
                .Where(x => x.Modules <= maxMemorySlots)
                .ToListAsync();
            
            return allMemories.Select(x => new
                {
                    memory = x,
                    tagsMatch = CalculatePcPartTagMatch(x.MemoryTagMatches, userTagMatches)
                })
                .OrderByDescending(x => x.tagsMatch)
                .First()
                .memory;
        }

        private async Task<GraphicsCard> GetGraphicsCardForUser(List<User.UserTagMatch> userTagMatches)
        {
            if (userTagMatches == null)
                return await _context.GraphicsCards.FirstAsync();

            var allGpus = await _context.GraphicsCards
                .Include(x => x.GraphicsCardsTagMatches)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
            
            var mostMatchingGpus = allGpus.Select(x => new
                {
                    graphicsCard = x,
                    tagsMatch = CalculatePcPartTagMatch(x.GraphicsCardsTagMatches, userTagMatches)
                })
                .OrderByDescending(x => x.tagsMatch)
                .Take(3)
                .ToArray();

            var random = new Random();
            return mostMatchingGpus[random.Next(0, 3)].graphicsCard;
        }

        private async Task<Storage> GetStorageForUser(List<User.UserTagMatch> userTagMatches)
        {
            if (userTagMatches == null)
                return await _context.Storage.FirstAsync();

            var allStorages = await _context.Storage
                .Include(x => x.StorageTagMatches)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
            
            return allStorages.Select(x => new
                {
                    storage = x,
                    tagsMatch = CalculatePcPartTagMatch(x.StorageTagMatches, userTagMatches)
                })
                .OrderByDescending(x => x.tagsMatch)
                .First()
                .storage;
        }

        private async Task<PowerSupply> GetPowerSupplyForUser(List<User.UserTagMatch> userTagMatches)
        {
            if (userTagMatches == null)
                return await _context.PowerSupplies.FirstAsync();

            var allPsus = await _context.PowerSupplies
                .Include(x => x.PowerSupplyTagMatches)
                .ThenInclude(x => x.Tag)
                .ToListAsync();
            
            return allPsus.Select(x => new
                {
                    psu = x,
                    tagsMatch = CalculatePcPartTagMatch(x.PowerSupplyTagMatches, userTagMatches)
                })
                .OrderByDescending(x => x.tagsMatch)
                .First()
                .psu;
        }

        private async Task<Case> GetCaseForUser(List<User.UserTagMatch> userTagMatches, MotherboardFormFactor formFactor)
        {
            if (userTagMatches == null)
                return await _context.Cases
                    .Where(x => x.FormFactor == formFactor)
                    .FirstAsync();

            var allCases = await _context.Cases
                .Include(x => x.CaseTagMatches)
                .ThenInclude(x => x.Tag)
                .Where(x => x.FormFactor == formFactor)
                .ToListAsync();
            
            return allCases.Select(x => new
                {
                    computerCase = x,
                    tagsMatch = CalculatePcPartTagMatch(x.CaseTagMatches, userTagMatches)
                })
                .OrderByDescending(x => x.tagsMatch)
                .First()
                .computerCase;
        }

        private double CalculatePcPartTagMatch<T>(ICollection<T> partTagMatches, List<User.UserTagMatch> userTagMatches) where T : TagMatch
        {
            double sum = 0f;

            foreach (var userMatch in userTagMatches)
            {
                var buildMatch = partTagMatches.SingleOrDefault(x => x.Tag.Id == userMatch.Tag.Id);
                if (buildMatch != null)
                {
                    sum += userMatch.MatchLevel * buildMatch.MatchLevel;
                }
            }

            return sum;
        }
    }
}