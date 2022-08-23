import { Button, Container, Paper, TextField, Typography } from "@mui/material";
import { Stack } from "@mui/system";
import { AuthUser } from "models/access-control.model";
import React from "react";
import { Controller, UseFormReturn } from "react-hook-form";

const LoginFormView = (props: {
    loginHandler: (authUser: AuthUser) => {};
    methods: UseFormReturn<AuthUser>;
}) => {
    return (
        <Paper
            component="form"
            sx={{ width: "28rem", padding: "10px", margin: "auto" }}
            onSubmit={props.methods.handleSubmit(props.loginHandler)}
        >
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
                <Button variant="contained" type="submit">
                    Login
                </Button>
            </Stack>
        </Paper>
    );
};

export default LoginFormView;
