import { AccessLevel } from "models/common.model";
import Router from "next/router";
import { useCallback, useEffect } from "react";
import { GroupDto } from "../../models/access-control.model";
import { AuthResponse } from "../../models/responses.model";
import { useAppDispatch, useAppSelector } from "../redux/hooks";
import {
    loginAction,
    logoutAction,
    changeLevelAction,
} from "../redux/slices/auth";

let logoutTimer: NodeJS.Timeout;

export const useAuth = () => {
    const authState = useAppSelector((state) => state.auth);
    const dispatch = useAppDispatch();

    const login = useCallback(
        (authResponse: AuthResponse) => {
            dispatch(loginAction(authResponse));

            console.log("responseToStore", authResponse);

            localStorage.setItem("authResponse", JSON.stringify(authResponse));

            switch (authResponse.user.nivelAcesso) {
                case AccessLevel.Sub:
                    Router.push(`/sub/${authResponse.user.id}`);
                    break;
                case AccessLevel.Gerente:
                    Router.push(`/gerente/${authResponse.user.id}`);
                    break;
                case AccessLevel.AssessorDiretoria:
                    Router.push(`/assessor-diretoria/${authResponse.user.id}`);
                    break;
                case AccessLevel.Diretor:
                    Router.push(`/diretoria/${authResponse.user.id}`);
                    break;
                case AccessLevel.Grg:
                    Router.push(`/grg/${authResponse.user.id}`);
                    break;
                case AccessLevel.SysAdmin:
                    Router.push(`/admin`);
                    break;

                default:
                    break;
            }
        },
        [dispatch]
    );

    const logout = useCallback(() => {
        dispatch(logoutAction());
        localStorage.removeItem("authResponse");
    }, [dispatch]);

    const changeGroup = (g: GroupDto) => {
        // setCurrentGroup(g);
        // console.log("change group, group: ", g);
        // setAreaTratamentoDados((prevState) => ({ ...prevState, area: g.nome }));
    };

    const changeLevel = useCallback(
        (l: AccessLevel) => {
            const storedAuthResponse = localStorage.getItem("authResponse");
            const authResponseObject: AuthResponse = storedAuthResponse
                ? JSON.parse(storedAuthResponse)
                : null;
            const storedExpirationDate = authResponseObject
                ? new Date(authResponseObject.expirationDate)
                : undefined;
            if (
                authResponseObject &&
                authResponseObject.token &&
                storedExpirationDate &&
                storedExpirationDate > new Date()
            ) {
                localStorage.removeItem("authResponse");
                dispatch(changeLevelAction(l));
                authResponseObject.user.nivelAcesso = l;
                localStorage.setItem(
                    "authResponse",
                    JSON.stringify(authResponseObject)
                );
            }
        },
        [dispatch]
    );

    //handle token expiration & auto-logout
    useEffect(() => {
        if (authState.token && authState.tokenExpiration) {
            const remainingTime =
                new Date(authState.tokenExpiration).getTime() -
                new Date().getTime();

            logoutTimer = setTimeout(logout, remainingTime);
        } else {
            clearTimeout(logoutTimer);
        }
        return () => {
            clearTimeout(logoutTimer);
        };
    }, [logout, authState.token, authState.tokenExpiration]);

    // auto-login
    useEffect(() => {
        const storedAuthResponse = localStorage.getItem("authResponse");
        const authResponseObject: AuthResponse = storedAuthResponse
            ? JSON.parse(storedAuthResponse)
            : null;
        const storedExpirationDate = authResponseObject
            ? new Date(authResponseObject.expirationDate)
            : undefined;
        if (
            authResponseObject &&
            authResponseObject.token &&
            storedExpirationDate &&
            storedExpirationDate > new Date()
        ) {
            login(authResponseObject);
        }
    }, [login]);

    return {
        login,
        logout,
        changeGroup,
        changeLevel,
    };
};
