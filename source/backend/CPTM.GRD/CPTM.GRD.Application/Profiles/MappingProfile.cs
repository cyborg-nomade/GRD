using AutoMapper;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Logging;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Children;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Resolucao;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.DTOs.Main.Reuniao.Children;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Acoes.Children;
using CPTM.GRD.Domain.Logging;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Proposicoes.Children;
using CPTM.GRD.Domain.Reunioes;
using CPTM.GRD.Domain.Reunioes.Children;

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