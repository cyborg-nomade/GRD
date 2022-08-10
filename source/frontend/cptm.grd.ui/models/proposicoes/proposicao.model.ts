import {
    ObjetoProposicao,
    ProposicaoStatus,
    ReceitaDespesa,
} from "../common.model";
import { ReuniaoDto } from "./../reunioes/reuniao.model";
import { CreateVotoDto, VotoDto } from "./children/voto.model";
import { UserDto, GroupDto } from "./../access-control.model";

interface IAutoPropertiesProposicaoDto {
    status: ProposicaoStatus;
    arquivada: boolean;
    reuniao?: ReuniaoDto;
    anotacoesPrevia?: string;
    votosRd: VotoDto[];
    motivoRetornoDiretoriaResp?: string;
    motivoRetornoGrg?: string;
    motivoRetornoRd?: string;
    deliberacao?: string;
    isExtraPauta: boolean;
    resolucaoDiretoriaFilePath?: string;
}

interface IBaseProposicaoDto {
    titulo: string;
    objeto: ObjetoProposicao;
    descricaoProposicao: string;
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
    valorAtualContrato: number;
    numeroReservaVerba: string;
    valorReservaVerba: number;
    inicioVigenciaReserva: Date;
    fimVigenciaReserva: Date;
    numeroProposicao: string;
    protocoloExpediente: string;
    numeroProcessoLicit: string;
    outrasObservacoes?: string;
    numeroConselho?: string;
    sinteseProcessoFilePath: string;
    notaTecnicaFilePath: string;
    prdFilePath: string;
    parecerJuridicoFilePath: string;
    trFilePath: string;
    relatorioTecnicoFilePath: string;
    planilhaQuantFilePath: string;
    editalFilePath: string;
    reservaVerbaFilePath: string;
    scFilePath: string;
    ravFilePath: string;
    cronogramaFisFinFilePath: string;
    pcaFilePath: string;
    outrosFilePath: string[];
    seq: number;
}

interface IFullProposicaoDto {
    id: number;
    idPrd: number;
}

interface IOwnerPropertiesProposicaoDto {
    criador: UserDto;
    area: GroupDto;
}

export class CreateProposicaoDto
    implements IBaseProposicaoDto, IOwnerPropertiesProposicaoDto
{
    titulo!: string;
    objeto!: ObjetoProposicao;
    descricaoProposicao!: string;
    possuiParecerJuridico!: boolean;
    resumoGeralResolucao!: string;
    observacoesCustos!: string;
    competenciasConformeNormas!: string;
    dataBaseValor!: Date;
    moeda!: string;
    valorOriginalContrato!: number;
    valorTotalProposicao!: number;
    receitaDespesa!: ReceitaDespesa;
    numeroContrato!: string;
    termo!: string;
    fornecedor!: string;
    valorAtualContrato!: number;
    numeroReservaVerba!: string;
    valorReservaVerba!: number;
    inicioVigenciaReserva!: Date;
    fimVigenciaReserva!: Date;
    numeroProposicao!: string;
    protocoloExpediente!: string;
    numeroProcessoLicit!: string;
    outrasObservacoes?: string | undefined;
    numeroConselho?: string | undefined;
    sinteseProcessoFilePath!: string;
    notaTecnicaFilePath!: string;
    prdFilePath!: string;
    parecerJuridicoFilePath!: string;
    trFilePath!: string;
    relatorioTecnicoFilePath!: string;
    planilhaQuantFilePath!: string;
    editalFilePath!: string;
    reservaVerbaFilePath!: string;
    scFilePath!: string;
    ravFilePath!: string;
    cronogramaFisFinFilePath!: string;
    pcaFilePath!: string;
    outrosFilePath!: string[];
    seq!: number;
    criador!: UserDto;
    area!: GroupDto;

    constructor() {
        this.titulo = "";
        this.objeto = ObjetoProposicao.Aditamento;
        this.descricaoProposicao = "";
        this.possuiParecerJuridico = false;
        this.resumoGeralResolucao = "";
        this.observacoesCustos = "";
        this.competenciasConformeNormas = "";
        this.dataBaseValor = new Date();
        this.moeda = "";
        this.valorOriginalContrato = 0;
        this.valorTotalProposicao = 0;
        this.receitaDespesa = ReceitaDespesa.Despesa;
        this.numeroContrato = "";
        this.termo = "";
        this.fornecedor = "";
        this.valorAtualContrato = 0;
        this.numeroReservaVerba = "";
        this.valorReservaVerba = 0;
        this.inicioVigenciaReserva = new Date();
        this.fimVigenciaReserva = new Date();
        this.numeroProposicao = "";
        this.protocoloExpediente = "";
        this.numeroProcessoLicit = "";
        this.sinteseProcessoFilePath = "";
        this.notaTecnicaFilePath = "";
        this.prdFilePath = "";
        this.parecerJuridicoFilePath = "";
        this.trFilePath = "";
        this.relatorioTecnicoFilePath = "";
        this.planilhaQuantFilePath = "";
        this.editalFilePath = "";
        this.reservaVerbaFilePath = "";
        this.scFilePath = "";
        this.ravFilePath = "";
        this.cronogramaFisFinFilePath = "";
        this.pcaFilePath = "";
        this.outrosFilePath = [];
        this.criador = new UserDto();
        this.area = new GroupDto();
    }
}

