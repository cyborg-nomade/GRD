using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Contracts.Persistence.Reunioes;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.Features.Acoes.Requests.Commands;
using CPTM.GRD.Domain.Acoes;
using MediatR;

namespace CPTM.GRD.Application.Features.Acoes.Handlers.Commands;

public class CreateAcaoRequestHandler : IRequestHandler<CreateAcaoRequest, AcaoDto>
{
    private readonly IReuniaoRepository _reuniaoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateAcaoRequestHandler(IReuniaoRepository reuniaoRepository, IUserRepository userRepository,
        IMapper mapper)
    {
        _reuniaoRepository = reuniaoRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<AcaoDto> Handle(CreateAcaoRequest request, CancellationToken cancellationToken)
    {
        var acao = _mapper.Map<Acao>(request.CreateAcaoDto);
        var reuniao = await _reuniaoRepository.Get(request.Rid);
        var responsavel = await _userRepository.Get(request.Uid);

        reuniao.CreateAcao(acao, responsavel);

        await _reuniaoRepository.Update(reuniao);

        return _mapper.Map<AcaoDto>(acao);
    }
}