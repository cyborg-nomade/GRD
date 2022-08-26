import { Stack } from "@mui/material";
import Typography from "@mui/material/Typography";
import ProposicaoListContainer from "components/lists/proposicao-list/ProposicaoListContainer";

const SubHome = () => {
    return (
        <Stack>
            <Typography variant="h4">Home</Typography>
            <ProposicaoListContainer />
        </Stack>
    );
};

export default SubHome;
