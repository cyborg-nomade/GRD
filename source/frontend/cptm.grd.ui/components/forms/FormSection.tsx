import Grid from "@mui/system/Unstable_Grid";
import React from "react";
import FormTitleDivider from "./FormTitleDivider";

const FormSection = (props: { title: string; children?: React.ReactNode }) => {
    return (
        <React.Fragment>
            <FormTitleDivider title={props.title} />
            <Grid container spacing={1}>
                {props.children}
            </Grid>
        </React.Fragment>
    );
};

export default FormSection;
