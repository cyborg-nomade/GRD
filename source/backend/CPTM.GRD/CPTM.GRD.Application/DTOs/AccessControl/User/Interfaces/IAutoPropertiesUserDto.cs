using CPTM.GRD.Application.DTOs.Main.Reuniao;

namespace CPTM.GRD.Application.DTOs.AccessControl.User.Interfaces;

public interface IAutoPropertiesUserDto
{
    public IEnumerable<ReuniaoDto>? Reunioes { get; set; }
    public IEnumerable<ReuniaoDto>? Previas { get; set; }
}