using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPTM.GRD.API.Controllers
{
    [Route("api/groups")]
    [ApiController]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/groups
        [HttpGet]
        public async Task<List<GroupDto>> Get()
        {
            return await _mediator.Send(new GetAllGroupsListRequest());
        }

        // GET api/groups/user/:uid:/

        [HttpGet("user/{uid:int}")]
        public async Task<List<GroupDto>> GetByUser(int uid)
        {
            return await _mediator.Send(new GetByUserGroupsListRequest() { Uid = uid });
        }

        // GET api/groups/:gid:
        [HttpGet("{gid:int}")]
        public async Task<GroupDto> Get(int gid)
        {
            return await _mediator.Send(new GetGroupDetailRequest() { Gid = gid });
        }
    }
}