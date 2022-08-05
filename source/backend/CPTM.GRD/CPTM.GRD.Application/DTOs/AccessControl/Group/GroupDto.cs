using CPTM.GRD.Application.DTOs.AccessControl.Group.Interfaces;

namespace CPTM.GRD.Application.DTOs.AccessControl.Group;

public class GroupDto : IGroupDto
{
    public int Id { get; set; }
    public string Sigla { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string SiglaGerencia { get; set; } = string.Empty;
    public string Gerencia { get; set; } = string.Empty;
    public string SiglaDiretoria { get; set; } = string.Empty;
    public string Diretoria { get; set; } = string.Empty;

    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id},\n{nameof(Sigla)}: {Sigla},\n{nameof(Nome)}: {Nome},\n{nameof(SiglaGerencia)}: {SiglaGerencia},\n{nameof(Gerencia)}: {Gerencia},\n{nameof(SiglaDiretoria)}: {SiglaDiretoria},\n{nameof(Diretoria)}: {Diretoria}";
    }
}