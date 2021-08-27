using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Repositories
{
    public interface IBuildsRepository
    {
        Task<List<Build>> GetAllAsync();
        Task UpdateAsync(Build build);
    }
}