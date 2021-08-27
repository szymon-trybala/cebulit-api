using System.Linq;
using System.Threading.Tasks;
using Cebulit.API.Dto.Products;
using Cebulit.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Cebulit.API.Controllers
{
    [ApiController]
    [Route("api/pcParts")]
    public class PcPartsController : ControllerBase
    {
        private readonly IPcPartsRepository _repository;

        public PcPartsController(IPcPartsRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet("getAvailableFilters")]
        public async Task<ActionResult<AvailableFiltersDto>> GetAvailableFilters()
        {
            var cpus = await _repository.GetGroupedProcessorsAsync();
            var gpus = await _repository.GetGroupedGraphicsCardsAsync();
            var cases = await _repository.GetGroupedCasesAsync();
            
            var availableFilters = new AvailableFiltersDto()
            {
                Processors = cpus.Select(x => new AvailableFiltersDto.BrandGroup<AvailableFiltersDto.NamedProduct>
                {
                    Brand = x.Key,
                    Products = x.Value.Select(y => new AvailableFiltersDto.NamedProduct
                    {
                        Id = y.Id,
                        Name = y.Name,
                    }).ToList()
                }).ToList(),
                Cases = cases.Select(x => new AvailableFiltersDto.BrandGroup<AvailableFiltersDto.NamedProduct>
                {
                    Brand = x.Key,
                    Products = x.Value.Select(y => new AvailableFiltersDto.NamedProduct
                    {
                        Id = y.Id,
                        Name = y.Name,
                    }).ToList()
                }).ToList(),
                GraphicsCards = gpus.Select(x => new AvailableFiltersDto.BrandGroup<AvailableFiltersDto.NamedProduct>
                {
                    Brand = x.Key,
                    Products = x.Value.Select(y => new AvailableFiltersDto.NamedProduct
                    {
                        Id = y.Id,
                        Name = y.Name,
                    }).ToList()
                }).ToList(),
                MaxPrice = await _repository.GetHighestPriceAsync(),
                MinPrice = await _repository.GetLowestPriceAsync(),
                RamCapacities = await _repository.GetRamCapacitiesAsync(),
                StorageCapacities = await _repository.GetStorageCapacities(),
                
            };

            return availableFilters;
        }
    }
}