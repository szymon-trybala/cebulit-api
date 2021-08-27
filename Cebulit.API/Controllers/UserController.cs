using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cebulit.API.Core.Extensions;
using Cebulit.API.Dto.Auth;
using Cebulit.API.Dto.Core;
using Cebulit.API.Dto.Products.PcParts;
using Cebulit.API.Exceptions.Auth;
using Cebulit.API.Params;
using Cebulit.API.Repositories;
using Cebulit.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cebulit.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ITagsRepository _tagsRepository;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUserRepository userRepository, ITagsRepository tagsRepository, IMapper mapper)
        {
            _userService = userService;
            _userRepository = userRepository;
            _tagsRepository = tagsRepository;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto dto)
        {
            try
            {
                return await _userService.Login(dto);
            }
            catch (UnauthorizedException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
        {
            try
            {
                return await _userService.Register(dto);
            }
            catch (UnauthorizedException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [Authorize]
        [HttpPost("changePassword")]
        public async Task<ActionResult> ChangePassword(PasswordChangeParams passwordChangeParams)
        {
            var userId = HttpContext.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();
            
            await _userService.ChangePassword(userId.Value, passwordChangeParams);
            return Ok();
        }

        [HttpPost("setTags")]
        [Authorize]
        public async Task<ActionResult> SetTags(List<TagMatchDto> tagMatches)
        {   
            var userId = HttpContext.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();
            
            await _tagsRepository.SetForUser(userId.Value, tagMatches);
            return Ok();
        }

        [HttpGet("getOrderedBuilds")]
        [Authorize]
        public async Task<ActionResult<List<BuildOrderDto>>> GetOrderedBuilds()
        {
            var userId = HttpContext.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            var orderedBuilds = await _userRepository.GetOrderedBuilds(userId.Value);
            var orderedGeneratedBuilds = await _userRepository.GetOrderedGeneratedBuilds(userId.Value);

            var orderedBuildsDto = orderedBuilds.Select(x => _mapper.Map<BuildOrderDto>(x));
            var orderedGeneratedBuildsDto = orderedGeneratedBuilds.Select(x => _mapper.Map<BuildOrderDto>(x));

            return orderedBuildsDto.Concat(orderedGeneratedBuildsDto).ToList();
        }

        [HttpPost("orderBuild")]
        [Authorize]
        public async Task<ActionResult> OrderBuild(BuildOrderParams orderParams)
        {
            var userId = HttpContext.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            await _userService.AddBuildOrder(userId.Value, orderParams);
            return Ok();
        }

        [HttpPost("orderGeneratedBuild")]
        [Authorize]
        public async Task<ActionResult> OrderUserGeneratedBuild(BuildOrderParams orderParams)
        {
            var userId = HttpContext.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            await _userService.AddGeneratedBuildOrder(userId.Value, orderParams);
            return Ok();
        }
    }
}