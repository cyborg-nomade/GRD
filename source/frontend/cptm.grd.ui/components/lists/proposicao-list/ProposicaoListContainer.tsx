import { ProposicaoListDto } from "models/proposicoes/proposicao.model";
import React, { useEffect, useState } from "react";
import ProposicoesApi from "services/api/proposicoes.api";
import { useAppSelector } from "services/redux/hooks";
import { useHttpClient } from "services/util/http-hook";
import ProposicaoListView from "./ProposicaoListView";

const ProposicaoListContainer = (props: { byUser?: boolean }) => {
    const authState = useAppSelector((state) => state.auth);
    const [proposicoes, setProposicoes] = useState<ProposicaoListDto[]>([]);

    const { clearError, error, isLoading, isWarning, sendRequest } =
        useHttpClient();

    useEffect(() => {
        const getProposicaoListByUserHandler = async () => {
            const proposicaoAPI = new ProposicoesApi();
            try {
                const proposicaoList: ProposicaoListDto[] = await sendRequest<
                    ProposicaoListDto[]
                >(
                    proposicaoAPI.getByUser,
                    authState.token,
                    authState.currentUser.id
                );
                console.log(proposicaoList);
                setProposicoes(proposicaoList);
            } catch (err) {
                console.log(err);
            }
        };

        if (props.byUser) {
            getProposicaoListByUserHandler();
        }

        return () => {
            setProposicoes([]);
        };
    }, [authState.currentUser.id, authState.token, props.byUser, sendRequest]);

    return <ProposicaoListView rows={proposicoes} isLoading={isLoading} />;
};

export default ProposicaoListContainer;