export class ProposicaoDto
    implements
        IBaseProposicaoDto,
        IFullProposicaoDto,
        IOwnerPropertiesProposicaoDto,
        IAutoPropertiesProposicaoDto
{
    titulo!: string;
    objeto!: ObjetoProposicao;
    descricaoProposicao!: string;
    possuiParecerJuridico!: boolean;
    resumoGeralResolucao!: string;
    observacoesCustos!: string;
    competenciasConformeNormas!: string;
    dataBaseValor!: Date;
    moeda!: string;
    valorOriginalContrato!: number;
    valorTotalProposicao!: number;
    receitaDespesa!: ReceitaDespesa;
    numeroContrato!: string;
    termo!: string;
    fornecedor!: string;
    valorAtualContrato!: number;
    numeroReservaVerba!: string;
    valorReservaVerba!: number;
    inicioVigenciaReserva!: Date;
    fimVigenciaReserva!: Date;
    numeroProposicao!: string;
    protocoloExpediente!: string;
    numeroProcessoLicit!: string;
    outrasObservacoes?: string | undefined;
    numeroConselho?: string | undefined;
    sinteseProcessoFilePath!: string;
    notaTecnicaFilePath!: string;
    prdFilePath!: string;
    parecerJuridicoFilePath!: string;
    trFilePath!: string;
    relatorioTecnicoFilePath!: string;
    planilhaQuantFilePath!: string;
    editalFilePath!: string;
    reservaVerbaFilePath!: string;
    scFilePath!: string;
    ravFilePath!: string;
    cronogramaFisFinFilePath!: string;
    pcaFilePath!: string;
    outrosFilePath!: string[];
    seq!: number;
    id!: number;
    idPrd!: number;
    criador!: UserDto;
    area!: GroupDto;
    status!: ProposicaoStatus;
    arquivada!: boolean;
    reuniao?: ReuniaoDto | undefined;
    anotacoesPrevia?: string | undefined;
    votosRd!: VotoDto[];
    motivoRetornoDiretoriaResp?: string | undefined;
    motivoRetornoGrg?: string | undefined;
    motivoRetornoRd?: string | undefined;
    deliberacao?: string | undefined;
    isExtraPauta!: boolean;
    resolucaoDiretoriaFilePath?: string | undefined;

    constructor() {
        this.titulo = "";
        this.objeto = ObjetoProposicao.Aditamento;
        this.descricaoProposicao = "";
        this.possuiParecerJuridico = false;
        this.resumoGeralResolucao = "";
        this.observacoesCustos = "";
        this.competenciasConformeNormas = "";
        this.dataBaseValor = new Date();
        this.moeda = "";
        this.valorOriginalContrato = 0;
        this.valorTotalProposicao = 0;
        this.receitaDespesa = ReceitaDespesa.Despesa;
        this.numeroContrato = "";
        this.termo = "";
        this.fornecedor = "";
        this.valorAtualContrato = 0;
        this.numeroReservaVerba = "";
        this.valorReservaVerba = 0;
        this.inicioVigenciaReserva = new Date();
        this.fimVigenciaReserva = new Date();
        this.numeroProposicao = "";
        this.protocoloExpediente = "";
        this.numeroProcessoLicit = "";
        this.sinteseProcessoFilePath = "";
        this.notaTecnicaFilePath = "";
        this.prdFilePath = "";
        this.parecerJuridicoFilePath = "";
        this.trFilePath = "";
        this.relatorioTecnicoFilePath = "";
        this.planilhaQuantFilePath = "";
        this.editalFilePath = "";
        this.reservaVerbaFilePath = "";
        this.scFilePath = "";
        this.ravFilePath = "";
        this.cronogramaFisFinFilePath = "";
        this.pcaFilePath = "";
        this.outrosFilePath = [];
        this.id = 0;
        this.idPrd = 0;
        this.criador = new UserDto();
        this.area = new GroupDto();
        this.status = ProposicaoStatus.EmPreenchimento;
        this.arquivada = false;
        this.votosRd = [];
        this.isExtraPauta = false;
    }
}

