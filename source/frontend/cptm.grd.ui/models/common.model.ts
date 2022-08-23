export enum AccessLevel {
    ResponsavelAcao,
    Sub,
    Gerente,
    AssessorDiretoria,
    Diretor,
    Grg,
    SysAdmin,
}

export enum AndamentoStatus {
    Ativo,
    Inativo,
}

export enum AcaoStatus {
    EmAndamento,
    EmAcompanhamento,
    Concluida,
    EncerradaSemConclusao,
}

export enum TipoAcao {
    Acao,
    Comentario,
    Definicao,
    ParecerTecnico,
    OutrosAssuntos,
}

export enum TipoPeriodicidadeAcao {
    Data,
    Semanal,
    Mensal,
}

export enum TipoAlertaVencimento {
    NoPrazo,
    UmDiaVencimento,
    Atrasado,
}

export enum TipoVotoRd {
    Aprovacao,
    Reprovacao,
    Suspensao,
    Abstencao,
}

export enum ProposicaoStatus {
    EmPreenchimento,
    EmAprovacaoDiretoriaResp,
    ReprovadoDiretoriaResp,
    DisponivelInclusaoPauta,
    RetornadoPelaGrgADiretoriaResp,
    InclusaEmReuniao,
    EmPautaPrevia,
    EmPautaDefinitiva,
    AprovadaRd,
    ReprovadaRd,
    SuspensaRd,
    AprovadaRdAguardandoAjustes,
    SuspensaRdAguardandoAjustes,
    AprovadaRdAjustesRealizados,
    SuspensaRdAjustesRealizados,
}

export enum ObjetoProposicao {
    Aditamento,
    AlienacaoLeilao,
    AlteracaoEstruturaOrg,
    AprovacaoNormaGeral,
    AprovacaoRegulamento,
    AprovacaoEdital,
    AprovacaoPolitica,
    AtaRegistroPrecos,
    AtualizacaoRevisaoNormas,
    CancelamentoRd,
    Contratacao,
    ContratacaoDireta,
    Convenio,
    DispensaLicitacao,
    Homologacao,
    Inexigibilidade,
    InicioProcedimentosLicit,
    Outros,
    Prorrogacao,
    RenovacaoTpu,
    RetiRetificacaoRd,
    TermoPermissaoUso,
    ViagemExterior,
}

export enum ReceitaDespesa {
    Receita,
    Despesa,
}

export enum ReuniaoStatus {
    EmCriacao,
    Registrada,
    Previa,
    Pauta,
    Realizada,
    Arquivada,
}

export enum TipoReuniao {
    Ordinaria,
    Extraordinaria,
}
