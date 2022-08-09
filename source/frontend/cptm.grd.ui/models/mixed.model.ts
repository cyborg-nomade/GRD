import { AcaoDto } from "./acoes/acao.model";
import { ProposicaoDto } from "./proposicoes/proposicao.model";
import { ReuniaoDto } from "./reunioes/reuniao.model";

export class AddAcaoToReuniaoDto {
    acaoDto!: AcaoDto;
    reuniaoDto!: ReuniaoDto;

    constructor() {
        this.acaoDto = new AcaoDto();
        this.reuniaoDto = new ReuniaoDto();
    }
}

export class AddProposicaoToReuniaoDto {
    proposicaoDto!: ProposicaoDto;
    reuniaoDto!: ReuniaoDto;

    constructor() {
        this.proposicaoDto = new ProposicaoDto();
        this.reuniaoDto = new ReuniaoDto();
    }
}
