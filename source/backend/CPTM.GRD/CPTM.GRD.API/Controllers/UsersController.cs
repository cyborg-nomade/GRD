using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;
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
        public object Login([FromBody] AuthUser authUser)
        {
            return new object();
        }


        // GET: api/users/
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await _mediator.Send(new GetAllUsersListRequest());
        }

        // GET: api/users/level/:level:/
        [HttpGet("level/{level}")]
        public async Task<List<UserDto>> GetByLevel(AccessLevel level)
        {
            return await _mediator.Send(new GetByLevelUsersListRequest() { Level = level });
        }

        // GET /api/users/group/:gid:/
        [HttpGet("group/{gid:int}")]
        public async Task<List<UserDto>> GetByGroup(int gid)
        {
            return await _mediator.Send(new GetByGroupUsersListRequest() { Gid = gid });
        }

        // GET /api/users/level/:level:/group/:gid:/
        [HttpGet("level/{level}/group/{gid:int}")]
        public async Task<List<UserDto>> GetByLevelAndGroup(AccessLevel level, int gid)
        {
            return await _mediator.Send(new GetByGroupAndLevelUsersListRequest() { Level = level, Gid = gid });
        }

        // GET /api/users/:uid:/
        [HttpGet("{uid:int}")]
        public async Task<UserDto> Get(int uid)
        {
            return await _mediator.Send(new GetUserDetailRequest() { Uid = uid });
        }

        // POST /api/users/
        [HttpPost]
        public async Task<UserDto> Post([FromBody] CreateUserDto createUserDto)
        {
            return await _mediator.Send(new CreateUserRequest() { CreateUserDto = createUserDto });
        }

        // PUT /api/users/:uid:/
        [HttpPut("{uid:int}")]
        public async Task<UserDto> Put(int uid, [FromBody] UpdateUserDto updateUserDto)
        {
            return await _mediator.Send(new UpdateUserRequest() { UpdateUserDto = updateUserDto });
        }

        // DELETE /api/users/:uid:/
        [HttpDelete("{uid:int}")]
        public async Task<Unit> Delete(int uid)
        {
            return await _mediator.Send(new DeleteUserRequest() { Uid = uid });
        }
    }
}