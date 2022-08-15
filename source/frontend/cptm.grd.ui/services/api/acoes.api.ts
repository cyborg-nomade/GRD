import axios from "axios";
import {
    AcaoDto,
    AcaoListDto,
    CreateAcaoDto,
    UpdateAcaoDto,
} from "../../models/acoes/acao.model";
import {
    AndamentoDto,
    CreateAndamentoDto,
} from "../../models/acoes/children/andamento.model";
import { AcaoStatus } from "../../models/common.model";
import { AddAcaoToReuniaoDto } from "../../models/mixed.model";
import { ApiCore, ApiCoreOptions } from "./utilities/core.util";
import { handleError, handleResponse } from "./utilities/response.util";

const BASE_URL = process.env.NEXT_PUBLIC_CONNSTR;

const url = "acoes";
const plural = "acoes";
const single = "acao";

// plural and single may be used for message logic if needed in the ApiCore class.

const acoesApiOptions: ApiCoreOptions = {
    getAll: true,
    getSingle: true,
    post: false,
    put: true,
    remove: true,
    url,
};

class AcoesApi extends ApiCore<
    AcaoDto,
    AcaoListDto,
    CreateAcaoDto,
    UpdateAcaoDto
> {
    getByReuniao!: (token: string, rid: number) => Promise<AcaoListDto[]>;
    getByResponsavel!: (token: string, uid: number) => Promise<AcaoListDto[]>;
    getFromSubordinados!: (
        token: string,
        suid: number
    ) => Promise<AcaoListDto[]>;
    postToReuniao!: (
        token: string,
        rid: number,
        createAcaoDto: CreateAcaoDto
    ) => Promise<AcaoDto>;
    addAndamento!: (
        token: string,
        aid: number,
        andamentoDto: CreateAndamentoDto
    ) => Promise<AcaoDto>;
    followUp!: (
        token: string,
        aid: number,
        rid: number
    ) => Promise<AddAcaoToReuniaoDto>;
    finish!: (
        token: string,
        aid: number,
        status: AcaoStatus
    ) => Promise<AcaoDto>;

    constructor() {
        super(acoesApiOptions);

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

        this.getByResponsavel = async (token: string, uid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/responsavel/${uid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getFromSubordinados = async (token: string, suid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/subordinados/${suid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.postToReuniao = async (
            token: string,
            rid: number,
            createAcaoDto: CreateAcaoDto
        ) => {
            try {
                const response = await axios.post(
                    `${BASE_URL}/${url}/reuniao/${rid}`,
                    createAcaoDto,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.addAndamento = async (
            token: string,
            aid: number,
            andamentoDto: CreateAndamentoDto
        ) => {
            try {
                const response = await axios.post(
                    `${BASE_URL}/${url}/${aid}/add-andamento`,
                    andamentoDto,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.followUp = async (token: string, aid: number, rid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${aid}/reuniao/${rid}/add`,
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

        this.finish = async (
            token: string,
            aid: number,
            status: AcaoStatus
        ) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${aid}/finish/${status}`,
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
    }
}

export default AcoesApi;
