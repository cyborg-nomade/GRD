using AutoMapper;
using CPTM.GRD.Application.DTOs;
using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.DTOs.Lists;
using CPTM.GRD.Application.DTOs.Logging;
using CPTM.GRD.Domain;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Logging;

namespace CPTM.GRD.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Acao, AcaoDto>().ReverseMap();
        CreateMap<Andamento, AndamentoDto>().ReverseMap();
        CreateMap<Participante, ParticipanteDto>().ReverseMap();
        CreateMap<Proposicao, ProposicaoDto>().ReverseMap();
        CreateMap<Resolucao, ResolucaoDto>().ReverseMap();
        CreateMap<Reuniao, ReuniaoDto>().ReverseMap();

        CreateMap<Group, GroupDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<LogAcao, LogAcaoDto>().ReverseMap();
        CreateMap<LogProposicao, LogProposicaoDto>().ReverseMap();
        CreateMap<LogReuniao, LogReuniaoDto>().ReverseMap();

        CreateMap<Acao, AcaoListDto>().ReverseMap();
        CreateMap<Proposicao, ProposicaoListDto>().ReverseMap();
        CreateMap<Reuniao, ReuniaoListDto>().ReverseMap();
    }
}