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
    getByUser!: (uid: number) => Promise<ProposicaoListDto[]>;
    getByGroup!: (gid: number) => Promise<ProposicaoListDto[]>;
    getByStatus!: (
        status: ProposicaoStatus,
        arquivada: boolean
    ) => Promise<ProposicaoListDto[]>;
    getByUserAndStatus!: (
        uid: number,
        status: ProposicaoStatus,
        arquivada: boolean
    ) => Promise<ProposicaoListDto[]>;
    getByGroupAndStatus!: (
        gid: number,
        status: ProposicaoStatus,
        arquivada: boolean
    ) => Promise<ProposicaoListDto[]>;
    getByReuniao!: (rid: number) => Promise<ProposicaoListDto[]>;
    getByReuniaoPrevia!: (rid: number) => Promise<ProposicaoListDto[]>;
    sendDiretoriaApproval!: (pid: number) => Promise<ProposicaoDto>;
    diretoriaApprove!: (pid: number) => Promise<ProposicaoDto>;
    diretoriaRepprove!: (
        pid: number,
        motivoReprovacao: string
    ) => Promise<ProposicaoDto>;
    returnToDiretoria!: (
        pid: number,
        motivoReprovacao: string
    ) => Promise<ProposicaoDto>;
    returnToGrg!: (pid: number) => Promise<ProposicaoDto>;
    fixesDone!: (pid: number) => Promise<ProposicaoDto>;
    rdDeliberateDiretor!: (
        pid: number,
        votesWithAjustes: VoteWithAjustesProposicaoDto
    ) => Promise<ProposicaoDto>;
    annotatePrevia!: (
        pid: number,
        annotation: string
    ) => Promise<ProposicaoDto>;

    constructor() {
        super(proposicoesApiOptions);

        this.getByUser = async (uid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/user/${uid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByGroup = async (gid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/group/${gid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
        this.getByStatus = async (
            status: ProposicaoStatus,
            arquivada: boolean
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/status/${status}/${arquivada}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByUserAndStatus = async (
            uid: number,
            status: ProposicaoStatus,
            arquivada: boolean
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/user/${uid}/status/${status}/${arquivada}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByGroupAndStatus = async (
            gid: number,
            status: ProposicaoStatus,
            arquivada: boolean
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/group/${gid}/status/${status}/${arquivada}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByReuniao = async (rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/reuniao/${rid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByReuniaoPrevia = async (rid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/reuniao/${rid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.sendDiretoriaApproval = async (pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/send-diretoria-approval`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.diretoriaApprove = async (pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/diretoria-approve`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.diretoriaRepprove = async (
            pid: number,
            motivoReprovacao: string
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/diretoria-repprove`,
                    motivoReprovacao
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.returnToDiretoria = async (
            pid: number,
            motivoReprovacao: string
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/return-to-diretoria`,
                    motivoReprovacao
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.returnToGrg = async (pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/return-to-grg`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.fixesDone = async (pid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/fixes-done`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.rdDeliberateDiretor = async (
            pid: number,
            votesWithAjustes: VoteWithAjustesProposicaoDto
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/rd-deliberate`,
                    votesWithAjustes
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.annotatePrevia = async (pid: number, annotation: string) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${pid}/annotate-previa`,
                    annotation
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
    }
}

export default ProposicoesApi;
