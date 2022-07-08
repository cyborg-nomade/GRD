interface Proposicao {
    id: number;
    idPrd: number;
    status: ProposicaoStatus;
    arquivada: boolean;
    areaSolicitante: Group;
    titulo: string;
    objeto: ObjetoProposicao;
    descriçãoProposicao: string;
    possuiParecerJuridico: boolean;
    resumoGeralResolucao: string;
    observacoesCustos: string;
    competenciasConformeNormas: string;
    dataBaseValor: Date;
    moeda: string;
    valorOriginalContrato: number;
    valorTotalProposicao: number;
    receitaDespesa: ReceitaDespesa;
    numeroContrato: string;
    termo: string;
    fornecedor: string;
    valorAtualContrato: string;
    numeroReservaVerba: string;
    valorReservaVerba: number;
    inicioVigenciaReserva: Date;
    fimVigenciaReserva: Date;
    numeroProposicao: string;
    protoloExpediente: string;
    numeroProcessoLicit: string;
    outrasObservacoes?: string;
    reuniao: Reuniao;
    motivoRetornoDiretoria: string;
    motivoRetornoGRG: string;
    motivoRetornoRD: string;
    deliberacao: string;
    logs: LogProposicao[];
    resolucao: Resolucao;
    isExtraPauta: boolean;
    numeroConselho?: string;
    sinteseProcessoFilePath: string;
    notaTecnicaFilePath: string;
    PRDFilePath: string;
    parecerJuridicoFilePath: string;
    TRFilePath: string;
    relatorioTecnicoFilePath: string;
    planilhaQuantFilePath: string;
    editalFilePath: string;
    reservaVerbaFilePath: string;
    SCFilePath: string;
    RAVFilePath: string;
    cronogramaFisFinFilePath: string;
    PCAFilePath: string;
    outrosFilePath: string[];
    areaAtual: string;
    descricaoFluxo: string;
    tempoPrevPerm: string;
    descProxPasso: string;
    tempoPermProx: string;
    seq?: number;
}

enum ProposicaoStatus {
    emPreenchimento,
    emAprovacaoDiretoriaResp,
    reprovadoDiretoriaResp,
    disponivelInclusaoPauta,
    retornadoGRG,
    emPauta,
    aprovadaRD,
    reprovadaRD,
    aprovadaRDAguardandoAjustes,
    aprovadaRDAjustesRealizados,
    suspensaRDAguardandoAjustes,
    suspensaRDAjustesRealizados,
}

enum ObjetoProposicao {
    aditamento,
    alienacaoLeilao,
    alteracaoEstruturaOrg,
    aprovacaoNormaGeral,
    aprovacaoRegulamento,
    aprovacaoEdital,
    aprovacaoPolitica,
    ataRegistroPrecos,
    atualizacaoRevisaoNormas,
    cancelamentoRD,
    contratacao,
    contratacaoDireta,
    convenio,
    dispensaLicitacao,
    homologacao,
    inexigibilidade,
    inicioProcedimentosLicit,
    outros,
    prorrogacao,
    renovacaoTPU,
    retiRetificacaoRD,
    termoPermissaoUso,
    viagemExterior,
}

enum ReceitaDespesa {
    receita,
    despesa,
}

interface Resolucao {
    id: number;
    numeroResolucao: number;
    assinaturaResolucao: string;
    resolucaoDiretoria: string;
    resolucaoFilePath: string;
    proposicao: Proposicao;
}

interface Reuniao {
    id: number;
    numeroReuniao: number;
    data: Date;
    horario: Date;
    status: ReuniaoStatus;
    dataPrevia: Date;
    horarioPrevia: Date;
    local: string;
    tipoReuniao: TipoReuniao;
    proposicoes: Proposicao[];
    proposicoesPrevia: Proposicao[];
    participantes: Participante[];
    participantesPrevia: Participante[];
    acoes: Acao[];
    comunicado?: string;
    outrasObservacoes?: string;
    mensagemEMail?: string;
    logs: LogReuniao[];
}

