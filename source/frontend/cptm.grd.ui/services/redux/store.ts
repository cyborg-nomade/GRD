import { configureStore, ThunkAction, Action } from "@reduxjs/toolkit";
import { createWrapper } from "next-redux-wrapper";
import reducers from "./reducers";
import { authInitialState } from "./slices/auth";

const makeStore = () => {
    return configureStore({
        reducer: reducers,
        devTools: true,
        preloadedState: {
            auth: authInitialState,
        },
    });
};

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
