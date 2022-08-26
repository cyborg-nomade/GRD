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
            }}
        >
            <Box sx={{ flexGrow: 1, height: "600px" }}>{props.children}</Box>
        </Paper>
    );
};

export default ListPaper;
