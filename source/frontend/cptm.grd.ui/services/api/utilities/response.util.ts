import HttpException from "services/util/http-exception";

export function handleResponse(response: any) {
    if (response.results) {
        return response.results;
    }

    if (response.data) {
        return response.data;
    }

    return response;
}

export function handleError(error: any) {
    if (error.response) {
        console.log("error.response", error.response);

        throw new HttpException(
            error.response.status,
            error.response.data.title
        );
    } else if (error.request) {
        console.log("error.request", error.request);
        throw new HttpException(0, error.request);
    }
    console.log("error.message", error.message);
    throw new HttpException(1, error.message);
}
