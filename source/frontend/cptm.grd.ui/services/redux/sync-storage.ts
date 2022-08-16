import { persistReducer } from "redux-persist";
import createWebStorage from "redux-persist/lib/storage/createWebStorage";

const createNoopStorage = () => {
    return {
        getItem(_key: string) {
            console.log("loading state...", _key);

            return Promise.resolve(null);
        },
        setItem(_key: string, value: any) {
            console.log("saving state....", _key, value);

            return Promise.resolve(value);
        },
        removeItem(_key: string) {
            console.log("removing state...", _key);

            return Promise.resolve();
        },
    };
};

const storage =
    typeof window !== "undefined"
        ? createWebStorage("local")
        : createNoopStorage();

export default storage;
