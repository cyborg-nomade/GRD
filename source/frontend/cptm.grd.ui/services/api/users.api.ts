import axios from "axios";
import {
    AuthUser,
    CreateUserDto,
    UpdateUserDto,
    UserDto,
} from "../../models/access-control.model";
import { AccessLevel } from "../../models/common.model";
import { AuthResponse } from "../../models/responses.model";
import { ApiCore, ApiCoreOptions } from "./utilities/core.util";
import { handleError, handleResponse } from "./utilities/response.util";

const BASE_URL = process.env.NEXT_PUBLIC_CONNSTR;

const url = "users";
const plural = "users";
const single = "user";

// plural and single may be used for message logic if needed in the ApiCore class.

const usersApiOptions: ApiCoreOptions = {
    getAll: true,
    getSingle: true,
    post: true,
    put: true,
    remove: true,
    url,
};

class UsersApi extends ApiCore<UserDto, UserDto, CreateUserDto, UpdateUserDto> {
    login!: (user: AuthUser) => Promise<AuthResponse>;
    getByLevel!: (token: string, level: AccessLevel) => Promise<UserDto[]>;
    getByGroup!: (token: string, gid: number) => Promise<UserDto[]>;
    getByLevelAndGroup!: (
        token: string,
        level: AccessLevel,
        gid: number
    ) => Promise<UserDto[]>;

    constructor() {
        super(usersApiOptions);

        this.login = async (user: AuthUser) => {
            try {
                const response = await axios.post(
                    `${BASE_URL}/${url}/login`,
                    user
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByLevel = async (token: string, level: AccessLevel) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/level/${level}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByGroup = async (token: string, gid: number) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/group/${gid}`,
                    {
                        headers: { Authorization: `Bearer ${token}` },
                    }
                );
                return handleResponse(response);
            } catch (error) {
                return handleError(error);
            }
        };

        this.getByLevelAndGroup = async (
            token: string,
            level: AccessLevel,
            gid: number
        ) => {
            try {
                const response = await axios.get(
                    `${BASE_URL}/${url}/level/${level}/group/${gid}`,
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

export default UsersApi;
