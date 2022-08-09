import axios from "axios";
import { handleError, handleResponse } from "./response.util";

const BASE_URL = process.env.REACT_APP_CONNSTR;

const getAll = async (resource: string) => {
    try {
        const response = await axios.get(`${BASE_URL}/${resource}`);
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const getSingle = async (resource: string, id: number) => {
    try {
        const response = await axios.get(`${BASE_URL}/${resource}/${id}`);
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const post = async (resource: string, model: object) => {
    try {
        const response = await axios.post(`${BASE_URL}/${resource}`, model);
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const put = async (resource: string, model: object) => {
    try {
        const response = await axios.put(`${BASE_URL}/${resource}`, model);
        return handleResponse(response);
    } catch (error) {
        return handleError(error);
    }
};

const remove = async (resource: string, id: number) => {
    try {
        const response = await axios.delete(`${BASE_URL}/${resource}/${id}`);
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
