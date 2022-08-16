import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { GroupDto, UserDto } from "../../../models/access-control.model";
import { AccessLevel } from "../../../models/common.model";
import { AuthResponse } from "../../../models/responses.model";
import { AppState } from "../store";

export interface AuthState {
    currentUser: UserDto;
    currentArea: GroupDto;
    token: string;
    tokenExpiration: string;
    isLoggedIn: boolean;
}

const initialState: AuthState = {
    currentArea: {
        diretoria: "",
        gerencia: "",
        id: 0,
        nome: "",
        sigla: "",
        siglaDiretoria: "",
        siglaGerencia: "",
    },
    currentUser: {
        areasAcesso: [],
        email: "",
        funcao: "",
        id: 0,
        nivelAcesso: AccessLevel.Sub,
        nome: "",
        usernameAd: "",
    },
    token: "",
    tokenExpiration: "",
    isLoggedIn: false,
};

export const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        login(state, action: PayloadAction<AuthResponse>) {
            state.currentUser = action.payload.user;
            state.currentArea = action.payload.user.areasAcesso[0];
            state.token = action.payload.token;
            state.tokenExpiration = action.payload.expirationDate;
            state.isLoggedIn = true;

            return state;
        },
        logout(state, action: PayloadAction<void>) {
            state = initialState;

            return state;
        },

        // // Special reducer for hydrating the state. Special case for next-redux-wrapper
        // extraReducers: {
        //     [HYDRATE]: (state, action) => {
        //         return {
        //             ...state,
        //             ...action.payload.auth,
        //         };
        //     },
        // },
    },
});

export const { login, logout } = authSlice.actions;

export const selectAuthState = (state: AppState) => state.auth;

export default authSlice.reducer;
