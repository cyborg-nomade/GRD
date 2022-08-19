import { useRouter } from "next/router";
import { useEffect } from "react";
import { useAuth } from "services/local-storage/auth-hook";

const Logout = () => {
    const { login, logout } = useAuth();
    const router = useRouter();

    useEffect(() => {
        const logoutHandler = () => {
            logout();
            console.log("hi");

            router.push("/");
        };

        logoutHandler();
        return () => {};
    }, [logout, router]);

    return <div>Logout</div>;
};

export default Logout;
