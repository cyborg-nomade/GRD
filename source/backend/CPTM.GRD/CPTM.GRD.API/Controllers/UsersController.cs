using CPTM.GRD.Application.DTOs.AccessControl.User;
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
        public IEnumerable<UserDto> Get()
        {
            return new List<UserDto>();
        }

        // GET: api/users/level/:level:/
        [HttpGet("level/{level}")]
        public IEnumerable<UserDto> GetByLevel(AccessLevel level)
        {
            return new List<UserDto>();
        }

        // GET /api/users/group/:gid:/
        [HttpGet("group/{gid:int}")]
        public IEnumerable<UserDto> GetByGroup(int gid)
        {
            return new List<UserDto>();
        }

        // GET /api/users/level/:level:/group/:gid:/
        [HttpGet("level/{level}/group/{gid:int}")]
        public IEnumerable<UserDto> GetByLevelAndGroup(AccessLevel level, int gid)
        {
            return new List<UserDto>();
        }

        // GET /api/users/:uid:/
        [HttpGet("{uid:int}")]
        public UserDto Get(int uid)
        {
            return new UserDto();
        }

        // POST /api/users/
        [HttpPost]
        public UserDto Post([FromBody] CreateUserDto createUserDto)
        {
            return new UserDto();
        }

        // PUT /api/users/:uid:/
        [HttpPut("{uid:int}")]
        public UserDto Put(int uid, [FromBody] UpdateUserDto updateUserDto)
        {
            return new UserDto();
        }

        // DELETE /api/users/:uid:/
        [HttpDelete("{uid:int}")]
        public UserDto Delete(int uid)
        {
            return new UserDto();
        }
    }
}