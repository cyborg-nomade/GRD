import { UserDto } from "./access-control.model";

export class AuthResponse {
    user!: UserDto;
    token!: string;
    expirationDate!: Date;

    constructor() {
        this.user = new UserDto();
        this.token = "";
        this.expirationDate = new Date();
    }
}
