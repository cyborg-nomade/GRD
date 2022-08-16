import { combineReducers } from "@reduxjs/toolkit";
import { persistReducer } from "redux-persist";
import { authSlice } from "./slices/auth";
import storage from "./sync-storage";

const rootPersistConfig = {
    key: "root",
    storage,
};

export const rootReducers = combineReducers({
    [authSlice.name]: authSlice.reducer,
});

export default persistReducer(rootPersistConfig, rootReducers);
