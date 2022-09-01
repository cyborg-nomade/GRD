import { Stack, Typography } from "@mui/material";
import ProposicaoFormContainer from "components/forms/proposicao-form/ProposicaoFormContainer";
import { useRouter } from "next/router";

const SubProposicaoView = () => {
    const router = useRouter();
    const { pid } = router.query;

    return (
        <Stack>
            <Typography variant="h4">Editar Proposição</Typography>
            <ProposicaoFormContainer edit pid={pid ? +pid : 0} />
        </Stack>
    );
};

export default SubProposicaoView;
