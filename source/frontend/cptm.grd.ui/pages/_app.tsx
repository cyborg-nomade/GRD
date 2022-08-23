import "../styles/globals.css";
import type { AppProps } from "next/app";
import { wrapper } from "../services/redux/store";
import { useAuth } from "../services/local-storage/auth-hook";
import React, { useEffect } from "react";
import Head from "next/head";
import CssBaseline from "@mui/material/CssBaseline";
import NavbarView from "components/nav/NavbarView";
import { createTheme, ThemeProvider } from "@mui/material";
import { useAppSelector } from "services/redux/hooks";
import { useRouter } from "next/router";

const theme = createTheme({
    palette: {
        primary: {
            main: "#455a64",
            light: "#718792",
            dark: "#1c313a",
        },
        secondary: {
            main: "#424242",
            light: "#6d6d6d",
            dark: "#1b1b1b",
        },
    },
});

function MyApp({ Component, pageProps }: AppProps) {
    useAuth();
    const authState = useAppSelector((state) => state.auth);
    const router = useRouter();

    useEffect(() => {
        if (authState.currentUser.id === 0) {
            router.push("/login");
        }
    }, [authState.currentUser.id, router]);

    return (
        <React.Fragment>
            <CssBaseline />
            <Head>
                <title>
                    CPTM - GRD - Sistema de Gestão de Reuniões de Diretoria
                </title>
                <meta
                    name="Sistema de Gestão de Reuniões de Diretoria"
                    content="Criado por Uriel Fiori"
                />
                <meta
                    name="viewport"
                    content="initial-scale=1, width=device-width"
                />
                <link rel="icon" href="/favicon.ico" />
            </Head>
            <ThemeProvider theme={theme}>
                <NavbarView>
                    <Component {...pageProps} />
                </NavbarView>
            </ThemeProvider>
        </React.Fragment>
    );
}

export default wrapper.withRedux(MyApp);
