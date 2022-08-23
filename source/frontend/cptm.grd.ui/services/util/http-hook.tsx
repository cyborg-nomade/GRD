import { useCallback, useEffect, useRef, useState } from "react";
import HttpException from "./http-exception";

export const useHttpClient = () => {
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);
    const [isWarning, setIsWarning] = useState(false);

    const activeHttpRequests = useRef<AbortController[]>([]);

    const sendRequest = useCallback(
        async <T,>(request: (...args: any[]) => Promise<T>, ...args: any[]) => {
            setIsLoading(true);
            const httpAbortController = new AbortController();
            activeHttpRequests.current.push(httpAbortController);

            try {
                console.log(args);

                const response = await request(args);
                console.log("response: ", response);

                activeHttpRequests.current = activeHttpRequests.current.filter(
                    (reqCtrl) => reqCtrl !== httpAbortController
                );

                setIsLoading(false);
                return response;
            } catch (error: any) {
                console.log("hook error log: ", error);

                setIsLoading(false);
                setError(error.message);
                if (error.status > 402 && error.status < 500) {
                    setIsWarning(true);
                }
                throw error;
            }
        },
        []
    );

    const clearError = () => {
        setError(null);
    };

    useEffect(() => {
        return () => {
            activeHttpRequests.current.forEach((abortCtrl) =>
                abortCtrl.abort()
            );
            setIsLoading(false);
            setError(null);
        };
    }, []);

    return { isLoading, error, isWarning, sendRequest, clearError };
};
