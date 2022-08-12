import type { NextPage } from "next";
import Head from "next/head";
import Image from "next/image";
import { useState } from "react";
import {
    AuthUser,
    CreateUserDto,
    GroupDto,
    UserDto,
} from "../models/access-control.model";
import {
    ObjetoProposicao,
    ProposicaoStatus,
    TipoVotoRd,
} from "../models/common.model";
import { AddProposicaoToReuniaoDto } from "../models/mixed.model";
import {
    CreateProposicaoDto,
    ProposicaoDto,
    UpdateProposicaoDto,
    VoteWithAjustesProposicaoDto,
} from "../models/proposicoes/proposicao.model";
import { AuthResponse, EstruturaResponse } from "../models/responses.model";
import {
    CreateReuniaoDto,
    ReuniaoDto,
    UpdateReuniaoDto,
} from "../models/reunioes/reuniao.model";
import GroupsApi from "../services/api/groups.api";
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
    const [estrutura, setEstrutura] = useState(new EstruturaResponse());
    const [dir1, setDir1] = useState(new UserDto());
    const [dir2, setDir2] = useState(new UserDto());
    const [dir3, setDir3] = useState(new UserDto());

    const usersAPI = new UsersApi();
    const groupsAPI = new GroupsApi();
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
        voteWithAjustesdir1.votoDto.participanteId = dir1.id;
        voteWithAjustesdir1.votoDto.votoRd = TipoVotoRd.Aprovacao;

        const voteWithAjustesdir2 = new VoteWithAjustesProposicaoDto();
        voteWithAjustesdir2.votoDto.participanteId = dir2.id;
        voteWithAjustesdir2.votoDto.votoRd = TipoVotoRd.Aprovacao;

        const voteWithAjustesdir3 = new VoteWithAjustesProposicaoDto();
        voteWithAjustesdir3.votoDto.participanteId = dir3.id;
        voteWithAjustesdir3.votoDto.votoRd = TipoVotoRd.Aprovacao;

        const response: ProposicaoDto = await proposicaoAPI.rdDeliberateDiretor(
            token,
            createdProposicao.id,
            [voteWithAjustesdir1, voteWithAjustesdir2, voteWithAjustesdir3]
        );

        console.log(response);
    };

    const diretorVotesHandler = async () => {
        const voteWithAjustes = new VoteWithAjustesProposicaoDto();
        voteWithAjustes.votoDto.participanteId = currentUser.id;
        voteWithAjustes.votoDto.votoRd = TipoVotoRd.Aprovacao;
        voteWithAjustes.ajustes = "teste ajuste";
        const response: ProposicaoDto = await proposicaoAPI.rdDeliberateDiretor(
            token,
            createdProposicao.id,
            [voteWithAjustes]
        );
        console.log(response);
    };

    const grgEmitsResolucaoDiretoriaForProposicaoHandler = async () => {
        const response = await reuniaoAPI.getResolucaoDiretoriaFile(
            token,
            createdReuniao.id,
            createdProposicao.id
        );
        console.log(response);
    };

    const diretoriaSendProposicaoBackToGrgAfterFixesHandler = async () => {
        const response = await proposicaoAPI.returnToGrg(
            token,
            createdProposicao.id
        );
        console.log(response);
    };

    const grgMarksFixesDoneHandler = async () => {
        const response = await proposicaoAPI.fixesDone(
            token,
            createdProposicao.id
        );
        console.log(response);
    };

    const proposicaoGetsHandler = async () => {
        const get1 = await proposicaoAPI.getAll(token);
        console.log(get1);
        const get2 = await proposicaoAPI.getByGroup(token, currentArea.id);
        console.log(get2);
        const get3 = await proposicaoAPI.getByGroupAndStatus(
            token,
            currentArea.id,
            ProposicaoStatus.AprovadaRd,
            false
        );
        console.log(get3);
        const get4 = await proposicaoAPI.getByReuniao(token, createdReuniao.id);
        console.log(get4);
        const get5 = await proposicaoAPI.getByReuniaoPrevia(
            token,
            createdReuniao.id
        );
        console.log(get5);
        const get6 = await proposicaoAPI.getByStatus(
            token,
            ProposicaoStatus.AprovadaRd,
            false
        );
        console.log(get6);
        const get7 = await proposicaoAPI.getByUser(token, currentUser.id);
        console.log(get7);
        const get8 = await proposicaoAPI.getByUserAndStatus(
            token,
            currentUser.id,
            ProposicaoStatus.AprovadaRd,
            false
        );
        console.log(get8);
        const get9 = await proposicaoAPI.getSingle(token, createdProposicao.id);
        console.log(get9);
    };

    const postReuniaoHandler = async () => {
        const reuniao = new CreateReuniaoDto();
        reuniao.data = new Date("2022-08-12");
        reuniao.horario = new Date("2022-08-12");
        reuniao.dataPrevia = new Date("2022-08-11");
        reuniao.horarioPrevia = new Date("2022-08-11");
        reuniao.local = "teste";

        const gilsac = new CreateUserDto();
        gilsac.usernameAd = "GILSAC";

        const argenton = new CreateUserDto();
        argenton.usernameAd = "ARGENTON";

        const marcelom = new CreateUserDto();
        marcelom.usernameAd = "MARCELOM";

        const participante1 = await usersAPI.post(token, gilsac);
        const participante2 = await usersAPI.post(token, argenton);
        const participante3 = await usersAPI.post(token, marcelom);

        setDir1(participante1);
        setDir2(participante2);
        setDir3(participante3);

        reuniao.participantesIds.push(
            participante1.id,
            participante2.id,
            participante3.id,
            currentUser.id
        );

        var createdReuniao = await reuniaoAPI.post(token, reuniao);
        console.log(createdReuniao);
        setCreatedReuniao(createdReuniao);
    };

    const editReuniaoHandler = async () => {
        const gottenReuniao = await reuniaoAPI.getSingle(
            token,
            createdReuniao.id
        );

        let reuniaoWithChanges = new UpdateReuniaoDto();
        reuniaoWithChanges = { ...gottenReuniao };
        reuniaoWithChanges.local = "teste update";

        const updatedProposicao = await reuniaoAPI.put(
            token,
            createdReuniao.id,
            reuniaoWithChanges
        );
        console.log(updatedProposicao);
        setCreatedReuniao(updatedProposicao);
    };

    const grgEmitsPautaPreviaHandler = async () => {
        const response: ReuniaoDto = await reuniaoAPI.getPautaPreviaFile(
            token,
            createdReuniao.id
        );
        console.log(response);
        setCreatedReuniao(response);
    };

    const annotateProposicaoInPreviaHandler = async () => {
        const response = await proposicaoAPI.annotatePrevia(
            token,
            createdProposicao.id,
            "teste anotação"
        );
        console.log(response);
    };

    const grgEmitsMemoriaPreviaHandler = async () => {
        const response: ReuniaoDto = await reuniaoAPI.getMemoriaPreviaFile(
            token,
            createdReuniao.id
        );
        console.log(response);
        setCreatedReuniao(response);
    };

    const grgEmitsPautaDefinitivaHandler = async () => {
        const response: ReuniaoDto = await reuniaoAPI.getPautaDefinitivaFile(
            token,
            createdReuniao.id
        );
        console.log(response);
        setCreatedReuniao(response);
    };

    const reuniaoScreenHandler = async () => {
        const reuniao = await reuniaoAPI.getSingle(token, createdReuniao.id);
        console.log(reuniao);
        const reuniaoProposicoes = await proposicaoAPI.getByReuniao(
            token,
            createdReuniao.id
        );
        console.log(reuniaoProposicoes);
    };

    const grgEmitsRelatorioDeliberativoHandler = async () => {
        const response: ReuniaoDto =
            await reuniaoAPI.getRelatorioDeliberativoFile(
                token,
                createdReuniao.id
            );
        console.log(response);
        setCreatedReuniao(response);
    };

    const getEstruturaHandler = async () => {
        const estrutura: EstruturaResponse = await groupsAPI.getEstrutura(
            token
        );
        console.log(estrutura);
        setEstrutura(estrutura);
    };

    const createGroupHandler = async () => {
        const group3 = await groupsAPI.postWithSigla(
            token,
            estrutura.gerencias[2]
        );
        console.log(group3);
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
                    <a className={styles.card} onClick={diretorVotesHandler}>
                        <h2>Diretor Vota &rarr;</h2>
                        <p>UC #009</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgEmitsResolucaoDiretoriaForProposicaoHandler}
                    >
                        <h2>
                            Emitir Resolução Diretoria para Proposição &rarr;
                        </h2>
                        <p>UC #010</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={
                            diretoriaSendProposicaoBackToGrgAfterFixesHandler
                        }
                    >
                        <h2>Diretoria devolve à GRG após correções &rarr;</h2>
                        <p>UC #011</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgMarksFixesDoneHandler}
                    >
                        <h2>GRG aprova correções &rarr;</h2>
                        <p>UC #012</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={proposicaoGetsHandler}>
                        <h2>Pesquisar Proposições &rarr;</h2>
                        <p>UC #013</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={postReuniaoHandler}>
                        <h2>Criar Reunião &rarr;</h2>
                        <p>UC #014</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={editReuniaoHandler}>
                        <h2>Editar Reunião &rarr;</h2>
                        <p>UC #015</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgAddsProposicaoToReuniaoHandler}
                    >
                        <h2>GRG adiciona Proposição a uma Reunião &rarr;</h2>
                        <p>UC #016</p>
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

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={annotateProposicaoInPreviaHandler}
                    >
                        <h2>Anotar Proposição na Prévia &rarr;</h2>
                        <p>UC #018</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgEmitsMemoriaPreviaHandler}
                    >
                        <h2>Emitir Memória Prévia &rarr;</h2>
                        <p>UC #019</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgEmitsPautaDefinitivaHandler}
                    >
                        <h2>Emitir Pauta Definitiva &rarr;</h2>
                        <p>UC #020</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={reuniaoScreenHandler}>
                        <h2>Tela de Reunião &rarr;</h2>
                        <p>UC #021</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a
                        className={styles.card}
                        onClick={grgEmitsRelatorioDeliberativoHandler}
                    >
                        <h2>Emitir Relatório Deliberativo &rarr;</h2>
                        <p>UC #023</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={getEstruturaHandler}>
                        <h2>Obter Estrutura &rarr;</h2>
                        <p>Utility</p>
                    </a>
                </div>

                <div className={styles.grid}>
                    <a className={styles.card} onClick={createGroupHandler}>
                        <h2>Criar Grupo &rarr;</h2>
                        <p>Utility</p>
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
