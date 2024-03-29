import Button from "@mui/material/Button";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import React from "react";

const ConfirmationModalView = (props: {
    open: boolean;
    handleClose: () => void;
    title: string;
    children?: React.ReactNode;
    disagreeHandler: () => void;
    agreeHandler: () => void;
}) => {
    return (
        <Dialog
            open={props.open}
            onClose={props.handleClose}
            aria-labelledby="alert-dialog-title"
            aria-describedby="alert-dialog-description"
        >
            <DialogTitle id="alert-dialog-title">{props.title}</DialogTitle>
            <DialogContent>
                <DialogContentText id="alert-dialog-description">
                    {props.children}
                </DialogContentText>
            </DialogContent>
            <DialogActions>
                <Button onClick={props.disagreeHandler} color="info" autoFocus>
                    Voltar
                </Button>
                <Button onClick={props.agreeHandler} color="warning">
                    Prosseguir
                </Button>
            </DialogActions>
        </Dialog>
    );
};

export default ConfirmationModalView;
