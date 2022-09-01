using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPTM.GRD.API.Controllers
{
    [Route("api/reunioes")]
    [ApiController]
    [Authorize]
    public class ReunioesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReunioesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/reunioes/
        [HttpGet]
        public async Task<List<ReuniaoListDto>> Get()
        {
            return await _mediator.Send(new GetAllReunioesListRequest()
            {
                RequestUser = User
            });
        }

        // GET /api/reunioes/status/:status:/
        [HttpGet("status/{status}")]
        public async Task<List<ReuniaoListDto>> GetByStatus(ReuniaoStatus status)
        {
            return await _mediator.Send(new GetByStatusReunioesListRequest()
            {
                RequestUser = User,
                Status = status
            });
        }

        // GET /api/reunioes/:rid:/
        [HttpGet("{rid:int}")]
        public async Task<ReuniaoDto> Get(int rid)
        {
            return await _mediator.Send(new GetReuniaoDetailRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }

        // GET /api/reunioes/:rid:/pauta-previa/
        [HttpGet("{rid:int}/pauta-previa")]
        public async Task<ReuniaoDto> GetPautaPreviaFile(int rid)
        {
            return await _mediator.Send(new CreatePautaPreviaReuniaoRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }

        // GET /api/reunioes/:rid:/memoria-previa/
        [HttpGet("{rid:int}/memoria-previa")]
        public async Task<ReuniaoDto> GetMemoriaPreviaFile(int rid)
        {
            return await _mediator.Send(new CreateMemoriaPreviaReuniaoRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }

        // GET /api/reunioes/:rid:/pauta-definitiva/
        [HttpGet("{rid:int}/pauta-definitiva")]
        public async Task<ReuniaoDto> GetPautaDefinitivaFile(int rid)
        {
            return await _mediator.Send(new CreatePautaDefinitivaReuniaoRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }

        // GET /api/reunioes/:rid:/relatorio-deliberativo/
        [HttpGet("{rid:int}/relatorio-deliberativo")]
        public async Task<ReuniaoDto> GetRelatorioDeliberativoFile(int rid)
        {
            return await _mediator.Send(new CreateRelatorioDeliberativoReuniaoRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }

        // GET /api/reunioes/:rid:/proposicao/:pid:/resolucao-diretoria/
        [HttpGet("{rid:int}/proposicao/{pid:int}/resolucao-diretoria")]
        public async Task<ProposicaoDto> GetResolucaoDiretoriaFile(int rid, int pid)
        {
            return await _mediator.Send(new CreateResolucaoDiretoriaProposicaoReuniaoRequest()
            {
                RequestUser = User,
                Pid = pid,
                Rid = rid
            });
        }

        // GET /api/reunioes/:rid:/ata
        [HttpGet("{rid:int}/ata")]
        public async Task<ReuniaoDto> GetAtaFile(int rid)
        {
            return await _mediator.Send(new CreateAtaReuniaoRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }

        // POST /api/reunioes/
        [HttpPost]
        public async Task<ReuniaoDto> Post([FromBody] CreateReuniaoDto createReuniaoDto)
        {
            return await _mediator.Send(new CreateReuniaoRequest()
            {
                RequestUser = User,
                CreateReuniaoDto = createReuniaoDto
            });
        }

        // PUT /api/reunioes/:rid:/
        [HttpPut("{rid:int}")]
        public async Task<ReuniaoDto> Put(int rid, [FromBody] UpdateReuniaoDto updateReuniaoDto)
        {
            return await _mediator.Send(new UpdateReuniaoRequest()
            {
                RequestUser = User,
                Rid = rid,
                UpdateReuniaoDto = updateReuniaoDto
            });
        }

        // PUT /api/reunioes/:rid:/proposicao/:pid:/add
        [HttpPut("{rid:int}/proposicao/{pid:int}/add")]
        public async Task<AddProposicaoToReuniaoDto> AddProposicao(int rid, int pid)
        {
            return await _mediator.Send(new AddProposicaoToReuniaoRequest()
            {
                RequestUser = User,
                Pid = pid,
                Rid = rid
            });
        }

        // DELETE /api/reunioes/:rid:/proposicao/:pid:/
        [HttpDelete("{rid:int}/proposicao/{pid:int}")]
        public async Task<AddProposicaoToReuniaoDto> RemoveProposicao(int rid, int pid)
        {
            return await _mediator.Send(new RemoveProposicaoFromReuniaoRequest()
            {
                RequestUser = User,
                Pid = pid,
                Rid = rid
            });
        }

        // DELETE /api/reunioes/:rid:/acao/:aid
        [HttpDelete("{rid:int}/acao/{aid:int}")]
        public async Task<AddAcaoToReuniaoDto> RemoveAcao(int rid, int aid)
        {
            return await _mediator.Send(new RemoveAcaoFromReuniaoRequest()
            {
                RequestUser = User,
                Aid = aid,
                Rid = rid
            });
        }

        // DELETE /api/reunioes/:rid:/
        [HttpDelete("{rid:int}")]
        public async Task<Unit> Delete(int rid)
        {
            return await _mediator.Send(new DeleteReuniaoRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }
    }
}