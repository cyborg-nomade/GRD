import Box from "@mui/material/Box";
import Paper from "@mui/material/Paper";
import React from "react";

const FormPaper = (props: { children?: React.ReactNode }) => {
    return (
        <Paper
            component="form"
            sx={{ padding: "10px", margin: "auto", width: "100%" }}
        >
            <Box sx={{ flexGrow: 1 }}>{props.children}</Box>
        </Paper>
    );
};

export default FormPaper;