export class ProposicaoListDto {
    id!: number;
    idPrd!: number;
    status!: ProposicaoStatus;
    arquivada!: boolean;
    criador!: UserDto;
    areaSolicitante!: GroupDto;
    titulo!: string;
    objeto!: ObjetoProposicao;
    moeda!: string;
    valorTotalProposicao!: number;
    receitaDespesa!: ReceitaDespesa;

    constructor() {
        this.titulo = "";
        this.objeto = ObjetoProposicao.Aditamento;
        this.moeda = "";
        this.valorTotalProposicao = 0;
        this.receitaDespesa = ReceitaDespesa.Despesa;
        this.id = 0;
        this.idPrd = 0;
        this.criador = new UserDto();
        this.status = ProposicaoStatus.EmPreenchimento;
        this.arquivada = false;
    }
}

export class UpdateProposicaoDto
    implements IBaseProposicaoDto, IFullProposicaoDto
{
    titulo!: string;
    objeto!: ObjetoProposicao;
    descricaoProposicao!: string;
    possuiParecerJuridico!: boolean;
    resumoGeralResolucao!: string;
    observacoesCustos!: string;
    competenciasConformeNormas!: string;
    dataBaseValor!: Date;
    moeda!: string;
    valorOriginalContrato!: number;
    valorTotalProposicao!: number;
    receitaDespesa!: ReceitaDespesa;
    numeroContrato!: string;
    termo!: string;
    fornecedor!: string;
    valorAtualContrato!: number;
    numeroReservaVerba!: string;
    valorReservaVerba!: number;
    inicioVigenciaReserva!: Date;
    fimVigenciaReserva!: Date;
    numeroProposicao!: string;
    protocoloExpediente!: string;
    numeroProcessoLicit!: string;
    outrasObservacoes?: string | undefined;
    numeroConselho?: string | undefined;
    sinteseProcessoFilePath!: string;
    notaTecnicaFilePath!: string;
    prdFilePath!: string;
    parecerJuridicoFilePath!: string;
    trFilePath!: string;
    relatorioTecnicoFilePath!: string;
    planilhaQuantFilePath!: string;
    editalFilePath!: string;
    reservaVerbaFilePath!: string;
    scFilePath!: string;
    ravFilePath!: string;
    cronogramaFisFinFilePath!: string;
    pcaFilePath!: string;
    outrosFilePath!: string[];
    seq!: number;
    id!: number;
    idPrd!: number;

    constructor() {
        this.titulo = "";
        this.objeto = ObjetoProposicao.Aditamento;
        this.descricaoProposicao = "";
        this.possuiParecerJuridico = false;
        this.resumoGeralResolucao = "";
        this.observacoesCustos = "";
        this.competenciasConformeNormas = "";
        this.dataBaseValor = new Date();
        this.moeda = "";
        this.valorOriginalContrato = 0;
        this.valorTotalProposicao = 0;
        this.receitaDespesa = ReceitaDespesa.Despesa;
        this.numeroContrato = "";
        this.termo = "";
        this.fornecedor = "";
        this.valorAtualContrato = 0;
        this.numeroReservaVerba = "";
        this.valorReservaVerba = 0;
        this.inicioVigenciaReserva = new Date();
        this.fimVigenciaReserva = new Date();
        this.numeroProposicao = "";
        this.protocoloExpediente = "";
        this.numeroProcessoLicit = "";
        this.sinteseProcessoFilePath = "";
        this.notaTecnicaFilePath = "";
        this.prdFilePath = "";
        this.parecerJuridicoFilePath = "";
        this.trFilePath = "";
        this.relatorioTecnicoFilePath = "";
        this.planilhaQuantFilePath = "";
        this.editalFilePath = "";
        this.reservaVerbaFilePath = "";
        this.scFilePath = "";
        this.ravFilePath = "";
        this.cronogramaFisFinFilePath = "";
        this.pcaFilePath = "";
        this.outrosFilePath = [];
        this.id = 0;
        this.idPrd = 0;
    }
}

export class VoteWithAjustesProposicaoDto {
    votoDto!: CreateVotoDto;
    ajustes!: string;

    constructor() {
        this.votoDto = new CreateVotoDto();
        this.ajustes = "";
    }
}
