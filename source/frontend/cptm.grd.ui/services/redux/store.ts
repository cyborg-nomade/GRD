import { configureStore, ThunkAction, Action } from "@reduxjs/toolkit";
import { createWrapper } from "next-redux-wrapper";
import { authSlice } from "./slices/auth";
import thunkMiddleware from "redux-thunk";
import { persistStore } from "redux-persist";
import persistMiddleware from "./middleware/persistMiddleware";

const makeStore = () => {
    return configureStore({
        reducer: {
            [authSlice.name]: authSlice.reducer,
            // other reducers
        },
        devTools: true,
        middleware: (getDefaultMiddleware) =>
            getDefaultMiddleware()
                .concat(thunkMiddleware)
                .concat(persistMiddleware),
    });
};

export const persistor = persistStore(makeStore());
export const store = makeStore();
export type AppStore = ReturnType<typeof makeStore>;
export type AppState = ReturnType<AppStore["getState"]>;
export type AppDispatch = AppStore["dispatch"];
export type AppThunk<ReturnType = void> = ThunkAction<
    ReturnType,
    AppState,
    unknown,
    Action
>;

export const wrapper = createWrapper<AppStore>(makeStore);
