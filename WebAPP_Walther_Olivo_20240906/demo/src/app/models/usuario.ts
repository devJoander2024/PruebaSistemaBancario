export class Usuario {
    id : number;
    nombre: string;
    apellido: string;
    nombreUsuario: string;
    estado: string;
    email: string;
    password: string;
    constructor(nombre: string, apellido: string, nombreUsuario: string, estado: string, email: string, password: string) {
        this.nombre = nombre;
        this.apellido = apellido
        this.nombreUsuario = nombreUsuario;
        this.estado = estado;
        this.email = email;
        this.password = password;
    }
}
