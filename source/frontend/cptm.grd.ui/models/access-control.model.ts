import { AccessLevel } from "./common.model";

interface IGroupDto {
    sigla: string;
    nome: string;
    siglaGerencia: string;
    gerencia: string;
    siglaDiretoria: string;
    diretoria: string;
}

export class GroupDto implements IGroupDto {
    id!: number;
    sigla!: string;
    nome!: string;
    siglaGerencia!: string;
    gerencia!: string;
    siglaDiretoria!: string;
    diretoria!: string;

    constructor() {
        this.id = 0;
        this.sigla = "";
        this.nome = "";
        this.siglaGerencia = "";
        this.gerencia = "";
        this.siglaDiretoria = "";
        this.diretoria = "";
    }
}

interface IBaseUserDto {
    nome: string;
    nivelAcesso: AccessLevel;
    areasAcesso: GroupDto[];
    funcao: string;
    email: string;
}

interface IFullUserDto {
    id: number;
}

interface IUsernameAdUserDto {
    usernameAd: string;
}

export class AuthUser {
    username!: string;
    password!: string;

    constructor() {
        this.username = "";
        this.password = "";
    }
}

export class CreateUserDto implements IUsernameAdUserDto {
    usernameAd!: string;

    constructor() {
        this.usernameAd = "";
    }
}

export class UpdateUserDto implements IBaseUserDto, IFullUserDto {
    nome!: string;
    nivelAcesso!: AccessLevel;
    areasAcesso!: GroupDto[];
    funcao!: string;
    email!: string;
    id!: number;

    constructor() {
        this.nome = "";
        this.nivelAcesso = AccessLevel.Sub;
        this.areasAcesso = [new GroupDto()];
        this.funcao = "";
        this.email = "";
        this.id = 0;
    }
}

export class UserDto implements IBaseUserDto, IFullUserDto, IUsernameAdUserDto {
    nome!: string;
    nivelAcesso!: AccessLevel;
    areasAcesso!: GroupDto[];
    funcao!: string;
    email!: string;
    id!: number;
    usernameAd!: string;

    constructor() {
        this.nome = "";
        this.nivelAcesso = AccessLevel.Sub;
        this.areasAcesso = [new GroupDto()];
        this.funcao = "";
        this.email = "";
        this.id = 0;
        this.funcao = "";
    }
}
