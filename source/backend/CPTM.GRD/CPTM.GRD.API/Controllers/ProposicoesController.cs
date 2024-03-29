﻿using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Commands;
using CPTM.GRD.Application.Features.Proposicoes.Requests.Queries;
using CPTM.GRD.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CPTM.GRD.API.Controllers
{
    [Route("api/proposicoes")]
    [ApiController]
    [Authorize]
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
            return await _mediator.Send(new GetAllProposicoesListRequest()
            {
                RequestUser = User,
            });
        }

        // GET /api/proposicoes/user/:uid:/
        [HttpGet("user/{uid:int}")]
        public async Task<List<ProposicaoListDto>> GetByUser(int uid)
        {
            return await _mediator.Send(new GetByUserProposicoesListRequest()
            {
                RequestUser = User,
                Uid = uid
            });
        }

        // GET /api/proposicoes/group/:gid:/
        [HttpGet("group/{gid:int}")]
        public async Task<List<ProposicaoListDto>> GetByGroup(int gid)
        {
            return await _mediator.Send(new GetByGroupProposicoesListRequest()
            {
                RequestUser = User,
                Gid = gid
            });
        }

        // GET /api/proposicoes/status/:status:/:arquivada:
        [HttpGet("status/{status}/{arquivada:bool}")]
        public async Task<List<ProposicaoListDto>> GetByStatus(ProposicaoStatus status, bool arquivada)
        {
            return await _mediator.Send(new GetByStatusProposicoesListRequest()
            {
                RequestUser = User,
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
                RequestUser = User,
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
                RequestUser = User,
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
                RequestUser = User,
                Rid = rid
            });
        }

        // GET /api/proposicoes/reuniao/:rid:/previa/
        [HttpGet("reuniao/{rid:int}/previa/")]
        public async Task<List<ProposicaoListDto>> GetByReuniaoPrevia(int rid)
        {
            return await _mediator.Send(new GetByReuniaoPreviaProposicoesListRequest()
            {
                RequestUser = User,
                Rid = rid
            });
        }

        // GET /api/proposicoes/:pid:/
        [HttpGet("{pid:int}")]
        public async Task<ProposicaoDto> Get(int pid)
        {
            return await _mediator.Send(new GetProposicaoDetailRequest()
            {
                RequestUser = User,
                Pid = pid
            });
        }

        // POST /api/proposicoes/
        [HttpPost]
        public async Task<ProposicaoDto> Post([FromBody] CreateProposicaoDto createProposicaoDto)
        {
            return await _mediator.Send(new CreateProposicaoRequest()
            {
                RequestUser = User,
                CreateProposicaoDto = createProposicaoDto
            });
        }

        // PUT /api/proposicoes/:pid:/
        [HttpPut("{pid:int}")]
        public async Task<ProposicaoDto> Put(int pid, [FromBody] UpdateProposicaoDto updateProposicaoDto)
        {
            return await _mediator.Send(new UpdateProposicaoRequest()
            {
                RequestUser = User,
                Pid = pid,
                UpdateProposicaoDto = updateProposicaoDto
            });
        }

        // PUT /api/proposicoes/:pid:/send-diretoria-approval/
        [HttpPut("{pid:int}/send-diretoria-approval")]
        public async Task<ProposicaoDto> SendDiretoriaApproval(int pid)
        {
            return await _mediator.Send(new SendToDiretoriaProposicaoRequest()
            {
                RequestUser = User,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/diretoria-approve/
        [HttpPut("{pid:int}/diretoria-approve")]
        public async Task<ProposicaoDto> DiretoriaApprove(int pid)
        {
            return await _mediator.Send(new DiretoriaResponsavelApproveProposicaoRequest()
            {
                RequestUser = User,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/diretoria-repprove/
        [HttpPut("{pid:int}/diretoria-repprove")]
        public async Task<ProposicaoDto> DiretoriaRepprove(int pid, [FromBody] string motivoReprovacao)
        {
            return await _mediator.Send(new DiretoriaResponsavelRepproveProposicaoRequest()
            {
                RequestUser = User,
                MotivoReprovacao = motivoReprovacao,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/return-to-diretoria/
        [HttpPut("{pid:int}/return-to-diretoria")]
        public async Task<ProposicaoDto> ReturnToDiretoria(int pid, [FromBody] string motivoReprovacao)
        {
            return await _mediator.Send(new GrgReturnToDiretoriaProposicaoRequest()
            {
                RequestUser = User,
                MotivoReprovacao = motivoReprovacao,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/return-to-grg/
        [HttpPut("{pid:int}/return-to-grg")]
        public async Task<ProposicaoDto> ReturnToGrg(int pid)
        {
            return await _mediator.Send(new DiretoriaReturnToGrgAfterAjustesRdProposicaoRequest()
            {
                RequestUser = User,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/fixes-done/
        [HttpPut("{pid:int}/fixes-done")]
        public async Task<ProposicaoDto> FixesDone(int pid)
        {
            return await _mediator.Send(new GrgApproveAjustesRdProposicaoRequest()
            {
                RequestUser = User,
                Pid = pid
            });
        }

        // PUT /api/proposicoes/:pid:/rd-deliberate/
        [HttpPut("{pid:int}/rd-deliberate")]
        public async Task<ProposicaoDto> RdDeliberateDiretor(int pid,
            [FromBody] List<VoteWithAjustesProposicaoDto> votesWithAjustes)
        {
            return await _mediator.Send(new AddDiretorVoteToProposicaoRequest()
            {
                RequestUser = User,
                Pid = pid,
                VotesWithAjustes = votesWithAjustes
            });
        }

        // PUT /api/proposicoes/:pid:/annotate-previa/
        [HttpPut("{pid:int}/annotate-previa")]
        public async Task<ProposicaoDto> AnnotatePrevia(int pid, [FromBody] string annotation)
        {
            return await _mediator.Send(new AnnotateInPreviaProposicaoRequest()
            {
                RequestUser = User,
                Anotacao = annotation,
                Pid = pid
            });
        }

        // DELETE /api/proposicoes/:pid:/
        [HttpDelete("{pid:int}")]
        public async Task<Unit> Delete(int pid)
        {
            return await _mediator.Send(new DeleteProposicaoRequest()
            {
                RequestUser = User,
                Pid = pid
            });
        }
    }
}