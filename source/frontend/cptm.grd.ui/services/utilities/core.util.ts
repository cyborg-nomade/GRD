// core.js

import { apiProvider } from "./provider.util";

type ApiCoreOptions = {
    getAll: any;
    getSingle: any;
    post: any;
    put: any;
    remove: any;

    url: string;
};

export class ApiCore {
    getAll!: () => Promise<object[]>;
    getSingle!: (id: number) => Promise<object>;
    post!: (model: object) => Promise<object>;
    put!: (model: object) => Promise<object>;
    remove!: (id: number) => Promise<any>;

    constructor(options: ApiCoreOptions) {
        if (options.getAll) {
            this.getAll = () => {
                return apiProvider.getAll(options.url);
            };
        }

        if (options.getSingle) {
            this.getSingle = (id: number) => {
                return apiProvider.getSingle(options.url, id);
            };
        }

        if (options.post) {
            this.post = (model: object) => {
                return apiProvider.post(options.url, model);
            };
        }

        if (options.put) {
            this.put = (model: object) => {
                return apiProvider.put(options.url, model);
            };
        }

        if (options.remove) {
            this.remove = (id: number) => {
                return apiProvider.remove(options.url, id);
            };
        }
    }
}
