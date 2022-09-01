import { UserDto } from "../../access-control.model";
import { TipoVotoRd } from "../../common.model";

interface IBaseVotoDto {
    participanteId: number;
    votoRd: TipoVotoRd;
}

interface IFullVotoDto {
    id: number;
}

export class CreateVotoDto implements IBaseVotoDto {
    participanteId!: number;
    votoRd!: TipoVotoRd;

    constructor() {
        this.participanteId = 0;
        this.votoRd = TipoVotoRd.Suspensao;
    }
}

export class VotoDto implements IBaseVotoDto, IFullVotoDto {
    participanteId!: number;
    votoRd!: TipoVotoRd;
    id!: number;

    constructor() {
        this.participanteId = 0;
        this.votoRd = TipoVotoRd.Suspensao;
        this.id = 0;
    }
}
