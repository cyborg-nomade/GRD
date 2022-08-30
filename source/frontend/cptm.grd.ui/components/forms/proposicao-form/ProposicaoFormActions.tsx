import { Button } from "@mui/material";
import React from "react";
import FormActionSection from "../FormActionSection";
import Grid from "@mui/system/Unstable_Grid";
import { CreateProposicaoDto } from "models/proposicoes/proposicao.model";
import { UseFormReturn } from "react-hook-form";
import { useAppSelector } from "services/redux/hooks";
import { useRouter } from "next/router";
import { getFirstError } from "services/util/getFirstError";

const ProposicaoFormActions = (props: {
    methods: UseFormReturn<CreateProposicaoDto>;
}) => {
    const authState = useAppSelector((state) => state.auth);
    const router = useRouter();

    const cancelarHandler = () => {
        router.back();
    };

    const cancelar = (
        <Button variant="outlined" color="error" onClick={cancelarHandler}>
            Cancelar
        </Button>
    );

    const salvarHandler = (proposicao: CreateProposicaoDto) => {
        console.log(proposicao);

        console.log(props.methods.formState.errors);
        props.methods.trigger();

        console.log(getFirstError(props.methods.formState.errors));
        props.methods.setFocus(getFirstError(props.methods.formState.errors));
    };

    const salvar = (
        <Button
            variant="contained"
            color="success"
            onClick={() => salvarHandler(props.methods.getValues())}
        >
            Salvar
        </Button>
    );

    const removerHandler = () => {};

    const remover = (
        <Button variant="contained" color="error" onClick={removerHandler}>
            Remover
        </Button>
    );

    const enviarAprovacaoHandler = () => {};

    const enviarAprovacao = (
        <Button
            variant="contained"
            color="warning"
            onClick={enviarAprovacaoHandler}
        >
            Enviar Para Aprovação
        </Button>
    );

    const retornarGrgHandler = () => {};

    const retornarGrg = (
        <Button
            variant="contained"
            color="warning"
            onClick={retornarGrgHandler}
        >
            Retornar à GRG
        </Button>
    );

    const aprovarHandler = () => {};

    const aprovar = (
        <Button variant="contained" color="success" onClick={aprovarHandler}>
            Aprovar
        </Button>
    );

    const reprovarHandler = () => {};

    const reprovar = (
        <Button variant="contained" color="error" onClick={reprovarHandler}>
            Reprovar
        </Button>
    );

    const incluirEmPautaHandler = () => {};

    const incluirEmPauta = (
        <Button
            variant="contained"
            color="success"
            onClick={incluirEmPautaHandler}
        >
            Incluir em Pauta
        </Button>
    );

    const retornarADiretoriaHandler = () => {};

    const retornarADiretoria = (
        <Button
            variant="contained"
            color="error"
            onClick={retornarADiretoriaHandler}
        >
            Retornar à Diretoria
        </Button>
    );

    const ajustesRealizadosHandler = () => {};

    const ajustesRealizados = (
        <Button
            variant="contained"
            color="success"
            onClick={ajustesRealizadosHandler}
        >
            Ajustes Realizados
        </Button>
    );

    return (
        <FormActionSection>
            <Grid
                xs={12}
                container
                justifyContent="space-between"
                alignItems="center"
                flexDirection={{ xs: "column", sm: "row" }}
                sx={{ fontSize: "12px" }}
            >
                <Grid sx={{ order: { xs: 2, sm: 1 } }}>{cancelar}</Grid>
                <Grid
                    container
                    columnSpacing={1}
                    sx={{ order: { xs: 1, sm: 2 } }}
                >
                    <Grid>{remover}</Grid>
                    <Grid>{enviarAprovacao}</Grid>
                    <Grid>{salvar}</Grid>
                </Grid>
            </Grid>
        </FormActionSection>
    );
};

export default ProposicaoFormActions;
