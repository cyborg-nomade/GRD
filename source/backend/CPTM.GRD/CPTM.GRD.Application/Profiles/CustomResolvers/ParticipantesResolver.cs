using AutoMapper;
using CPTM.GRD.Application.DTOs.Main.Reuniao;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Application.Profiles.CustomResolvers;

public class ParticipantesResolver : IValueResolver<Reuniao, ReuniaoDto, ICollection<int>>
{
    public ICollection<int> Resolve(Reuniao source, ReuniaoDto destination, ICollection<int> destMember,
        ResolutionContext context)
    {
        return (source.Participantes ?? throw new InvalidOperationException()).Select(p => p.Id).ToList();
    }
}