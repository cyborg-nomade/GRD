﻿using CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;
using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao;

public class UpdateProposicaoDto : IBaseProposicaoDto, IFullProposicaoDto
{
    public int Id { get; set; }
    public int IdPrd { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public ObjetoProposicao Objeto { get; set; }
    public string DescricaoProposicao { get; set; } = string.Empty;
    public bool PossuiParecerJuridico { get; set; }
    public string ResumoGeralResolucao { get; set; } = string.Empty;
    public string ObservacoesCustos { get; set; } = string.Empty;
    public string CompetenciasConformeNormas { get; set; } = string.Empty;
    public DateOnly DataBaseValor { get; set; }
    public string Moeda { get; set; } = string.Empty;
    public float ValorOriginalContrato { get; set; }
    public float ValorTotalProposicao { get; set; }
    public ReceitaDespesa ReceitaDespesa { get; set; }
    public string NumeroContrato { get; set; } = string.Empty;
    public string Termo { get; set; } = string.Empty;
    public string Fornecedor { get; set; } = string.Empty;
    public float ValorAtualContrato { get; set; }
    public string NumeroReservaVerba { get; set; } = string.Empty;
    public float ValorReservaVerba { get; set; }
    public DateOnly InicioVigenciaReserva { get; set; }
    public DateOnly FimVigenciaReserva { get; set; }
    public string NumeroProposicao { get; set; } = string.Empty;
    public string ProtoloExpediente { get; set; } = string.Empty;
    public string NumeroProcessoLicit { get; set; } = string.Empty;
    public string? OutrasObservacoes { get; set; }
    public string? NumeroConselho { get; set; }
    public string SinteseProcessoFilePath { get; set; } = string.Empty;
    public string NotaTecnicaFilePath { get; set; } = string.Empty;
    public string PrdFilePath { get; set; } = string.Empty;
    public string ParecerJuridicoFilePath { get; set; } = string.Empty;
    public string TrFilePath { get; set; } = string.Empty;
    public string RelatorioTecnicoFilePath { get; set; } = string.Empty;
    public string PlanilhaQuantFilePath { get; set; } = string.Empty;
    public string EditalFilePath { get; set; } = string.Empty;
    public string ReservaVerbaFilePath { get; set; } = string.Empty;
    public string ScFilePath { get; set; } = string.Empty;
    public string RavFilePath { get; set; } = string.Empty;
    public string CronogramaFisFinFilePath { get; set; } = string.Empty;
    public string PcaFilePath { get; set; } = string.Empty;
    public ICollection<string> OutrosFilePath { get; set; } = new HashSet<string>();
    public int? Seq { get; set; }
}