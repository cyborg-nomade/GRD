import { CreateAcaoDto } from "models/acoes/acao.model";
import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import React from "react";
import { useForm } from "react-hook-form";
import { useHttpClient } from "services/util/http-hook";
import ProposicaoFormView from "./ProposicaoFormView";

const ProposicaoFormContainer = () => {
    const { clearError, error, isLoading, isWarning, sendRequest } =
        useHttpClient();

    const methods = useForm<CreateProposicaoDto>({
        defaultValues: new CreateProposicaoDto(),
        shouldFocusError: true,
    });

    const saveProposicaoHandler = (proposicao: CreateProposicaoDto) => {
        console.log(proposicao);
        return {};
    };

    return (
        <ProposicaoFormView
            methods={methods}
            clearError={clearError}
            error={error}
            isLoading={isLoading}
            isWarning={isWarning}
            saveProposicaoHandler={saveProposicaoHandler}
        />
    );
};

export default ProposicaoFormContainer;
