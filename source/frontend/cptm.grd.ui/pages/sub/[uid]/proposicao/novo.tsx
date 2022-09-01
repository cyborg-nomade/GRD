import { Typography } from "@mui/material";
import { Stack } from "@mui/system";
import ProposicaoFormContainer from "components/forms/proposicao-form/ProposicaoFormContainer";
import React from "react";

const SubProposicaoNovo = () => {
    return (
        <Stack>
            <Typography variant="h4">Nova Proposição</Typography>
            <ProposicaoFormContainer new />
        </Stack>
    );
};

export default SubProposicaoNovo;
