using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using CPTM.GRD.Application.Responses;
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
            return await _mediator.Send(new GetAllGroupsListRequest()
            {
                RequestUser = User
            });
        }

        // GET api/groups/user/:uid:/

        [HttpGet("user/{uid:int}")]
        public async Task<List<GroupDto>> GetByUser(int uid)
        {
            return await _mediator.Send(new GetByUserGroupsListRequest()
            {
                RequestUser = User,
                Uid = uid
            });
        }

        // GET api/groups/:gid:
        [HttpGet("{gid:int}")]
        public async Task<GroupDto> Get(int gid)
        {
            return await _mediator.Send(new GetGroupDetailRequest()
            {
                RequestUser = User,
                Gid = gid
            });
        }

        // GET /api/groups/estrutura
        [HttpGet("estrutura")]
        public async Task<EstruturaResponse> GetEstrutura()
        {
            return await _mediator.Send(new GetEstruturaRequest());
        }
    }
}