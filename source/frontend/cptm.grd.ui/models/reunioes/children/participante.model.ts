import { GroupDto, UserDto } from "../../access-control.model";

export interface IBaseParticipanteDto {
    user?: UserDto;
    diretoriaArea: GroupDto;
    nome: string;
    email: string;
}

interface IFullParticipanteDto {
    id: number;
}

export class CreateParticipanteDto implements IBaseParticipanteDto {
    user?: UserDto;
    diretoriaArea!: GroupDto;
    nome!: string;
    email!: string;

    constructor() {
        this.diretoriaArea = new GroupDto();
        this.nome = "";
        this.email = "";
    }
}

export class ParticipanteDto
    implements IBaseParticipanteDto, IFullParticipanteDto
{
    user?: UserDto;
    diretoriaArea!: GroupDto;
    nome!: string;
    email!: string;
    id!: number;

    constructor() {
        this.diretoriaArea = new GroupDto();
        this.nome = "";
        this.email = "";
        this.id = 0;
    }
}
