import axios from "axios";
import {
    AcaoDto,
    AcaoListDto,
    CreateAcaoDto,
    UpdateAcaoDto,
} from "../../models/acoes/acao.model";
import { AndamentoDto } from "../../models/acoes/children/andamento.model";
import { AcaoStatus } from "../../models/common.model";
import { AddAcaoToReuniaoDto } from "../../models/mixed.model";
import { ApiCore, ApiCoreOptions } from "./utilities/core.util";
import { handleError, handleResponse } from "./utilities/response.util";

const BASE_URL = process.env.REACT_APP_CONNSTR;

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
    getByReuniao!: (rid: number) => Promise<AcaoListDto[]>;
    getByResponsavel!: (uid: number) => Promise<AcaoListDto[]>;
    getFromSubordinados!: (suid: number) => Promise<AcaoListDto[]>;
    postToReuniao!: (
        rid: number,
        createAcaoDto: CreateAcaoDto
    ) => Promise<AcaoDto>;
    addAndamento!: (
        aid: number,
        andamentoDto: AndamentoDto
    ) => Promise<AcaoDto>;
    followUp!: (aid: number, rid: number) => Promise<AddAcaoToReuniaoDto>;
    finish!: (aid: number, status: AcaoStatus) => Promise<AcaoDto>;

    constructor() {
        super(acoesApiOptions);

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

        this.getByResponsavel = async (uid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/responsavel/${uid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getFromSubordinados = async (suid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/subordinados/${suid}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.postToReuniao = async (
            rid: number,
            createAcaoDto: CreateAcaoDto
        ) => {
            try {
                const response = await axios.post(
                    `${BASE_URL}/${url}/reuniao/${rid}`,
                    createAcaoDto
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.addAndamento = async (aid: number, andamentoDto: AndamentoDto) => {
            try {
                const response = await axios.post(
                    `${BASE_URL}/${url}/${aid}/add-andamento`,
                    andamentoDto
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.followUp = async (aid: number, rid: number) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${aid}/reuniao/${rid}/add`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.finish = async (aid: number, status: AcaoStatus) => {
            try {
                const response = await axios.put(
                    `${BASE_URL}/${url}/${aid}/finish/${status}`
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
    }
}

export default AcoesApi;
