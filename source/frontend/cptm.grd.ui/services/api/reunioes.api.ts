import axios from "axios";
import { ProposicaoStatus, ReuniaoStatus } from "../../models/common.model";
import {
    AddAcaoToReuniaoDto,
    AddProposicaoToReuniaoDto,
} from "../../models/mixed.model";
import {
    CreateProposicaoDto,
    ProposicaoDto,
    ProposicaoListDto,
    UpdateProposicaoDto,
    VoteWithAjustesProposicaoDto,
} from "../../models/proposicoes/proposicao.model";
import {
    CreateReuniaoDto,
    ReuniaoDto,
    ReuniaoListDto,
    UpdateReuniaoDto,
} from "../../models/reunioes/reuniao.model";
import { ApiCore, ApiCoreOptions } from "./utilities/core.util";
import { handleError, handleResponse } from "./utilities/response.util";

const BASE_URL = process.env.NEXT_PUBLIC_CONNSTR;

const url = "reunioes";
const plural = "reunioes";
const single = "reuniao";

// plural and single may be used for message logic if needed in the ApiCore class.

const proposicoesApiOptions: ApiCoreOptions = {
    getAll: true,
    getSingle: true,
    post: true,
    put: true,
    remove: true,
    url,
};

class ReunioesApi extends ApiCore<
    ReuniaoDto,
    ReuniaoListDto,
    CreateReuniaoDto,
    UpdateReuniaoDto
> {
    getByStatus!: (status: ReuniaoStatus) => Promise<ReuniaoListDto[]>;
    getPautaPreviaFile!: (rid: number) => Promise<ReuniaoDto>;
    getMemoriaPreviaFile!: (rid: number) => Promise<ReuniaoDto>;
    getPautaDefinitivaFile!: (rid: number) => Promise<ReuniaoDto>;
    getRelatorioDeliberativoFile!: (rid: number) => Promise<ReuniaoDto>;
    getResolucaoDiretoriaFile!: (
        rid: number,
        pid: number
    ) => Promise<ReuniaoDto>;
    getAtaFile!: (rid: number) => Promise<ReuniaoDto>;
    addProposicao!: (
        rid: number,
        pid: number
    ) => Promise<AddProposicaoToReuniaoDto>;
    removeProposicao!: (
        rid: number,
        pid: number
    ) => Promise<AddProposicaoToReuniaoDto>;
    removeAcao!: (rid: number, aid: number) => Promise<AddAcaoToReuniaoDto>;

    constructor() {
        super(proposicoesApiOptions);

        this.getByStatus = async (status: ReuniaoStatus) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/status/${status}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getPautaPreviaFile = async (rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/pauta-previa`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
        this.getMemoriaPreviaFile = async (rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/memoria-previa`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getPautaDefinitivaFile = async (rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/pauta-definitiva`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getRelatorioDeliberativoFile = async (rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/relatorio-deliberativo`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getResolucaoDiretoriaFile = async (rid: number, pid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/proposicao/${pid}/resolucao-diretoria`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getAtaFile = async (rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/ata`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.addProposicao = async (rid: number, pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${rid}/proposicao/${pid}/add`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.removeProposicao = async (rid: number, pid: number) => {
            try {
                const response = await axios.delete(
                    `${BASE_URL}/${url}/${rid}/proposicao/${pid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.removeAcao = async (rid: number, aid: number) => {
            try {
                const response = await axios.delete(
                    `${BASE_URL}/${url}/${rid}/acao/${aid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
    }
}

export default ReunioesApi;
