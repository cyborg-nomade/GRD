import React from "react";
import { useForm } from "react-hook-form";
import { AuthUser } from "models/access-control.model";
import { AuthResponse } from "models/responses.model";
import UsersApi from "services/api/users.api";
import { useAuth } from "services/local-storage/auth-hook";
import LoginFormView from "./LoginFormView";
import { useHttpClient } from "services/util/http-hook";

const LoginFormContainer = () => {
    const { login } = useAuth();
    const usersAPI = new UsersApi();
    const { clearError, error, isLoading, isWarning, sendRequest } =
        useHttpClient();

    const methods = useForm<AuthUser>({
        defaultValues: new AuthUser(),
        shouldFocusError: true,
    });

    const loginHandler = async (authUser: AuthUser) => {
        console.log(authUser);

        try {
            const authResponse: AuthResponse = await sendRequest<AuthResponse>(
                usersAPI.login,
                authUser
            );
            console.log(authResponse);
            login(authResponse);
        } catch (err) {
            console.log(err);
        }
    };

    return (
        <LoginFormView
            loginHandler={loginHandler}
            methods={methods}
            isLoading={isLoading}
            isWarning={isWarning}
            error={error}
            clearError={clearError}
        />
    );
};

export default LoginFormContainer;
