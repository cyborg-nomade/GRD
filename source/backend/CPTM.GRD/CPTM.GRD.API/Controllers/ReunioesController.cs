using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Mixed;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Features.Reunioes.Requests.Commands;
using CPTM.GRD.Application.Features.Reunioes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPTM.GRD.API.Controllers
{
    [Route("api/reunioes")]
    [ApiController]
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
            return await _mediator.Send(new GetAllReunioesListRequest());
        }

        // GET /api/reunioes/status/:status:/
        [HttpGet("status/{status}")]
        public async Task<List<ReuniaoListDto>> GetByStatus(ReuniaoStatus status)
        {
            return await _mediator.Send(new GetByStatusReunioesListRequest()
            {
                Status = status
            });
        }

        // GET /api/reunioes/:rid:/
        [HttpGet("{rid:int}")]
        public async Task<ReuniaoDto> Get(int rid)
        {
            return await _mediator.Send(new GetReuniaoDetailRequest());
        }

        // GET /api/reunioes/:rid:/pauta-previa/
        [HttpGet("{rid:int}/pauta-previa")]
        public async Task<ReuniaoDto> GetPautaPreviaFile(int rid)
        {
            return await _mediator.Send(new CreatePautaPreviaReuniaoRequest());
        }

        // GET /api/reunioes/:rid:/memoria-previa/
        [HttpGet("{rid:int}/memoria-previa")]
        public async Task<ReuniaoDto> GetMemoriaPreviaFile(int rid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new CreateMemoriaPreviaReuniaoRequest()
            {
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // GET /api/reunioes/:rid:/pauta-definitiva/
        [HttpGet("{rid:int}/pauta-definitiva")]
        public async Task<ReuniaoDto> GetPautaDefinitivaFile(int rid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new CreatePautaDefinitivaReuniaoRequest()
            {
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // GET /api/reunioes/:rid:/relatorio-deliberativo/
        [HttpGet("{rid:int}/relatorio-deliberativo")]
        public async Task<ReuniaoDto> GetRelatorioDeliberativoFile(int rid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new CreateRelatorioDeliberativoReuniaoRequest()
            {
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // GET /api/reunioes/:rid:/proposicao/:pid:/resolucao-diretoria/
        [HttpGet("{rid:int}/proposicao/{pid:int}/resolucao-diretoria")]
        public async Task<ProposicaoDto> GetResolucaoDiretoriaFile(int rid, int pid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new CreateResolucaoDiretoriaProposicaoReuniaoRequest()
            {
                Pid = pid,
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // GET /api/reunioes/:rid:/ata
        [HttpGet("{rid:int}/ata")]
        public async Task<ReuniaoDto> GetAtaFile(int rid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new CreateAtaReuniaoRequest()
            {
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // POST /api/reunioes/
        [HttpPost]
        public async Task<ReuniaoDto> Post([FromBody] CreateReuniaoDto createReuniaoDto)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new CreateReuniaoRequest()
            {
                CreateReuniaoDto = createReuniaoDto,
                Uid = responsavel.Id
            });
        }

        // PUT /api/reunioes/:rid:/
        [HttpPut("{rid:int}")]
        public async Task<ReuniaoDto> Put(int rid, [FromBody] UpdateReuniaoDto updateReuniaoDto)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new UpdateReuniaoRequest()
            {
                Rid = rid,
                UpdateReuniaoDto = updateReuniaoDto,
                Uid = responsavel.Id
            });
        }

        // PUT /api/reunioes/:rid:/proposicao/:pid:/add
        [HttpPut("{rid:int}/proposicao/{pid:int}/add")]
        public async Task<AddProposicaoToReuniaoDto> AddProposicao(int rid, int pid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new AddProposicaoToReuniaoRequest()
            {
                Pid = pid,
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // DELETE /api/reunioes/:rid:/proposicao/:pid:/
        [HttpDelete("{rid:int}/proposicao/{pid:int}")]
        public async Task<AddProposicaoToReuniaoDto> RemoveProposicao(int rid, int pid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new RemoveProposicaoFromReuniaoRequest()
            {
                Pid = pid,
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // DELETE /api/reunioes/:rid:/acao/:aid
        [HttpDelete("{rid:int}/acao/{aid:int}")]
        public async Task<AddAcaoToReuniaoDto> RemoveAcao(int rid, int aid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new RemoveAcaoFromReuniaoRequest()
            {
                Aid = aid,
                Rid = rid,
                Uid = responsavel.Id
            });
        }

        // DELETE /api/reunioes/:rid:/
        [HttpDelete("{rid:int}")]
        public async Task<Unit> Delete(int rid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new DeleteReuniaoRequest()
            {
                Rid = rid,
                Uid = responsavel.Id
            });
        }
    }
}