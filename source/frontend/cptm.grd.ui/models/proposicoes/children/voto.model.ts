import { UserDto } from "../../access-control.model";
import { TipoVotoRd } from "../../common.model";

interface IBaseVotoDto {
    participante: UserDto;
    votoRd: TipoVotoRd;
}

interface IFullVotoDto {
    id: number;
}

export class CreateVotoDto implements IBaseVotoDto {
    participante!: UserDto;
    votoRd!: TipoVotoRd;

    constructor() {
        this.participante = new UserDto();
        this.votoRd = TipoVotoRd.Suspensao;
    }
}

export class VotoDto implements IBaseVotoDto, IFullVotoDto {
    participante!: UserDto;
    votoRd!: TipoVotoRd;
    id!: number;

    constructor() {
        this.participante = new UserDto();
        this.votoRd = TipoVotoRd.Suspensao;
        this.id = 0;
    }
}
