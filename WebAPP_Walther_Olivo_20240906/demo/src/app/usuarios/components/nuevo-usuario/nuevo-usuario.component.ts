import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models/usuario';
import { UsuariosService } from 'src/app/services/usuarios/usuario.service';

@Component({
  selector: 'app-nuevo-usuario',
  templateUrl: './nuevo-usuario.component.html',
  styleUrls: ['./nuevo-usuario.component.scss']
})
export class NuevoUsuarioComponent {

    nombre = '';
    apellido = '';
    nombreUsuario  = '';
    estado = '';
    email = '';
    password = '';

  constructor(
    private usuariosService: UsuariosService,
    private toastr: ToastrService,
    private router: Router
    ) { }

  ngOnInit() {
  }

  onCreate(): void {
    const producto = new Usuario(this.nombre, this.apellido, this.nombreUsuario, this.estado, this.email, this.password);
    this.usuariosService.createUsuario(producto).subscribe(
      data => {
        this.toastr.success('Producto Creado', 'OK', {
          timeOut: 2000, positionClass: 'toast-top-center'
        });
        this.router.navigate(['/listar-usuarios']);
      },
      err => {
        this.toastr.error(err.error.mensaje, 'Fail', {
          timeOut: 2000,  positionClass: 'toast-top-center',
        });
      }
    );
  }

}