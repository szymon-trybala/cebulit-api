using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.API.Models.Products.PcParts;
using Cebulit.API.Params;

namespace Cebulit.API.Services
{
    public interface IBuildsProvider
    {
        Task<List<Build>> GetTagMatched(List<string> tags);
        Task<List<Build>> GetFiltered(BuildsFiltersParams filters, int? userId = null);
    }
}