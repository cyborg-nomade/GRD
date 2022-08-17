import "../styles/globals.css";
import type { AppProps } from "next/app";
import { wrapper } from "../services/redux/store";
import { useAuth } from "../services/local-storage/auth-hook";

function MyApp({ Component, pageProps }: AppProps) {
    useAuth();

    return <Component {...pageProps} />;
}

export default wrapper.withRedux(MyApp);