enum ReuniaoStatus {
    emCriacao,
    registrada,
    previa,
    pauta,
    realizada,
    arquivada,
}

enum TipoReuniao {
    ordinaria,
    extraordinaria,
}

interface Participante {
    id: number;
    user?: User;
    diretoriaArea: string;
    nome: string;
    email: string;
}

interface Acao {
    id: number;
    tipo: TipoAcao;
    diretoriaRes: Group;
    definicao: string;
    periodicidade: TipoPeriodicidadeAcao;
    prazoInicial: Date;
    status: AcaoStatus;
    arquivada: boolean;
    responsavel: User;
    emailDiretor: string;
    numeroContrato?: string;
    fornecedor?: string;
    prazoProrrogadoDias: number;
    prazoFinal: Date;
    diasParaVencimento: number;
    alertaVencimento: TipoAlertaVencimento;
    andamentos: Andamento[];
    logs: LogAcao[];
}

enum TipoAcao {
    acao,
    comentario,
    definicao,
    parecerTecnico,
    outrosAssuntos,
}

enum TipoPeriodicidadeAcao {
    data,
    semanal,
    mensal,
}

enum AcaoStatus {
    emAndamento,
    emAcompanhamento,
    concluida,
    encerradaSemConclusao,
}

enum TipoAlertaVencimento {
    noPrazo,
    umDiaVencimento,
    atrasado,
}

interface Andamento {
    id: number;
    data: Date;
    user?: User;
    nomeResponsavel: string;
    status: AndamentoStatus;
    descricao: string;
    anexosFilePath: string[];
}

enum AndamentoStatus {
    ativo,
    inativo,
}

interface User {
    id: number;
    nome: string;
    usernameAD: string;
    nivelAcesso: AccessLevel;
    areasAcesso: Group[];
    funcao: string;
    logs: LogAccessControl[];
}

interface Group {
    id: number;
    nome: string;
    siglaGerencia: string;
    gerencia: string;
    siglaDiretoria: string;
    diretoria: string;
    relator: User;
}

enum AccessLevel {
    sub,
    gerente,
    assessorDiretoria,
    diretor,
    grg,
    sysAdmin,
    responsavelAcao,
}

interface LogProposicao {
    id: number;
    tipo: TipoLogProposicao;
    proposicao: Proposicao;
    diferenca: Proposicao;
    data: Date;
    usuarioResp: User;
}

enum TipoLogProposicao {
    criacao,
    edicao,
    remocao,
    envioAprovacaoDiretoria,
    aprovacaoDiretoria,
    reprovacaoDiretoria,
    inclusaoPauta,
    aprovacaoRD,
    reprovacaoRD,
    suspensaoRD,
    abstencaoRD,
    solicitaAjustesRD,
    emissaoResolucaoDiretoria,
    envioAjustesRD,
    ajustesRDOK,
    arquivamento,
}

interface LogReuniao {
    id: number;
    tipo: TipoLogReuniao;
    reuniao: Reuniao;
    diferenca: Reuniao;
    data: Date;
    usuarioResp: User;
}

enum TipoLogReuniao {
    criacao,
    edicao,
    remocao,
    inclusaoProposicao,
    emissaoPautaPrevia,
    anotacaoPrevia,
    emissaoMemoriaPrevia,
    emissaoPautaDefinitiva,
    realizacaoRD,
    inclusaoProposicaoRetro,
    emissaoRelatorioDeliberativo,
    emissaoAta,
    inclusaoAcao,
    arquivamento,
}

interface LogAcao {
    id: number;
    tipo: TipoLogAcao;
    acao: Acao;
    diferenca: Acao;
    data: Date;
    usuarioResp: User;
}

enum TipoLogAcao {
    criacao,
    inclusaoAndamento,
    finalizacao,
    arquivamento,
}

interface LogAccessControl {
    id: number;
    tipo: TipoLogAccessControl;
    usuario: User;
    diferenca: User;
    data: Date;
    usuarioResp: User;
}

enum TipoLogAccessControl {
    criacao,
    alteracaoNivel,
    alteracaoGrupos,
    remocao,
}
