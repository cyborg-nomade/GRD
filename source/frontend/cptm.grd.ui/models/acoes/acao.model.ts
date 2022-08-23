import {
    AcaoStatus,
    TipoAcao,
    TipoAlertaVencimento,
    TipoPeriodicidadeAcao,
} from "../common.model";
import { AndamentoDto } from "./children/andamento.model";
import { GroupDto, UserDto } from "./../access-control.model";

interface IAutoPropertiesAcaoDto {
    status: AcaoStatus;
    arquivada: boolean;
    diasParaVencimento: number;
    andamentos: AndamentoDto[];
}

export interface IBaseAcaoDto {
    tipo: TipoAcao;
    diretoriaRes: GroupDto;
    definicao: string;
    periodicidade: TipoPeriodicidadeAcao;
    prazoInicial: Date;
    responsavel: UserDto;
    emailDiretor: string;
    numeroContrato?: string;
    fornecedor?: string;
    prazoFinal: Date;
    alertaVencimento: TipoAlertaVencimento;
}

interface IFullAcaoDto {
    id: number;
    prazoProrrogadoDias: number;
}

export class AcaoDto
    implements IBaseAcaoDto, IFullAcaoDto, IAutoPropertiesAcaoDto
{
    tipo!: TipoAcao;
    diretoriaRes!: GroupDto;
    definicao!: string;
    periodicidade!: TipoPeriodicidadeAcao;
    prazoInicial!: Date;
    responsavel!: UserDto;
    emailDiretor!: string;
    numeroContrato?: string | undefined;
    fornecedor?: string | undefined;
    prazoFinal!: Date;
    alertaVencimento!: TipoAlertaVencimento;
    id!: number;
    prazoProrrogadoDias!: number;
    status!: AcaoStatus;
    arquivada!: boolean;
    diasParaVencimento!: number;
    andamentos!: AndamentoDto[];

    constructor() {
        const today = new Date();
        const tomorrow = new Date(today);
        tomorrow.setDate(tomorrow.getDate() + 1);
        const thirtyDaysFurther = new Date(today);
        thirtyDaysFurther.setDate(thirtyDaysFurther.getDate() + 30);

        this.tipo = TipoAcao.Acao;
        this.diretoriaRes = new GroupDto();
        this.definicao = "";
        this.periodicidade = TipoPeriodicidadeAcao.Semanal;
        this.prazoInicial = tomorrow;
        this.responsavel = new UserDto();
        this.emailDiretor = "";
        this.prazoFinal = thirtyDaysFurther;
        this.alertaVencimento = TipoAlertaVencimento.UmDiaVencimento;
        this.id = 0;
        this.prazoProrrogadoDias = 0;
        this.status = AcaoStatus.EmAndamento;
        this.arquivada = false;
        this.diasParaVencimento =
            this.prazoFinal.getDate() - this.prazoInicial.getDate();
        this.andamentos = [];
    }
}

export class AcaoListDto {
    id!: number;
    tipo!: TipoAcao;
    diretoriaRes!: GroupDto;
    definicao!: string;
    prazoInicial!: Date;
    status!: AcaoStatus;
    arquivada!: boolean;
    responsavel!: UserDto;
    prazoFinal!: Date;

    constructor() {
        const today = new Date();
        const tomorrow = new Date(today);
        tomorrow.setDate(tomorrow.getDate() + 1);
        const thirtyDaysFurther = new Date(today);
        thirtyDaysFurther.setDate(thirtyDaysFurther.getDate() + 30);

        this.tipo = TipoAcao.Acao;
        this.diretoriaRes = new GroupDto();
        this.definicao = "";
        this.prazoInicial = tomorrow;
        this.responsavel = new UserDto();
        this.prazoFinal = thirtyDaysFurther;
        this.id = 0;
        this.status = AcaoStatus.EmAndamento;
        this.arquivada = false;
    }
}

export class CreateAcaoDto implements IBaseAcaoDto {
    tipo!: TipoAcao;
    diretoriaRes!: GroupDto;
    definicao!: string;
    periodicidade!: TipoPeriodicidadeAcao;
    prazoInicial!: Date;
    responsavel!: UserDto;
    emailDiretor!: string;
    numeroContrato?: string | undefined;
    fornecedor?: string | undefined;
    prazoFinal!: Date;
    alertaVencimento!: TipoAlertaVencimento;

    constructor() {
        const today = new Date();
        const tomorrow = new Date(today);
        tomorrow.setDate(tomorrow.getDate() + 1);
        const thirtyDaysFurther = new Date(today);
        thirtyDaysFurther.setDate(thirtyDaysFurther.getDate() + 30);

        this.tipo = TipoAcao.Acao;
        this.diretoriaRes = new GroupDto();
        this.definicao = "";
        this.periodicidade = TipoPeriodicidadeAcao.Semanal;
        this.prazoInicial = tomorrow;
        this.responsavel = new UserDto();
        this.emailDiretor = "";
        this.prazoFinal = thirtyDaysFurther;
        this.alertaVencimento = TipoAlertaVencimento.UmDiaVencimento;
    }
}

export class UpdateAcaoDto implements IBaseAcaoDto, IFullAcaoDto {
    tipo!: TipoAcao;
    diretoriaRes!: GroupDto;
    definicao!: string;
    periodicidade!: TipoPeriodicidadeAcao;
    prazoInicial!: Date;
    responsavel!: UserDto;
    emailDiretor!: string;
    numeroContrato?: string | undefined;
    fornecedor?: string | undefined;
    prazoFinal!: Date;
    alertaVencimento!: TipoAlertaVencimento;
    id!: number;
    prazoProrrogadoDias!: number;

    constructor() {
        const today = new Date();
        const tomorrow = new Date(today);
        tomorrow.setDate(tomorrow.getDate() + 1);
        const thirtyDaysFurther = new Date(today);
        thirtyDaysFurther.setDate(thirtyDaysFurther.getDate() + 30);

        this.tipo = TipoAcao.Acao;
        this.diretoriaRes = new GroupDto();
        this.definicao = "";
        this.periodicidade = TipoPeriodicidadeAcao.Semanal;
        this.prazoInicial = tomorrow;
        this.responsavel = new UserDto();
        this.emailDiretor = "";
        this.prazoFinal = thirtyDaysFurther;
        this.alertaVencimento = TipoAlertaVencimento.UmDiaVencimento;
        this.id = 0;
        this.prazoProrrogadoDias = 0;
    }
}
