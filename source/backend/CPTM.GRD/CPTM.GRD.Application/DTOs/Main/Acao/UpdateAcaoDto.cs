using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.Main.Acao.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Acao;

public class UpdateAcaoDto : IBaseAcaoDto, IFullAcaoDto
{
    public int Id { get; set; }
    public TipoAcao Tipo { get; set; }
    public GroupDto DiretoriaRes { get; set; } = new GroupDto();
    public string Definicao { get; set; } = string.Empty;
    public TipoPeriodicidadeAcao Periodicidade { get; set; }
    public DateTime PrazoInicial { get; set; }
    public UserDto Responsavel { get; set; } = new UserDto();
    public string EmailDiretor { get; set; } = string.Empty;
    public string? NumeroContrato { get; set; }
    public string? Fornecedor { get; set; }
    public int PrazoProrrogadoDias { get; set; }
    public DateTime PrazoFinal { get; set; }
    public TipoAlertaVencimento AlertaVencimento { get; set; }
}