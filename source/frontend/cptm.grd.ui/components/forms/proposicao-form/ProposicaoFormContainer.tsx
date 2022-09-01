import {
    CreateProposicaoDto,
    ProposicaoDto,
    ProposicaoListDto,
} from "models/proposicoes/proposicao.model";
import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import ProposicoesApi from "services/api/proposicoes.api";
import { useAppSelector } from "services/redux/hooks";
import { useHttpClient } from "services/util/http-hook";
import ProposicaoFormView from "./ProposicaoFormView";

const ProposicaoFormContainer = (props: {
    edit?: boolean;
    pid?: number;
    new?: boolean;
}) => {
    const authState = useAppSelector((state) => state.auth);
    const [proposicaoToEdit, setProposicaoToEdit] = useState(
        new CreateProposicaoDto()
    );

    const { clearError, error, isLoading, isWarning, sendRequest } =
        useHttpClient();

    const methods = useForm<CreateProposicaoDto>({
        defaultValues: new CreateProposicaoDto(),
        shouldFocusError: true,
    });

    useEffect(
        () => methods.reset(proposicaoToEdit),
        [methods, proposicaoToEdit]
    );

    useEffect(() => {
        const getProposicaoToEdit = async () => {
            const proposicaoAPI = new ProposicoesApi();
            try {
                const proposicaoToEdit: ProposicaoDto =
                    await sendRequest<ProposicaoDto>(
                        proposicaoAPI.getSingle,
                        authState.token,
                        props.pid
                    );
                console.log(proposicaoToEdit);
                setProposicaoToEdit(proposicaoToEdit);
            } catch (err) {
                console.log(err);
            }
        };

        if (props.edit) {
            getProposicaoToEdit();
        }

        return () => {
            setProposicaoToEdit(new CreateProposicaoDto());
        };
    }, [
        authState.currentUser.id,
        authState.token,
        props.edit,
        props.pid,
        sendRequest,
    ]);

    return (
        <ProposicaoFormView
            methods={methods}
            clearError={clearError}
            error={error}
            isLoading={isLoading}
            isWarning={isWarning}
            showFiles={!props.edit || false}
        />
    );
};

export default ProposicaoFormContainer;
