using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Domain;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class CreateAcaoRequestHandler : IRequestHandler<CreateAcaoRequest, AcaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IMapper _mapper;

    public CreateAcaoRequestHandler(IReuniaoRepository reuniaoRepository,
        IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(CreateAcaoRequest request, CancellationToken cancellationToken)
    {
        var acao = _mapper.Map<Acao>(request.CreateAcaoDto);
        var reuniao = await _reuniaoRepository.Get(request.Rid);

        reuniao.AddAcao(acao);

        await _reuniaoRepository.Update(reuniao);

        return _mapper.Map<AcaoDto>(acao);
    }
}