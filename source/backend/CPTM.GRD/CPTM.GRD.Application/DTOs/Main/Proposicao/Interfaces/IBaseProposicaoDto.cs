﻿using CPTM.GRD.Common;

namespace CPTM.GRD.Application.DTOs.Main.Proposicao.Interfaces;

public interface IBaseProposicaoDto
{
    public string Titulo { get; set; }
    public ObjetoProposicao Objeto { get; set; }
    public string DescricaoProposicao { get; set; }
    public bool PossuiParecerJuridico { get; set; }
    public string ResumoGeralResolucao { get; set; }
    public string ObservacoesCustos { get; set; }
    public string CompetenciasConformeNormas { get; set; }
    public DateTime DataBaseValor { get; set; }
    public string Moeda { get; set; }
    public float ValorOriginalContrato { get; set; }
    public float ValorTotalProposicao { get; set; }
    public ReceitaDespesa ReceitaDespesa { get; set; }
    public string NumeroContrato { get; set; }
    public string Termo { get; set; }
    public string Fornecedor { get; set; }
    public float ValorAtualContrato { get; set; }
    public string NumeroReservaVerba { get; set; }
    public float ValorReservaVerba { get; set; }
    public DateTime InicioVigenciaReserva { get; set; }
    public DateTime FimVigenciaReserva { get; set; }
    public string NumeroProposicao { get; set; }
    public string ProtocoloExpediente { get; set; }
    public string NumeroProcessoLicit { get; set; }
    public string? OutrasObservacoes { get; set; }
    public string? NumeroConselho { get; set; }
    public string SinteseProcessoFilePath { get; set; }
    public string NotaTecnicaFilePath { get; set; }
    public string PrdFilePath { get; set; }
    public string ParecerJuridicoFilePath { get; set; }
    public string TrFilePath { get; set; }
    public string RelatorioTecnicoFilePath { get; set; }
    public string PlanilhaQuantFilePath { get; set; }
    public string EditalFilePath { get; set; }
    public string ReservaVerbaFilePath { get; set; }
    public string ScFilePath { get; set; }
    public string RavFilePath { get; set; }
    public string CronogramaFisFinFilePath { get; set; }
    public string PcaFilePath { get; set; }
    public ICollection<string> OutrosFilePath { get; set; }
    public int? Seq { get; set; }
}