using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.API.Data;
using Cebulit.API.Models.Products.PcParts;
using Microsoft.EntityFrameworkCore;

namespace Cebulit.API.Repositories
{
    public class BuildsRepository : IBuildsRepository
    {
        private readonly DataContext _context;

        public BuildsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Build>> GetAllAsync()
        {
            return await _context.Builds.ToListAsync();
        }

        public async Task UpdateAsync(Build build)
        {
            _context.Update(build);
            await _context.SaveChangesAsync();
        }
    }
}