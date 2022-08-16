import { UserDto } from "./access-control.model";

export class AuthResponse {
    user!: UserDto;
    token!: string;
    expirationDate!: string;

    constructor() {
        this.user = new UserDto();
        this.token = "";
        this.expirationDate = new Date().toISOString();
    }
}

export class EstruturaResponse {
    diretorias!: string[];
    gerenciasGerais!: string[];
    gerencias!: string[];
    departamentos!: string[];

    constructor() {
        this.diretorias = [];
        this.gerencias = [];
        this.gerenciasGerais = [];
        this.departamentos = [];
    }
}
