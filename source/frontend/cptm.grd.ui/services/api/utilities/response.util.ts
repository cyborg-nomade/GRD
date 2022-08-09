export function handleResponse(response: any) {
    console.log(response);

    if (response.results) {
        console.log(response.results);

        return response.results;
    }

    if (response.data) {
        console.log(response.data);

        return response.data;
    }

    return response;
}

export function handleError(error: any) {
    if (error.data) {
        return error.data;
    }
    return error;
}
