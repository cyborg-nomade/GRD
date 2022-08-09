import { TipoVotoRd } from "../../common.model";
import { ParticipanteDto } from "./../../reunioes/children/participante.model";

interface IBaseVotoDto {
    participante: ParticipanteDto;
    votoRd: TipoVotoRd;
}

interface IFullVotoDto {
    id: number;
}

export class CreateVotoDto implements IBaseVotoDto {
    participante!: ParticipanteDto;
    votoRd!: TipoVotoRd;

    constructor() {
        this.participante = new ParticipanteDto();
        this.votoRd = TipoVotoRd.Suspensao;
    }
}

export class VotoDto implements IBaseVotoDto, IFullVotoDto {
    participante!: ParticipanteDto;
    votoRd!: TipoVotoRd;
    id!: number;

    constructor() {
        this.participante = new ParticipanteDto();
        this.votoRd = TipoVotoRd.Suspensao;
        this.id = 0;
    }
}
