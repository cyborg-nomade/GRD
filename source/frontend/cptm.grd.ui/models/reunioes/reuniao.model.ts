import { UserDto } from "../access-control.model";
import { ReuniaoStatus, TipoReuniao } from "../common.model";
import { ProposicaoDto } from "../proposicoes/proposicao.model";
import { AcaoDto, IBaseAcaoDto } from "./../acoes/acao.model";

interface IAutoPropertiesReuniaoDto {
    status: ReuniaoStatus;
    pautaPreviaFilePath: string;
    memoriaPreviaFilePath: string;
    pautaDefinitivaFilePath: string;
    relatorioDeliberativoFilePath: string;
    ataFilePath: string;
}

interface IBaseReuniaoDto {
    data: Date;
    horario: Date;
    dataPrevia: Date;
    horarioPrevia: Date;
    local: string;
    tipoReuniao: TipoReuniao;
    proposicoes: ProposicaoDto[];
    proposicoesPrevia: ProposicaoDto[];
    participantes: UserDto[];
    participantesPrevia: UserDto[];
    acoes: AcaoDto[];
    comunicado?: string;
    outrasObservacoes?: string;
    mensagemEmail?: string;
}

interface IFullReuniaoDto {
    id: number;
    numeroReuniao: number;
}

export class CreateReuniaoDto implements IBaseReuniaoDto {
    data!: Date;
    horario!: Date;
    dataPrevia!: Date;
    horarioPrevia!: Date;
    local!: string;
    tipoReuniao!: TipoReuniao;
    proposicoes!: ProposicaoDto[];
    proposicoesPrevia!: ProposicaoDto[];
    participantes!: UserDto[];
    participantesPrevia!: UserDto[];
    acoes!: AcaoDto[];
    comunicado?: string | undefined;
    outrasObservacoes?: string | undefined;
    mensagemEmail?: string | undefined;

    constructor() {
        this.data = new Date();
        this.horario = new Date();
        this.dataPrevia = new Date();
        this.horarioPrevia = new Date();
        this.local = "";
        this.tipoReuniao = TipoReuniao.Ordinaria;
        this.proposicoes = [];
        this.proposicoesPrevia = [];
        this.participantes = [];
        this.participantesPrevia = [];
        this.acoes = [];
    }
}

export class ReuniaoDto
    implements IBaseReuniaoDto, IFullReuniaoDto, IAutoPropertiesReuniaoDto
{
    data!: Date;
    horario!: Date;
    dataPrevia!: Date;
    horarioPrevia!: Date;
    local!: string;
    tipoReuniao!: TipoReuniao;
    proposicoes!: ProposicaoDto[];
    proposicoesPrevia!: ProposicaoDto[];
    participantes!: UserDto[];
    participantesPrevia!: UserDto[];
    acoes!: AcaoDto[];
    comunicado?: string | undefined;
    outrasObservacoes?: string | undefined;
    mensagemEmail?: string | undefined;
    id!: number;
    numeroReuniao!: number;
    status!: ReuniaoStatus;
    pautaPreviaFilePath!: string;
    memoriaPreviaFilePath!: string;
    pautaDefinitivaFilePath!: string;
    relatorioDeliberativoFilePath!: string;
    ataFilePath!: string;

    constructor() {
        this.data = new Date();
        this.horario = new Date();
        this.dataPrevia = new Date();
        this.horarioPrevia = new Date();
        this.local = "";
        this.tipoReuniao = TipoReuniao.Ordinaria;
        this.proposicoes = [];
        this.proposicoesPrevia = [];
        this.participantes = [];
        this.participantesPrevia = [];
        this.acoes = [];
        this.id = 0;
        this.numeroReuniao = 0;
        this.status = ReuniaoStatus.EmCriacao;
        this.pautaPreviaFilePath = "";
        this.memoriaPreviaFilePath = "";
        this.pautaDefinitivaFilePath = "";
        this.relatorioDeliberativoFilePath = "";
        this.ataFilePath = "";
    }
}

export class ReuniaoListDto {
    id!: number;
    numeroReuniao!: number;
    data!: Date;
    horario!: Date;
    status!: ReuniaoStatus;
    dataPrevia!: Date;
    horarioPrevia!: Date;
    local!: string;
    tipoReuniao!: TipoReuniao;

    constructor() {
        this.data = new Date();
        this.horario = new Date();
        this.dataPrevia = new Date();
        this.horarioPrevia = new Date();
        this.local = "";
        this.tipoReuniao = TipoReuniao.Ordinaria;
        this.id = 0;
        this.numeroReuniao = 0;
        this.status = ReuniaoStatus.EmCriacao;
    }
}

export class UpdateReuniaoDto implements IBaseReuniaoDto, IFullReuniaoDto {
    data!: Date;
    horario!: Date;
    dataPrevia!: Date;
    horarioPrevia!: Date;
    local!: string;
    tipoReuniao!: TipoReuniao;
    proposicoes!: ProposicaoDto[];
    proposicoesPrevia!: ProposicaoDto[];
    participantes!: UserDto[];
    participantesPrevia!: UserDto[];
    acoes!: AcaoDto[];
    comunicado?: string | undefined;
    outrasObservacoes?: string | undefined;
    mensagemEmail?: string | undefined;
    id!: number;
    numeroReuniao!: number;

    constructor() {
        this.data = new Date();
        this.horario = new Date();
        this.dataPrevia = new Date();
        this.horarioPrevia = new Date();
        this.local = "";
        this.tipoReuniao = TipoReuniao.Ordinaria;
        this.proposicoes = [];
        this.proposicoesPrevia = [];
        this.participantes = [];
        this.participantesPrevia = [];
        this.acoes = [];
        this.id = 0;
        this.numeroReuniao = 0;
    }
}
