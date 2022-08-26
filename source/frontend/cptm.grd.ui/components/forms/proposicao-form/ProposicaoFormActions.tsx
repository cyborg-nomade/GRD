import { Button } from "@mui/material";
import React from "react";
import FormActionSection from "../FormActionSection";
import Grid from "@mui/system/Unstable_Grid";

const ProposicaoFormActions = () => {
    const cancelar = (
        <Button variant="outlined" color="error">
            Cancelar
        </Button>
    );

    const salvar = (
        <Button variant="contained" color="success">
            Salvar
        </Button>
    );

    const remover = (
        <Button variant="contained" color="error">
            Remover
        </Button>
    );

    const enviarAprovacao = (
        <Button variant="contained" color="warning">
            Enviar Para Aprovação
        </Button>
    );

    const retornarGrg = (
        <Button variant="contained" color="warning">
            Retornar à GRG
        </Button>
    );

    const aprovar = (
        <Button variant="contained" color="success">
            Aprovar
        </Button>
    );

    const reprovar = (
        <Button variant="contained" color="error">
            Reprovar
        </Button>
    );

    const incluirEmPauta = (
        <Button variant="contained" color="success">
            Incluir em Pauta
        </Button>
    );

    const retornarADiretoria = (
        <Button variant="contained" color="error">
            Retornar à Diretoria
        </Button>
    );

    const ajustesRealizados = (
        <Button variant="contained" color="success">
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
