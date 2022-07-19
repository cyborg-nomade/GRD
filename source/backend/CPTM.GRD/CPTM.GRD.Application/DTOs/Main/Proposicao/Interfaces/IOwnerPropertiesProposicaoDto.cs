using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;

public interface IOwnerPropertiesProposicaoDto
{
    public UserDto Criador { get; set; }
    public GroupDto AreaSolicitante { get; set; }
}