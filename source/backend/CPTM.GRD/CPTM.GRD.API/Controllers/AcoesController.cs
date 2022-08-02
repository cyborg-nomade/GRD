using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Children;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPTM.GRD.API.Controllers
{
    [Route("api/acoes")]
    [ApiController]
    [Authorize]
    public class AcoesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AcoesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/acoes
        [HttpGet]
        public async Task<List<AcaoListDto>> Get()
        {
            return await _mediator.Send(new GetAllAcoesListRequest());
        }

        // GET /api/acoes/reuniao/:rid:/
        [HttpGet("reuniao/{rid:int}")]
        public async Task<List<AcaoListDto>> GetByReuniao(int rid)
        {
            return await _mediator.Send(new GetByReuniaoAcoesListRequest() { Rid = rid });
        }

        // GET api/acoes/:aid:/
        [HttpGet("{aid:int}")]
        public async Task<AcaoDto> Get(int aid)
        {
            return await _mediator.Send(new GetAcaoDetailRequest() { Aid = aid });
        }

        // POST api/acoes/reuniao/:rid:/
        [HttpPost("reuniao/{rid:int}")]
        public async Task<AcaoDto> Post(int rid, [FromBody] CreateAcaoDto createAcaoDto)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new CreateAcaoRequest()
            {
                CreateAcaoDto = createAcaoDto,
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // PUT api/acoes/:aid:
        [HttpPut("{aid:int}")]
        public async Task<AcaoDto> Put(int aid, [FromBody] UpdateAcaoDto updateAcaoDto)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new UpdateAcaoRequest()
            {
                Aid = aid,
                UpdateAcaoDto = updateAcaoDto,
                Uid = responsavel.Id
            });
        }

        // POST /api/acoes/:aid:/add-andamento
        [HttpPost("{aid:int}/add-andamento")]
        public async Task<AcaoDto> AddAndamento(int aid, [FromBody] AndamentoDto andamentoDto)
        {
            return await _mediator.Send(new AddAndamentoToAcaoRequest()
            {
                Aid = aid,
                AndamentoDto = andamentoDto
            });
        }

        // PUT /api/acoes/:aid:/reuniao/:rid/add
        [HttpPut("{aid:int}/reuniao/{rid:int}/add")]
        public async Task<AddAcaoToReuniaoDto> FollowUp(int aid, int rid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new FollowUpAcaoRequest()
            {
                Aid = aid,
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // PUT /api/acoes/:aid:/finish/:status:/
        [HttpPut("{aid:int}/finish/{status}")]
        public async Task<AcaoDto> Finish(int aid, AcaoStatus status)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new FinishAcaoRequest()
            {
                Aid = aid,
                Status = status,
                Uid = responsavel.Id
            });
        }

        // DELETE /api/acoes/:aid:/
        [HttpDelete("{aid:int}")]
        public async Task<Unit> Delete(int aid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new DeleteAcaoRequest()
            {
                Aid = aid,
                Uid = responsavel.Id
            });
        }
    }
}