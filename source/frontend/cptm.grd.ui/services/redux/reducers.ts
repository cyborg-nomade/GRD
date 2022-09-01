import { combineReducers } from "@reduxjs/toolkit";
import { authSlice } from "./slices/auth";

export const rootReducers = combineReducers({
    [authSlice.name]: authSlice.reducer,
});

export default rootReducers;
