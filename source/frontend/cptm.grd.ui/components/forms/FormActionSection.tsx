import Divider from "@mui/material/Divider";
import Grid from "@mui/system/Unstable_Grid";

import React from "react";

const FormActionSection = (props: { children?: React.ReactNode }) => {
    return (
        <React.Fragment>
            <Divider sx={{ marginTop: "20px", marginBottom: "5px" }} />
            <Grid container spacing={1}>
                {props.children}
            </Grid>
        </React.Fragment>
    );
};

export default FormActionSection;
