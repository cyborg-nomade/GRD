import { UserDto } from "../../access-control.model";
import { AndamentoStatus } from "../../common.model";

interface IAndamentoDto {
    user: UserDto;
    status: AndamentoStatus;
    descricao: string;
    anexosFilePaths: string[];
}

export class AndamentoDto implements IAndamentoDto {
    id!: number;
    data!: Date;
    user!: UserDto;
    nomeResponsavel!: string;
    status!: AndamentoStatus;
    descricao!: string;
    anexosFilePaths!: string[];

    constructor() {
        this.id = 0;
        this.data = new Date();
        this.user = new UserDto();
        this.nomeResponsavel = "";
        this.status = AndamentoStatus.Ativo;
        this.descricao = "";
        this.anexosFilePaths = [];
    }
}

export class CreateAndamentoDto implements IAndamentoDto {
    user!: UserDto;
    status!: AndamentoStatus;
    descricao!: string;
    anexosFilePaths!: string[];

    constructor() {
        this.user = new UserDto();
        this.status = AndamentoStatus.Ativo;
        this.descricao = "";
        this.anexosFilePaths = [];
    }
}
