import { Login } from "@mui/icons-material";
import { LoadingButton } from "@mui/lab";
import {
    Alert,
    AlertTitle,
    Button,
    Container,
    Paper,
    TextField,
    Typography,
} from "@mui/material";
import { Stack } from "@mui/system";
import { AuthUser } from "models/access-control.model";
import React from "react";
import { Controller, UseFormReturn } from "react-hook-form";

const LoginFormView = (props: {
    loginHandler: (authUser: AuthUser) => {};
    methods: UseFormReturn<AuthUser>;
    isLoading: boolean;
    isWarning: boolean;
    error: any;
    clearError: () => void;
}) => {
    return (
        <Paper
            component="form"
            sx={{ width: "28rem", padding: "10px", margin: "auto" }}
            onSubmit={props.methods.handleSubmit(props.loginHandler)}
        >
            {props.error && (
                <Alert
                    severity={props.isWarning ? "warning" : "error"}
                    onClose={props.clearError}
                >
                    <AlertTitle>
                        {props.isWarning ? "Atenção" : "Erro"}
                    </AlertTitle>
                    {props.error}
                </Alert>
            )}
            <Stack spacing={2}>
                <Typography variant="h6" ml={1}>
                    Login
                </Typography>
                <Controller
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    control={props.methods.control}
                    name="username"
                    render={({ field: { onChange, onBlur, value, ref } }) => (
                        <TextField
                            id="username"
                            required
                            label="Usuário"
                            ref={ref}
                            value={value}
                            onChange={onChange}
                            onBlur={onBlur}
                        />
                    )}
                />
                <Controller
                    rules={{
                        required: true,
                        maxLength: 250,
                    }}
                    control={props.methods.control}
                    name="password"
                    render={({ field: { onChange, onBlur, value, ref } }) => (
                        <TextField
                            id="password"
                            required
                            label="Senha"
                            type="password"
                            ref={ref}
                            value={value}
                            onChange={onChange}
                            onBlur={onBlur}
                        />
                    )}
                />
                <LoadingButton
                    variant="contained"
                    type="submit"
                    loading={props.isLoading}
                    loadingPosition="start"
                    startIcon={<Login />}
                >
                    Login
                </LoadingButton>
            </Stack>
        </Paper>
    );
};

export default LoginFormView;
