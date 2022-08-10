import type { NextPage } from "next";
import Head from "next/head";
import Image from "next/image";
import { useState } from "react";
import { AuthUser, GroupDto, UserDto } from "../models/access-control.model";
import { ObjetoProposicao } from "../models/common.model";
import {
    CreateProposicaoDto,
    ProposicaoDto,
    UpdateProposicaoDto,
} from "../models/proposicoes/proposicao.model";
import { AuthResponse } from "../models/responses.model";
import ProposicoesApi from "../services/api/proposicoes.api";
import UsersApi from "../services/api/users.api";
import styles from "../styles/Home.module.css";

const Home: NextPage = () => {
    const [token, setToken] = useState("");
    const [currentUser, setCurrentUser] = useState(new UserDto());
    const [currentArea, setCurrentArea] = useState(new GroupDto());
    const [createdProposicao, setCreatedProposicao] = useState(
        new ProposicaoDto()
    );

    const usersAPI = new UsersApi();
    const proposicaoAPI = new ProposicoesApi();

    const loginHandler = async () => {
        const authUser = new AuthUser();
        authUser.username = "urielf";
        authUser.password = "W$BcEbrgq33!";

        const authResponse: AuthResponse = await usersAPI.login(authUser);
        console.log(authResponse);
        setToken(authResponse.token);
        setCurrentUser(authResponse.user);
        setCurrentArea(authResponse.user.areasAcesso[0]);
    };

    const postProposicaoHandler = async () => {
        const proposicao = new CreateProposicaoDto();
        proposicao.criador = currentUser;
        proposicao.area = currentArea;
        proposicao.titulo = "teste API";
        proposicao.descricaoProposicao = "teste1";
        proposicao.possuiParecerJuridico = false;
        proposicao.resumoGeralResolucao = "teste1";
        proposicao.observacoesCustos = "teste";
        proposicao.competenciasConformeNormas = "teste";
        proposicao.dataBaseValor = new Date();
        proposicao.moeda = "real";
        proposicao.valorOriginalContrato = 100;
        proposicao.valorTotalProposicao = 100;
        proposicao.numeroContrato = "100";
        proposicao.termo = "teste";
        proposicao.fornecedor = "fornecedor teste";
        proposicao.valorAtualContrato = 100;
        proposicao.numeroReservaVerba = "100";
        proposicao.valorReservaVerba = 100;
        proposicao.inicioVigenciaReserva = new Date();
        proposicao.fimVigenciaReserva = new Date();
        proposicao.numeroProposicao = "1000";
        proposicao.protocoloExpediente = "1000f";
        proposicao.numeroProcessoLicit = "1f1";
        proposicao.cronogramaFisFinFilePath = "C:\\";
        proposicao.editalFilePath = "C:\\";
        proposicao.notaTecnicaFilePath = "C:\\";
        proposicao.parecerJuridicoFilePath = "C:\\";
        proposicao.pcaFilePath = "C:\\";
        proposicao.planilhaQuantFilePath = "C:\\";
        proposicao.prdFilePath = "C:\\";
        proposicao.ravFilePath = "C:\\";
        proposicao.relatorioTecnicoFilePath = "C:\\";
        proposicao.reservaVerbaFilePath = "C:\\";
        proposicao.scFilePath = "C:\\";
        proposicao.sinteseProcessoFilePath = "C:\\";
        proposicao.trFilePath = "C:\\";
        proposicao.objeto = ObjetoProposicao.Aditamento;

        const proposicaoReturn: ProposicaoDto = await proposicaoAPI.post(
            token,
            proposicao
        );
        console.log(proposicaoReturn);
        setCreatedProposicao(proposicaoReturn);
    };

    const editProposicaoHandler = async () => {
        const gottenProposicao = await proposicaoAPI.getSingle(
            token,
            createdProposicao.id
        );
        console.log(gottenProposicao);

        let proposicaoWithChanges = new UpdateProposicaoDto();
        proposicaoWithChanges = { ...gottenProposicao };
        proposicaoWithChanges.titulo = "teste update";
        console.log(proposicaoWithChanges);

        const updatedProposicao = await proposicaoAPI.put(
            token,
            createdProposicao.id,
            proposicaoWithChanges
        );
        console.log(updatedProposicao);
    };

    const removeProposicaoHandler = async () => {
        await proposicaoAPI.remove(token, createdProposicao.id);
        console.log("it worked?");
    };

    const sendToApprovalHandler = async () => {
        const proposicaoSentToApproval =
            await proposicaoAPI.sendDiretoriaApproval(
                token,
                createdProposicao.id
            );
        console.log(proposicaoSentToApproval);
    };

    const diretorApprovesHandler = async () => {
        const proposicaoApproved = await proposicaoAPI.diretoriaApprove(
            token,
            createdProposicao.id
        );
        console.log(proposicaoApproved);
    };

    const diretorRepprovesHandler = async () => {
        const proposicaoRepproved = await proposicaoAPI.diretoriaRepprove(
            token,
            createdProposicao.id,
            "teste motivo"
        );
        console.log(proposicaoRepproved);
    };

    return (
        <div className={styles.container}>
            <Head>
                <title>CPTM - GRD</title>
                <meta
                    name="description"
                    content="Generated by create next app"
                />
                <link rel="icon" href="/favicon.ico" />
            </Head>

            <main className={styles.main}>
                <h1 className={styles.title}>CPTM - GRD</h1>

                <p className={styles.description}>Teste de API</p>
                <p className={styles.description}>Token: {token}</p>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={loginHandler}>
                        <h2>Login &rarr;</h2>
                        <p>UC #001</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={postProposicaoHandler}>
                        <h2>Criar Proposição &rarr;</h2>
                        <p>UC #002</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={editProposicaoHandler}>
                        <h2>Editar Proposição &rarr;</h2>
                        <p>UC #003</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={removeProposicaoHandler}
                    >
                        <h2>Remover Proposição &rarr;</h2>
                        <p>UC #004</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={sendToApprovalHandler}>
                        <h2>Enviar Proposição para Aprovação &rarr;</h2>
                        <p>UC #005</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={diretorApprovesHandler}>
                        <h2>Diretor Aprova Proposição &rarr;</h2>
                        <p>UC #005</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={diretorRepprovesHandler}
                    >
                        <h2>Diretor Reprova Proposição &rarr;</h2>
                        <p>UC #005</p>
                    </a>
                </div>
            </main>

            <footer className={styles.footer}>
                <a
                    href="https://vercel.com?utm_source=create-next-app&utm_medium=default-template&utm_campaign=create-next-app"
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Powered by{" "}
                    <span className={styles.logo}>
                        <Image
                            src="/vercel.svg"
                            alt="Vercel Logo"
                            width={72}
                            height={16}
                        />
                    </span>
                </a>
            </footer>
        </div>
    );
};

export default Home;
