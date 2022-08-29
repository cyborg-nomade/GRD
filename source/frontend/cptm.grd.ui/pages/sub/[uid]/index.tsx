import { Stack } from "@mui/material";
import Typography from "@mui/material/Typography";
import ProposicaoListContainer from "components/lists/proposicao-list/ProposicaoListContainer";

const SubHome = () => {
    return (
        <Stack width={"100%"}>
            <Typography variant="h4">
                Início - Todos as suas Proposições
            </Typography>
            <ProposicaoListContainer byUser />
        </Stack>
    );
};

export default SubHome;
