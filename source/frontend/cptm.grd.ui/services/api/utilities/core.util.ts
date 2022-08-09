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

export class ApiCore<T> {
    getAll!: () => Promise<T[]>;
    getSingle!: (id: number) => Promise<T>;
    post!: (model: object) => Promise<T>;
    put!: (model: object) => Promise<T>;
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
            this.post = <T>(model: T) => apiProvider.post(options.url, model);
        }

        if (options.put) {
            this.put = <T>(model: T) => apiProvider.put(options.url, model);
        }

        if (options.remove) {
            this.remove = (id: number) => apiProvider.remove(options.url, id);
        }
    }
}
