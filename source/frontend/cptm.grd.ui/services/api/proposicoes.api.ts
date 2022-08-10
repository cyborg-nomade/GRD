import axios from "axios";
import { ProposicaoStatus } from "../../models/common.model";
import {
    CreateProposicaoDto,
    ProposicaoDto,
    ProposicaoListDto,
    UpdateProposicaoDto,
    VoteWithAjustesProposicaoDto,
} from "../../models/proposicoes/proposicao.model";
import { ApiCore, ApiCoreOptions } from "./utilities/core.util";
import { handleError, handleResponse } from "./utilities/response.util";

const BASE_URL = process.env.NEXT_PUBLIC_CONNSTR;

const url = "proposicoes";
const plural = "proposicoes";
const single = "proposicao";

// plural and single may be used for message logic if needed in the ApiCore class.

const proposicoesApiOptions: ApiCoreOptions = {
    getAll: true,
    getSingle: true,
    post: true,
    put: true,
    remove: true,
    url,
};

class ProposicoesApi extends ApiCore<
    ProposicaoDto,
    ProposicaoListDto,
    CreateProposicaoDto,
    UpdateProposicaoDto
> {
    getByUser!: (token: string, uid: number) => Promise<ProposicaoListDto[]>;
    getByGroup!: (token: string, gid: number) => Promise<ProposicaoListDto[]>;
    getByStatus!: (
        token: string,
        status: ProposicaoStatus,
        arquivada: boolean
    ) => Promise<ProposicaoListDto[]>;
    getByUserAndStatus!: (
        token: string,
        uid: number,
        status: ProposicaoStatus,
        arquivada: boolean
    ) => Promise<ProposicaoListDto[]>;
    getByGroupAndStatus!: (
        token: string,
        gid: number,
        status: ProposicaoStatus,
        arquivada: boolean
    ) => Promise<ProposicaoListDto[]>;
    getByReuniao!: (token: string, rid: number) => Promise<ProposicaoListDto[]>;
    getByReuniaoPrevia!: (
        token: string,
        rid: number
    ) => Promise<ProposicaoListDto[]>;
    sendDiretoriaApproval!: (
        token: string,
        pid: number
    ) => Promise<ProposicaoDto>;
    diretoriaApprove!: (token: string, pid: number) => Promise<ProposicaoDto>;
    diretoriaRepprove!: (
        token: string,
        pid: number,
        motivoReprovacao: string
    ) => Promise<ProposicaoDto>;
    returnToDiretoria!: (
        token: string,
        pid: number,
        motivoReprovacao: string
    ) => Promise<ProposicaoDto>;
    returnToGrg!: (token: string, pid: number) => Promise<ProposicaoDto>;
    fixesDone!: (token: string, pid: number) => Promise<ProposicaoDto>;
    rdDeliberateDiretor!: (
        token: string,
        pid: number,
        votesWithAjustes: VoteWithAjustesProposicaoDto
    ) => Promise<ProposicaoDto>;
    annotatePrevia!: (
        token: string,
        pid: number,
        annotation: string
    ) => Promise<ProposicaoDto>;

    constructor() {
        super(proposicoesApiOptions);

        this.getByUser = async (token: string, uid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/user/${uid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByGroup = async (token: string, gid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/group/${gid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
        this.getByStatus = async (
            token: string,
            status: ProposicaoStatus,
            arquivada: boolean
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/status/${status}/${arquivada}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByUserAndStatus = async (
            token: string,
            uid: number,
            status: ProposicaoStatus,
            arquivada: boolean
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/user/${uid}/status/${status}/${arquivada}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByGroupAndStatus = async (
            token: string,
            gid: number,
            status: ProposicaoStatus,
            arquivada: boolean
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/group/${gid}/status/${status}/${arquivada}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByReuniao = async (token: string, rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/reuniao/${rid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByReuniaoPrevia = async (token: string, rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/reuniao/${rid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.sendDiretoriaApproval = async (token: string, pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/send-diretoria-approval`,
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

        this.diretoriaApprove = async (token: string, pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/diretoria-approve`,
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

        this.diretoriaRepprove = async (
            token: string,
            pid: number,
            motivoReprovacao: string
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/diretoria-repprove`,
                    motivoReprovacao,
                    {
                        headers: {
                            "Content-Type": "application/json",
                            Authorization: `Bearer ${token}`,
                        },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.returnToDiretoria = async (
            token: string,
            pid: number,
            motivoReprovacao: string
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/return-to-diretoria`,
                    motivoReprovacao,
                    {
                        headers: {
                            "Content-Type": "application/json",
                            Authorization: `Bearer ${token}`,
                        },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.returnToGrg = async (token: string, pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/return-to-grg`,
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

        this.fixesDone = async (token: string, pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/fixes-done`,
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

        this.rdDeliberateDiretor = async (
            token: string,
            pid: number,
            votesWithAjustes: VoteWithAjustesProposicaoDto
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/rd-deliberate`,
                    votesWithAjustes,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.annotatePrevia = async (
            token: string,
            pid: number,
            annotation: string
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/annotate-previa`,
                    annotation,
                    {
                        headers: {
                            "Content-Type": "application/json",
                            Authorization: `Bearer ${token}`,
                        },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
    }
}

export default ProposicoesApi;
