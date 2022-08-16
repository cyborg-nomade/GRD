import "../styles/globals.css";
import type { AppProps } from "next/app";
import { persistor, wrapper } from "../services/redux/store";
import { PersistGate } from "redux-persist/integration/react";

function MyApp({ Component, pageProps }: AppProps) {
    return (
        <PersistGate persistor={persistor} loading={<div>Loading</div>}>
            <Component {...pageProps} />;
        </PersistGate>
    );
}

export default wrapper.withRedux(MyApp);
