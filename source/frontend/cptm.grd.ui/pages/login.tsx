import { AuthUser } from "models/access-control.model";
import { AccessLevel } from "models/common.model";
import { AuthResponse } from "models/responses.model";
import { useRouter } from "next/router";
import { useEffect } from "react";
import UsersApi from "services/api/users.api";
import { useAuth } from "services/local-storage/auth-hook";

const Login = () => {
    const { login, logout } = useAuth();
    const router = useRouter();

    useEffect(() => {
        const loginHandler = async () => {
            const authUser = new AuthUser();
            authUser.username = "urielf";
            authUser.password = "H2CKQ3A1q&Sq";
            const usersAPI = new UsersApi();

            const authResponse: AuthResponse = await usersAPI.login(authUser);
            console.log(authResponse);
            login(authResponse);

            switch (authResponse.user.nivelAcesso) {
                case AccessLevel.Sub:
                    router.push(`/sub/${authResponse.user.id}`);
                    break;
                case AccessLevel.Gerente:
                    router.push(`/gerente/${authResponse.user.id}`);
                    break;
                case AccessLevel.AssessorDiretoria:
                    router.push(`/assessor-diretoria/${authResponse.user.id}`);
                    break;
                case AccessLevel.Diretor:
                    router.push(`/diretoria/${authResponse.user.id}`);
                    break;
                case AccessLevel.Grg:
                    router.push(`/grg/${authResponse.user.id}`);
                    break;
                case AccessLevel.SysAdmin:
                    router.push(`/admin`);
                    break;

                default:
                    break;
            }
        };

        loginHandler();
        return () => {};
    }, [login, router]);

    return <div>Login Page</div>;
};

export default Login;
