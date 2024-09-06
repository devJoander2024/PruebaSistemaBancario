export class User {
    userId : number;
    username: string;
    email: string;
    password: string;
    estado: string;
    Role: string;
    constructor(username: string,email: string, password: string, estado: string, Role: string) {
        this.username = username;
        this.email = email;
        this.password = password;
        this.estado = estado;
        this.Role = Role;
    }
}
