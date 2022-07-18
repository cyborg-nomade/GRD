﻿using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.Acoes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Queries;

public class GetByReuniaoAcoesListRequestHandler : IRequestHandler<GetByReuniaoAcoesListRequest, List<AcaoListDto>>
{
    private readonly IAcaoRepository _acaoRepository;
    private readonly IMapper _mapper;

    public GetByReuniaoAcoesListRequestHandler(IAcaoRepository acaoRepository, IMapper mapper)
    {
        _acaoRepository = acaoRepository;
        _mapper = mapper;
    }

    public async Task<List<AcaoListDto>> Handle(GetByReuniaoAcoesListRequest request,
        CancellationToken cancellationToken)
    {
        var acoes = await _acaoRepository.GetByReuniao(request.Rid);
        return _mapper.Map<List<AcaoListDto>>(acoes);
    }
}