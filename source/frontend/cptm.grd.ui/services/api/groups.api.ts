import axios from "axios";
import { GroupDto } from "../../models/access-control.model";
import { ApiCore, ApiCoreOptions } from "./utilities/core.util";
import { handleError, handleResponse } from "./utilities/response.util";

const BASE_URL = process.env.NEXT_PUBLIC_CONNSTR;

const url = "groups";
const plural = "groups";
const single = "group";

// plural and single may be used for message logic if needed in the ApiCore class.

const groupsApiOptions: ApiCoreOptions = {
    getAll: true,
    getSingle: true,
    post: false,
    put: false,
    remove: false,
    url,
};

class GroupsApi extends ApiCore<GroupDto> {
    getByUser!: (token: string, uid: number) => Promise<GroupDto[]>;

    constructor() {
        super(groupsApiOptions);

        this.getByUser = async (token: string, uid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/user/${uid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };
    }
}

export default GroupsApi;
