import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { AuthResponse } from "../../../models/responses.model";
import { AppState } from "../store";

const initialState: AuthResponse = new AuthResponse();

// Actual Slice
export const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        // Action to set the authentication status
        setAuthState(state, action: PayloadAction<AuthResponse>) {
            // state = action.payload;
            console.log(action.type);
            console.log(action.payload);

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

export const { setAuthState } = authSlice.actions;

export const selectAuthState = (state: AppState) => state.auth;

export default authSlice.reducer;
