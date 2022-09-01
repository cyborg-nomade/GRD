using AutoMapper;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Logging;
using CPTM.GRD.Application.DTOs.Main.Acao;
using CPTM.GRD.Application.DTOs.Main.Acao.Children;
using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Resolucao;
using CPTM.GRD.Application.DTOs.Main.Proposicao.Children.Voto;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Application.Profiles.CustomResolvers;
using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Acoes.Children;
using CPTM.GRD.Domain.Logging;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Proposicoes.Children;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region acaoDtos

        CreateMap<Acao, AcaoDto>().ReverseMap();
        CreateMap<Acao, CreateAcaoDto>().ReverseMap();
        CreateMap<Acao, UpdateAcaoDto>().ReverseMap();
        CreateMap<Andamento, AndamentoDto>().ReverseMap();
        CreateMap<Andamento, CreateAndamentoDto>().ReverseMap();

        #endregion

        #region proposicaoDtos

        CreateMap<Proposicao, ProposicaoDto>().ReverseMap();
        CreateMap<Proposicao, CreateProposicaoDto>().ReverseMap();
        CreateMap<Proposicao, UpdateProposicaoDto>().ReverseMap();
        CreateMap<Resolucao, ResolucaoDto>().ReverseMap();
        CreateMap<Voto, VotoDto>().ReverseMap();
        CreateMap<Voto, CreateVotoDto>().ReverseMap();

        #endregion

        #region reuniaoDtos

        CreateMap<Reuniao, ReuniaoDto>()
            .ForMember(r => r.ParticipantesIds,
                opt => opt.MapFrom<ParticipantesResolver>())
            .ForMember(r => r.ParticipantesPreviaIds,
                opt => opt.MapFrom<ParticipantesPreviaResolver>())
            .ReverseMap();
        CreateMap<Reuniao, CreateReuniaoDto>().ReverseMap();
        CreateMap<Reuniao, UpdateReuniaoDto>().ReverseMap();

        #endregion

        #region accessControlDtos

        CreateMap<Group, GroupDto>().ReverseMap();
        CreateMap<Group, CreateGroupDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();

        #endregion

        #region loggingDtos

        CreateMap<LogAcao, LogAcaoDto>().ReverseMap();
        CreateMap<LogProposicao, LogProposicaoDto>().ReverseMap();
        CreateMap<LogReuniao, LogReuniaoDto>().ReverseMap();

        #endregion

        #region listDtos

        CreateMap<Acao, AcaoListDto>().ReverseMap();
        CreateMap<Proposicao, ProposicaoListDto>().ReverseMap();
        CreateMap<Reuniao, ReuniaoListDto>().ReverseMap();

        #endregion
    }
}