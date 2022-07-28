using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPTM.GRD.API.Controllers
{
    [Route("api/proposicoes")]
    [ApiController]
    public class ProposicoesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProposicoesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET /api/proposicoes/
        [HttpGet]
        public async Task<List<ProposicaoListDto>> Get()
        {
            return await _mediator.Send(new GetAllProposicoesListRequest());
        }

        // GET /api/proposicoes/user/:uid:/
        [HttpGet("user/{uid::int}")]
        public async Task<List<ProposicaoListDto>> GetByUser(int uid)
        {
            return await _mediator.Send(new GetByUserProposicoesListRequest()
            {
                Uid = uid
            });
        }

        // GET /api/proposicoes/group/:gid:/
        [HttpGet("group/{gid:int}")]
        public async Task<List<ProposicaoListDto>> GetByGroup(int gid)
        {
            return await _mediator.Send(new GetByGroupProposicoesListRequest()
            {
                Gid = gid
            });
        }

        // GET /api/proposicoes/status/:status:/:arquivada:
        [HttpGet("status/{status}/{arquivada:bool}")]
        public async Task<List<ProposicaoListDto>> GetByStatus(ProposicaoStatus status, bool arquivada)
        {
            return await _mediator.Send(new GetByStatusProposicoesListRequest()
            {
                Arquivada = arquivada,
                Status = status
            });
        }

        // GET /api/proposicoes/user/:uid:/status/:status:/:arquivada:/
        [HttpGet("user/{uid:int}/status/{status}/{arquivada:bool}")]
        public async Task<List<ProposicaoListDto>> GetByUserAndStatus(int uid, ProposicaoStatus status, bool arquivada)
        {
            return await _mediator.Send(new GetByUserAndStatusProposicoesListRequest()
            {
                Arquivada = arquivada,
                Status = status,
                Uid = uid
            });
        }

        // GET /api/proposicoes/group/:gid:/status/:status:/:arquivada:/
        [HttpGet("group/{gid:int}/status/{status}/{arquivada:bool}")]
        public async Task<List<ProposicaoListDto>> GetByGroupAndStatus(int gid, ProposicaoStatus status, bool arquivada)
        {
            return await _mediator.Send(new GetByGroupAndStatusProposicoesListRequest()
            {
                Arquivada = arquivada,
                Status = status,
                Gid = gid
            });
        }

        // GET /api/proposicoes/reuniao/:rid:/
        [HttpGet("reuniao/{rid:int}")]
        public async Task<List<ProposicaoListDto>> GetByReuniao(int rid)
        {
            return await _mediator.Send(new GetByReuniaoProposicoesListRequest()
            {
                Rid = rid
            });
        }

        // GET /api/proposicoes/reuniao/:rid:/previa/
        [HttpGet("reuniao/{rid:int}/previa/")]
        public async Task<List<ProposicaoListDto>> GetByReuniaoPrevia(int rid)
        {
            return await _mediator.Send(new GetByReuniaoPreviaProposicoesListRequest()
            {
                Rid = rid
            });
        }

        // GET /api/proposicoes/:pid:/
        [HttpGet("{pid:int}")]
        public async Task<ProposicaoDto> Get(int pid)
        {
            return await _mediator.Send(new GetProposicaoDetailRequest()
            {
                Pid = pid
            });
        }

        // POST /api/proposicoes/
        [HttpPost]
        public async Task<ProposicaoDto> Post([FromBody] CreateProposicaoDto createProposicaoDto)
        {
            return await _mediator.Send(new CreateProposicaoRequest()
            {
                CreateProposicaoDto = createProposicaoDto
            });
        }

        // PUT /api/proposicoes/:pid:/
        [HttpPut("{pid:int}")]
        public async Task<ProposicaoDto> Put(int pid, [FromBody] UpdateProposicaoDto updateProposicaoDto)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new UpdateProposicaoRequest()
            {
                Pid = pid,
                Uid = responsavel.Id,
                UpdateProposicaoDto = updateProposicaoDto
            });
        }

        // PUT /api/proposicoes/:pid:/send-diretoria-approval/
        [HttpPut("{pid:int}/send-diretoria-approval")]
        public async Task<ProposicaoDto> SendDiretoriaApproval(int pid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new SendToDiretoriaProposicaoRequest()
            {
                Pid = pid,
                Uid = responsavel.Id
            });
        }

        // PUT /api/proposicoes/:pid:/diretoria-approve/
        [HttpPut("{pid:int}/diretoria-approve")]
        public async Task<ProposicaoDto> DiretoriaApprove(int pid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new DiretoriaResponsavelApproveProposicaoRequest()
            {
                Pid = pid,
                Uid = responsavel.Id
            });
        }

        // PUT /api/proposicoes/:pid:/diretoria-repprove/
        [HttpPut("{pid:int}/diretoria-repprove")]
        public async Task<ProposicaoDto> DiretoriaRepprove(int pid, [FromBody] string motivoReprovacao)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new DiretoriaResponsavelRepproveProposicaoRequest()
            {
                Uid = responsavel.Id,
                MotivoReprovacao = motivoReprovacao,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/return-to-diretoria/
        [HttpPut("{pid:int}/return-to-diretoria")]
        public async Task<ProposicaoDto> ReturnToDiretoria(int pid, [FromBody] string motivoReprovacao)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new GrgReturnToDiretoriaProposicaoRequest()
            {
                Uid = responsavel.Id,
                MotivoReprovacao = motivoReprovacao,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/return-to-grg/
        [HttpPut("{pid:int}/return-to-grg")]
        public async Task<ProposicaoDto> ReturnToGrg(int pid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new DiretoriaReturnToGrgAfterAjustesRdProposicaoRequest()
            {
                Pid = pid,
                Uid = responsavel.Id
            });
        }

        // PUT /api/proposicoes/:pid:/fixes-done/
        [HttpPut("{pid:int}/fixes-done")]
        public async Task<ProposicaoDto> FixesDone(int pid)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new GrgApproveAjustesRdProposicaoRequest()
            {
                Pid = pid,
                Uid = responsavel.Id
            });
        }

        // PUT /api/proposicoes/:pid:/rd-deliberate/
        [HttpPut("{pid:int}/rd-deliberate")]
        public async Task<ProposicaoDto> RdDeliberateDiretor(int pid,
            [FromBody] List<VoteWithAjustesProposicaoDto> voteWithAjustes)
        {
            return await _mediator.Send(new AddDiretorVoteToProposicaoRequest()
            {
                Pid = pid,
                VotesWithAjustes = voteWithAjustes
            });
        }

        // PUT /api/proposicoes/:pid:/annotate-previa/
        [HttpPut("{pid:int}/annotate-previa")]
        public async Task<ProposicaoDto> AnnotatePrevia(int pid, [FromBody] string annotation)
        {
            var responsavel = new UserDto();
            return await _mediator.Send(new AnnotateInPreviaProposicaoRequest()
            {
                Anotacao = annotation,
                Pid = pid,
                Uid = responsavel.Id
            });
        }

        // DELETE /api/proposicoes/:pid:/
        [HttpDelete("{pid:int}")]
        public async Task<Unit> Delete(int pid)
        {
            return await _mediator.Send(new DeleteProposicaoRequest()
            {
                Pid = pid
            });
        }
    }
}