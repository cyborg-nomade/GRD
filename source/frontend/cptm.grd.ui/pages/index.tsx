import type { NextPage } from "next";
import Head from "next/head";
import Image from "next/image";
import { useState } from "react";
import { AuthUser, GroupDto, UserDto } from "../models/access-control.model";
import { ObjetoProposicao, TipoVotoRd } from "../models/common.model";
import { AddProposicaoToReuniaoDto } from "../models/mixed.model";
import {
    CreateProposicaoDto,
    ProposicaoDto,
    UpdateProposicaoDto,
    VoteWithAjustesProposicaoDto,
} from "../models/proposicoes/proposicao.model";
import { AuthResponse } from "../models/responses.model";
import {
    CreateParticipanteDto,
    ParticipanteDto,
} from "../models/reunioes/children/participante.model";
import { CreateReuniaoDto, ReuniaoDto } from "../models/reunioes/reuniao.model";
import ProposicoesApi from "../services/api/proposicoes.api";
import ReunioesApi from "../services/api/reunioes.api";
import UsersApi from "../services/api/users.api";
import styles from "../styles/Home.module.css";

const Home: NextPage = () => {
    const [token, setToken] = useState("");
    const [currentUser, setCurrentUser] = useState(new UserDto());
    const [currentArea, setCurrentArea] = useState(new GroupDto());
    const [createdProposicao, setCreatedProposicao] = useState(
        new ProposicaoDto()
    );
    const [createdReuniao, setCreatedReuniao] = useState(new ReuniaoDto());

    const usersAPI = new UsersApi();
    const proposicaoAPI = new ProposicoesApi();
    const reuniaoAPI = new ReunioesApi();

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
        setCreatedProposicao(updatedProposicao);
    };

    const removeProposicaoHandler = async () => {
        await proposicaoAPI.remove(token, createdProposicao.id);
        console.log("it worked?");
        setCreatedProposicao(new ProposicaoDto());
    };

    const sendToApprovalHandler = async () => {
        const proposicaoSentToApproval: ProposicaoDto =
            await proposicaoAPI.sendDiretoriaApproval(
                token,
                createdProposicao.id
            );
        console.log(proposicaoSentToApproval);
        setCreatedProposicao(proposicaoSentToApproval);
    };

    const diretorApprovesHandler = async () => {
        const proposicaoApproved: ProposicaoDto =
            await proposicaoAPI.diretoriaApprove(token, createdProposicao.id);
        console.log(proposicaoApproved);
        setCreatedProposicao(proposicaoApproved);
    };

    const diretorRepprovesHandler = async () => {
        const proposicaoRepproved: ProposicaoDto =
            await proposicaoAPI.diretoriaRepprove(
                token,
                createdProposicao.id,
                "teste motivo"
            );
        console.log(proposicaoRepproved);
        setCreatedProposicao(proposicaoRepproved);
    };

    const grgAddsProposicaoToReuniaoHandler = async () => {
        var response: AddProposicaoToReuniaoDto =
            await reuniaoAPI.addProposicao(
                token,
                createdReuniao.id,
                createdProposicao.id
            );

        console.log(response);
    };

    const grgCoordinatesVoteHandler = async () => {
        const voteWithAjustesdir1 = new VoteWithAjustesProposicaoDto();
        voteWithAjustesdir1.votoDto.participante =
            createdReuniao.participantes[0];
        voteWithAjustesdir1.votoDto.votoRd = TipoVotoRd.Aprovacao;
        const voteWithAjustesdir2 = new VoteWithAjustesProposicaoDto();
        voteWithAjustesdir2.votoDto.participante =
            createdReuniao.participantes[1];
        voteWithAjustesdir2.votoDto.votoRd = TipoVotoRd.Aprovacao;
        const voteWithAjustesdir3 = new VoteWithAjustesProposicaoDto();
        voteWithAjustesdir3.votoDto.participante =
            createdReuniao.participantes[3];
        voteWithAjustesdir3.votoDto.votoRd = TipoVotoRd.Aprovacao;

        const response: ProposicaoDto = await proposicaoAPI.rdDeliberateDiretor(
            token,
            createdProposicao.id,
            [voteWithAjustesdir1, voteWithAjustesdir2, voteWithAjustesdir3]
        );

        console.log(response);
    };

    const postReuniaoHandler = async () => {
        const reuniao = new CreateReuniaoDto();
        reuniao.data = new Date("2022-08-12");
        reuniao.horario = new Date("2022-08-12");
        reuniao.dataPrevia = new Date("2022-08-11");
        reuniao.horarioPrevia = new Date("2022-08-11");
        reuniao.local = "teste";

        const participante1 = new CreateParticipanteDto();
        participante1.nome = "dir1";
        participante1.email = "dir1@teste.com";
        participante1.area = currentArea;

        const participante2 = new CreateParticipanteDto();
        participante2.nome = "dir2";
        participante2.email = "dir2@teste.com";
        participante2.area = currentArea;

        const participante3 = new CreateParticipanteDto();
        participante3.nome = "dir3";
        participante3.email = "dir3@teste.com";
        participante3.area = currentArea;

        reuniao.participantes.push(participante1, participante2, participante3);

        var createdReuniao = await reuniaoAPI.post(token, reuniao);
        console.log(createdReuniao);
        setCreatedReuniao(createdReuniao);
    };

    const grgEmitsPautaPreviaHandler = async () => {
        const response: ReuniaoDto = await reuniaoAPI.getPautaPreviaFile(
            token,
            createdReuniao.id
        );
        console.log(response);
        setCreatedReuniao(response);
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
                        <p>UC #006</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={diretorRepprovesHandler}
                    >
                        <h2>Diretor Reprova Proposição &rarr;</h2>
                        <p>UC #006</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgAddsProposicaoToReuniaoHandler}
                    >
                        <h2>GRG adiciona Proposição a uma Reunião &rarr;</h2>
                        <p>UC #007</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgCoordinatesVoteHandler}
                    >
                        <h2>GRG coordena votos em reunião &rarr;</h2>
                        <p>UC #008</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={postReuniaoHandler}>
                        <h2>Criar Reunião &rarr;</h2>
                        <p>UC #014</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgEmitsPautaPreviaHandler}
                    >
                        <h2>Emitir Pauta Prévia &rarr;</h2>
                        <p>UC #017</p>
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
