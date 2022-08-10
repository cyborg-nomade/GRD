// core.js

import { apiProvider } from "./provider.util";

export type ApiCoreOptions = {
    getAll: any;
    getSingle: any;
    post: any;
    put: any;
    remove: any;

    url: string;
};

export class ApiCore<T, ListT = T, CreateT = T, UpdateT = T> {
    getAll!: (token: string) => Promise<ListT[]>;
    getSingle!: (token: string, id: number) => Promise<T>;
    post!: (token: string, model: CreateT) => Promise<T>;
    put!: (token: string, id: number, model: UpdateT) => Promise<T>;
    remove!: (token: string, id: number) => Promise<void>;

    constructor(options: ApiCoreOptions) {
        if (options.getAll) {
            this.getAll = (token: string) =>
                apiProvider.getAll(options.url, token);
        }

        if (options.getSingle) {
            this.getSingle = (token: string, id: number) =>
                apiProvider.getSingle(options.url, token, id);
        }

        if (options.post) {
            this.post = <CreateT>(token: string, model: CreateT) =>
                apiProvider.post(options.url, token, model);
        }

        if (options.put) {
            this.put = <UpdateT>(token: string, id: number, model: UpdateT) =>
                apiProvider.put(options.url, token, id, model);
        }

        if (options.remove) {
            this.remove = (token: string, id: number) =>
                apiProvider.remove(options.url, token, id);
        }
    }
}
