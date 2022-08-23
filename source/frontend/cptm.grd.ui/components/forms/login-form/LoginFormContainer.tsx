import React from "react";
import { useForm } from "react-hook-form";
import { AuthUser } from "models/access-control.model";
import { AuthResponse } from "models/responses.model";
import UsersApi from "services/api/users.api";
import { useAuth } from "services/local-storage/auth-hook";
import LoginFormView from "./LoginFormView";

const LoginFormContainer = () => {
    const { login } = useAuth();
    const usersAPI = new UsersApi();
    const methods = useForm<AuthUser>({
        defaultValues: new AuthUser(),
        shouldFocusError: true,
    });

    const loginHandler = async (authUser: AuthUser) => {
        console.log(authUser);

        const authResponse: AuthResponse = await usersAPI.login(authUser);
        console.log(authResponse);
        login(authResponse);
    };

    return <LoginFormView loginHandler={loginHandler} methods={methods} />;
};

export default LoginFormContainer;
