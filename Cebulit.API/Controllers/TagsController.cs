using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cebulit.API.Core.Extensions;
using Cebulit.API.Dto.Core;
using Cebulit.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cebulit.API.Controllers
{
    [ApiController]
    [Route("api/tags")]
    public class TagsController : ControllerBase
    {
        private ITagsRepository _repository;
        private readonly IMapper _mapper;

        public TagsController(ITagsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("getAll")]
        public async Task<ActionResult<List<TagDto>>> GetAll()
        {
            var tags = await _repository.GetAllAsync();
            return tags.Select(x => _mapper.Map<TagDto>(x)).ToList();
        }

        [Authorize]
        [HttpGet("getForUser")]
        public async Task<ActionResult<List<TagMatchDto>>> GetForUser()
        {
            var userId = HttpContext.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();
            
            var tagMatches = await _repository.GetForUser(userId.Value);
            return tagMatches.Select(x => _mapper.Map<TagMatchDto>(x)).ToList();
        }
    }
}