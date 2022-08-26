import { ProposicaoListDto } from "models/proposicoes/proposicao.model";
import React, { useEffect, useState } from "react";
import ProposicoesApi from "services/api/proposicoes.api";
import { useAppSelector } from "services/redux/hooks";
import { useHttpClient } from "services/util/http-hook";
import ProposicaoListView from "./ProposicaoListView";

const ProposicaoListContainer = () => {
    const authState = useAppSelector((state) => state.auth);
    const [proposicoes, setProposicoes] = useState<ProposicaoListDto[]>([]);

    const { clearError, error, isLoading, isWarning, sendRequest } =
        useHttpClient();

    useEffect(() => {
        const getProposicaoListHandler = async () => {
            const proposicaoAPI = new ProposicoesApi();
            try {
                const proposicaoList: ProposicaoListDto[] = await sendRequest<
                    ProposicaoListDto[]
                >(proposicaoAPI.getAll, authState.token);
                console.log(proposicaoList);
                setProposicoes(proposicaoList);
            } catch (err) {
                console.log(err);
            }
        };

        getProposicaoListHandler();

        return () => {
            setProposicoes([]);
        };
    }, [authState.token, sendRequest]);

    return <ProposicaoListView rows={proposicoes} />;
};

export default ProposicaoListContainer;
