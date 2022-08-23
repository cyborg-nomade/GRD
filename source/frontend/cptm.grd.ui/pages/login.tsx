import { AuthUser } from "models/access-control.model";

import { AuthResponse } from "models/responses.model";
import { useEffect } from "react";
import UsersApi from "services/api/users.api";
import { useAuth } from "services/local-storage/auth-hook";

const Login = () => {
    const { login, logout } = useAuth();

    useEffect(() => {
        const loginHandler = async () => {
            const authUser = new AuthUser();
            authUser.username = "urielf";
            authUser.password = "H2CKQ3A1q&Sq";
            const usersAPI = new UsersApi();

            const authResponse: AuthResponse = await usersAPI.login(authUser);
            console.log(authResponse);
            login(authResponse);
        };

        loginHandler();
        return () => {};
    }, [login]);

    return <div>Login Page</div>;
};

export default Login;
