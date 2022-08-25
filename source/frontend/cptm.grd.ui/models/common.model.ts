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

export const ObjetoProposicaoView: {
    label: string;
    value: ObjetoProposicao;
}[] = [
    { label: "Aditamento", value: ObjetoProposicao.Aditamento },
    { label: "Alienação Leilão", value: ObjetoProposicao.AlienacaoLeilao },
    {
        label: "Alteração Estrutura Org.",
        value: ObjetoProposicao.AlteracaoEstruturaOrg,
    },
    {
        label: "Aprovação Norma Geral",
        value: ObjetoProposicao.AprovacaoNormaGeral,
    },
    {
        label: "Aprovação Regulamento",
        value: ObjetoProposicao.AprovacaoRegulamento,
    },
    { label: "Aprovação Edital", value: ObjetoProposicao.AprovacaoEdital },
    { label: "Aprovação Política", value: ObjetoProposicao.AprovacaoPolitica },
    { label: "Ata Registro Preços", value: ObjetoProposicao.AtaRegistroPrecos },
    {
        label: "Atualização Revisão Normas",
        value: ObjetoProposicao.AtualizacaoRevisaoNormas,
    },
    { label: "Cancelamento RD", value: ObjetoProposicao.CancelamentoRd },
    { label: "Contratação", value: ObjetoProposicao.Contratacao },
    { label: "Contratação Direta", value: ObjetoProposicao.ContratacaoDireta },
    { label: "Convênio", value: ObjetoProposicao.Convenio },
    { label: "Dispensa Licitação", value: ObjetoProposicao.DispensaLicitacao },
    { label: "Homologação", value: ObjetoProposicao.Homologacao },
    { label: "Inexigibilidade", value: ObjetoProposicao.Inexigibilidade },
    {
        label: "Início Procedimentos Licit.",
        value: ObjetoProposicao.InicioProcedimentosLicit,
    },
    { label: "Outros", value: ObjetoProposicao.Outros },
    { label: "Prorrogação", value: ObjetoProposicao.Prorrogacao },
    { label: "Renovação TPU", value: ObjetoProposicao.RenovacaoTpu },
    { label: "Rati-Retificacao RD", value: ObjetoProposicao.RetiRetificacaoRd },
    { label: "Termo Permissão Uso", value: ObjetoProposicao.TermoPermissaoUso },
    { label: "Viagem Exterior", value: ObjetoProposicao.ViagemExterior },
];

export enum ReceitaDespesa {
    Receita,
    Despesa,
}

export const ReceitaDespesaView: { label: string; value: ReceitaDespesa }[] = [
    { label: "Receita", value: ReceitaDespesa.Receita },
    { label: "Despesa", value: ReceitaDespesa.Despesa },
];

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
