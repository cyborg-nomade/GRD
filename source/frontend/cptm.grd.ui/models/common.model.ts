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

export const ProposicaoStatusView: {
    label: string;
    value: ProposicaoStatus;
}[] = [
    { label: "Em Preenchimento", value: ProposicaoStatus.EmPreenchimento },
    {
        label: "Em Aprovacao da Diretoria Responsável",
        value: ProposicaoStatus.EmAprovacaoDiretoriaResp,
    },
    {
        label: "Reprovado pela Diretoria Resp",
        value: ProposicaoStatus.ReprovadoDiretoriaResp,
    },
    {
        label: "Disponivel para Inclusão Pauta",
        value: ProposicaoStatus.DisponivelInclusaoPauta,
    },
    {
        label: "Retornado Pela GRG à Diretoria Resp",
        value: ProposicaoStatus.RetornadoPelaGrgADiretoriaResp,
    },
    {
        label: "Inclusa Em Reunião de Diretoria",
        value: ProposicaoStatus.InclusaEmReuniao,
    },
    { label: "Em Pauta Prévia", value: ProposicaoStatus.EmPautaPrevia },
    { label: "Em Pauta Definitiva", value: ProposicaoStatus.EmPautaDefinitiva },
    { label: "Aprovada em RD", value: ProposicaoStatus.AprovadaRd },
    { label: "Reprovada em RD", value: ProposicaoStatus.ReprovadaRd },
    { label: "Suspensa em RD", value: ProposicaoStatus.SuspensaRd },
    {
        label: "Aprovada RD - Aguardando Ajustes",
        value: ProposicaoStatus.AprovadaRdAguardandoAjustes,
    },
    {
        label: "Suspensa RD - Aguardando Ajustes",
        value: ProposicaoStatus.SuspensaRdAguardandoAjustes,
    },
    {
        label: "Aprovada RD - Ajustes Realizados",
        value: ProposicaoStatus.AprovadaRdAjustesRealizados,
    },
    {
        label: "Suspensa RD - Ajustes Realizados",
        value: ProposicaoStatus.SuspensaRdAjustesRealizados,
    },
];

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
