import axios from "axios";
import { handleError, handleResponse } from "./response.util";

const BASE_URL = process.env.NEXT_PUBLIC_CONNSTR;

const getAll = async (resource: string, token: string) => {
    try {
        const response = await axios.get(`${BASE_URL}/${resource}`, {
            headers: { Authorization: `Bearer ${token}` },
        });
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const getSingle = async (resource: string, token: string, id: number) => {
    try {
        const response = await axios.get(`${BASE_URL}/${resource}/${id}`, {
            headers: { Authorization: `Bearer ${token}` },
        });
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const post = async <CreateT>(
    resource: string,
    token: string,
    model: CreateT
) => {
    try {
        const response = await axios.post(`${BASE_URL}/${resource}`, model, {
            headers: { Authorization: `Bearer ${token}` },
        });
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const put = async <UpdateT>(
    resource: string,
    token: string,
    id: number,
    model: UpdateT
) => {
    try {
        const response = await axios.put(
            `${BASE_URL}/${resource}/${id}`,
            model,
            {
                headers: { Authorization: `Bearer ${token}` },
            }
        );
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const remove = async (resource: string, token: string, id: number) => {
    try {
        const response = await axios.delete(`${BASE_URL}/${resource}/${id}`, {
            headers: { Authorization: `Bearer ${token}` },
        });
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

export const apiProvider = {
    getAll,
    getSingle,
    post,
    put,
    remove,
};
