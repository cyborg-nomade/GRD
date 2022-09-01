using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using CPTM.GRD.Application.Responses;
using CPTM.GRD.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPTM.GRD.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/users/login
        [HttpPost("login")]
        public async Task<AuthResponse> Login([FromBody] AuthUser authUser)
        {
            return await _mediator.Send(new LoginUserRequest()
            {
                AuthUser = authUser
            });
        }


        // GET: api/users/
        [HttpGet]
        [Authorize]
        public async Task<List<UserDto>> Get()
        {
            return await _mediator.Send(new GetAllUsersListRequest()
            {
                RequestUser = User,
            });
        }

        // GET: api/users/level/:level:/
        [HttpGet("level/{level}")]
        [Authorize]
        public async Task<List<UserDto>> GetByLevel(AccessLevel level)
        {
            return await _mediator.Send(new GetByLevelUsersListRequest()
            {
                RequestUser = User,
                Level = level
            });
        }

        // GET /api/users/group/:gid:/
        [HttpGet("group/{gid:int}")]
        [Authorize]
        public async Task<List<UserDto>> GetByGroup(int gid)
        {
            return await _mediator.Send(new GetByGroupUsersListRequest()
            {
                RequestUser = User,
                Gid = gid
            });
        }

        // GET /api/users/level/:level:/group/:gid:/
        [HttpGet("level/{level}/group/{gid:int}")]
        [Authorize]
        public async Task<List<UserDto>> GetByLevelAndGroup(AccessLevel level, int gid)
        {
            return await _mediator.Send(new GetByGroupAndLevelUsersListRequest()
            {
                RequestUser = User,
                Level = level,
                Gid = gid
            });
        }

        // GET /api/users/:uid:/
        [HttpGet("{uid:int}")]
        [Authorize]
        public async Task<UserDto> Get(int uid)
        {
            return await _mediator.Send(new GetUserDetailRequest()
            {
                RequestUser = User,
                Uid = uid
            });
        }

        // POST /api/users/
        [HttpPost]
        [Authorize]
        public async Task<UserDto> Post([FromBody] CreateUserDto createUserDto)
        {
            return await _mediator.Send(new CreateUserRequest()
            {
                RequestUser = User,
                CreateUserDto = createUserDto
            });
        }

        // PUT /api/users/:uid:/
        [HttpPut("{uid:int}")]
        [Authorize]
        public async Task<UserDto> Put(int uid, [FromBody] UpdateUserDto updateUserDto)
        {
            return await _mediator.Send(new UpdateUserRequest()
            {
                RequestUser = User,
                UpdateUserDto = updateUserDto
            });
        }

        // DELETE /api/users/:uid:/
        [HttpDelete("{uid:int}")]
        [Authorize]
        public async Task<Unit> Delete(int uid)
        {
            return await _mediator.Send(new DeleteUserRequest()
            {
                RequestUser = User,
                Uid = uid
            });
        }
    }
}