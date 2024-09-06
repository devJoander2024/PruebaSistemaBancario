import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UsuariosService } from 'src/app/services/usuarios/usuario.service';

@Component({
  selector: 'app-editar-usuarios',
  templateUrl: './editar-usuarios.component.html',
  styleUrls: ['./editar-usuarios.component.scss']
})
export class EditarUsuariosComponent {


  usuario: any;

  constructor(
    private usuarioService: UsuariosService,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router
  ) { } 

  ngOnInit() {
    const id = this.activatedRoute.snapshot.params['id'];
    this.usuarioService.getUsuarioById(id).subscribe(
      data => {
        this.usuario = data;
      },
      err => {
        this.toastr.error(err.error.mensaje, 'Fail', {
          timeOut: 2000,  positionClass: 'toast-top-center',
        });
        this.router.navigate(['/']);
      }
    );
  }

  onUpdate(): void {
    const id = this.activatedRoute.snapshot.params['id'];
    this.usuarioService.updateUsuario(id, this.usuario).subscribe(
      data => {
        this.toastr.success('Producto Actualizado', 'OK', {
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
