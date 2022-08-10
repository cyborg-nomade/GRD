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
    getByStatus!: (
        token: string,
        status: ReuniaoStatus
    ) => Promise<ReuniaoListDto[]>;
    getPautaPreviaFile!: (token: string, rid: number) => Promise<ReuniaoDto>;
    getMemoriaPreviaFile!: (token: string, rid: number) => Promise<ReuniaoDto>;
    getPautaDefinitivaFile!: (
        token: string,
        rid: number
    ) => Promise<ReuniaoDto>;
    getRelatorioDeliberativoFile!: (
        token: string,
        rid: number
    ) => Promise<ReuniaoDto>;
    getResolucaoDiretoriaFile!: (
        token: string,
        rid: number,
        pid: number
    ) => Promise<ReuniaoDto>;
    getAtaFile!: (token: string, rid: number) => Promise<ReuniaoDto>;
    addProposicao!: (
        token: string,
        rid: number,
        pid: number
    ) => Promise<AddProposicaoToReuniaoDto>;
    removeProposicao!: (
        token: string,
        rid: number,
        pid: number
    ) => Promise<AddProposicaoToReuniaoDto>;
    removeAcao!: (
        token: string,
        rid: number,
        aid: number
    ) => Promise<AddAcaoToReuniaoDto>;

    constructor() {
        super(proposicoesApiOptions);

        this.getByStatus = async (token: string, status: ReuniaoStatus) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/status/${status}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getPautaPreviaFile = async (token: string, rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/pauta-previa`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
        this.getMemoriaPreviaFile = async (token: string, rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/memoria-previa`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getPautaDefinitivaFile = async (token: string, rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/pauta-definitiva`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getRelatorioDeliberativoFile = async (
            token: string,
            rid: number
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/relatorio-deliberativo`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getResolucaoDiretoriaFile = async (
            token: string,
            rid: number,
            pid: number
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/proposicao/${pid}/resolucao-diretoria`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getAtaFile = async (token: string, rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/${rid}/ata`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.addProposicao = async (
            token: string,
            rid: number,
            pid: number
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${rid}/proposicao/${pid}/add`,
                    {},
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.removeProposicao = async (
            token: string,
            rid: number,
            pid: number
        ) => {
            try {
                const response = await axios.delete(
                    `${BASE_URL}/${url}/${rid}/proposicao/${pid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.removeAcao = async (token: string, rid: number, aid: number) => {
            try {
                const response = await axios.delete(
                    `${BASE_URL}/${url}/${rid}/acao/${aid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
    }
}

export default ReunioesApi;
