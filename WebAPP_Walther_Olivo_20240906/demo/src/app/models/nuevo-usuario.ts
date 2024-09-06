export class NuevoUsuario {
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
        this.estado = 'A'
        this.email = email;
        this.password = password;
    }
}
