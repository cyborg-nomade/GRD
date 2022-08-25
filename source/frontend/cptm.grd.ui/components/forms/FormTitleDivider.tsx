import { Chip } from "@mui/material";
import Divider from "@mui/material/Divider";
import Typography from "@mui/material/Typography";
import React from "react";

const FormTitleDivider = (props: { title: string }) => {
    return (
        <Divider
            textAlign="left"
            sx={{ marginTop: "25px", marginBottom: "5px" }}
        >
            <Chip
                color="primary"
                label={<Typography variant="button">{props.title}</Typography>}
            />
        </Divider>
    );
};

export default FormTitleDivider;
