import axios from "axios";
import { handleError, handleResponse } from "./response.util";

const BASE_URL = process.env.REACT_APP_CONNSTR;

const getAll = (resource: string) => {
    return axios
        .get(`${BASE_URL}/${resource}`)
        .then(handleResponse)
        .catch(handleError);
};

const getSingle = (resource: string, id: number) => {
    return axios
        .get(`${BASE_URL}/${resource}/${id}`)
        .then(handleResponse)
        .catch(handleError);
};

const post = (resource: string, model: object) => {
    return axios
        .post(`${BASE_URL}/${resource}`, model)
        .then(handleResponse)
        .catch(handleError);
};

const put = (resource: string, model: object) => {
    return axios
        .put(`${BASE_URL}/${resource}`, model)
        .then(handleResponse)
        .catch(handleError);
};

const remove = (resource: string, id: number) => {
    return axios
        .delete(`${BASE_URL}/${resource}/${id}`)
        .then(handleResponse)
        .catch(handleError);
};

export const apiProvider = {
    getAll,
    getSingle,
    post,
    put,
    remove,
};
