export class LoginDto {
    UsernameOrEmail: string;
    Password: string;
    constructor(UsernameOrEmail: string, Password: string) {
        this.UsernameOrEmail = UsernameOrEmail;
        this.Password = Password;
    }
}
