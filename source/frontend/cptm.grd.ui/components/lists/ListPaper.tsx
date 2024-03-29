import Box from "@mui/material/Box";
import Paper from "@mui/material/Paper";
import React from "react";

const ListPaper = (props: { children?: React.ReactNode }) => {
    return (
        <Paper
            component="div"
            sx={{
                padding: "10px",
                margin: "auto",
                width: "100%",
                height: "100%",
                display: "flex",
            }}
        >
            <Box sx={{ flexGrow: 1 }}>{props.children}</Box>
        </Paper>
    );
};

export default ListPaper;
