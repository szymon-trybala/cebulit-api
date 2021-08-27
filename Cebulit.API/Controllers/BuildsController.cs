using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cebulit.API.Core.Extensions;
using Cebulit.API.Dto.Products.PcParts;
using Cebulit.API.Params;
using Cebulit.API.Repositories;
using Cebulit.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cebulit.API.Controllers
{
    [ApiController]
    [Route("api/builds")]
    public class BuildsController : ControllerBase
    {
        private readonly IBuildsProvider _provider;
        private readonly IMapper _mapper;
        private readonly IUserBuildsRepository _userBuildsRepository;
        private readonly IPriceUpdater _priceUpdater;

        public BuildsController(IBuildsProvider provider, IMapper mapper, IUserBuildsRepository userBuildsRepository, IPriceUpdater priceUpdater)
        {
            _provider = provider;
            _mapper = mapper;
            _userBuildsRepository = userBuildsRepository;
            _priceUpdater = priceUpdater;
        }
        
        [HttpPost("getTagMatched")]
        public async Task<ActionResult<List<BuildDto>>> GetTagMatched(TagMatchedBuildsParams tagMatchedParams)
        {
            var builds = await _provider.GetTagMatched(tagMatchedParams.Tags);
            return builds.Select(x => _mapper.Map<BuildDto>(x)).ToList();
        }

        [HttpPost("getFiltered")]
        public async Task<ActionResult<List<BuildDto>>> GetFiltered(BuildsFiltersParams filters)
        {
            var builds = await _provider.GetFiltered(filters);
            return builds.Select(x => _mapper.Map<BuildDto>(x)).ToList();
        }
        
        [Authorize]
        [HttpPost("getFilteredForUser")]
        public async Task<ActionResult<List<BuildDto>>> GetFilteredForUser(BuildsFiltersParams filters)
        {
            var builds = await _provider.GetFiltered(filters, HttpContext.GetUserId());
            return builds.Select(x => _mapper.Map<BuildDto>(x)).ToList();
        }

        [Authorize]
        [HttpGet("generateBuild")]
        public async Task<ActionResult<BuildDto>> GeneratePersonalizedBuild()
        {
            var userId = HttpContext.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();
            
            var build = await _userBuildsRepository.GenerateBuildForUserAsync(userId.Value);
            return _mapper.Map<BuildDto>(build);
        }

        [HttpGet("updateBuildsPrices")]
        public async Task<ActionResult> UpdateBuildsPrices()
        {
            await _priceUpdater.UpdateAllBuildsPrices();
            return Ok();
        }
    }
}