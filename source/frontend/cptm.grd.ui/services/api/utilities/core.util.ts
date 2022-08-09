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
    getAll!: () => Promise<ListT[]>;
    getSingle!: (id: number) => Promise<T>;
    post!: (model: CreateT) => Promise<T>;
    put!: (id: number, model: UpdateT) => Promise<T>;
    remove!: (id: number) => Promise<void>;

    constructor(options: ApiCoreOptions) {
        if (options.getAll) {
            this.getAll = () => apiProvider.getAll(options.url);
        }

        if (options.getSingle) {
            this.getSingle = (id: number) =>
                apiProvider.getSingle(options.url, id);
        }

        if (options.post) {
            this.post = <CreateT>(model: CreateT) =>
                apiProvider.post(options.url, model);
        }

        if (options.put) {
            this.put = <UpdateT>(id: number, model: UpdateT) =>
                apiProvider.put(options.url, id, model);
        }

        if (options.remove) {
            this.remove = (id: number) => apiProvider.remove(options.url, id);
        }
    }
}
