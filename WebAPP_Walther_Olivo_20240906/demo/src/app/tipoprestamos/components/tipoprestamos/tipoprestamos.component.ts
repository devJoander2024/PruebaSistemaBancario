import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { GenericResponseDto } from 'src/app/models/geenericResponseDto';
import { TipoPrestamo } from 'src/app/models/tipoprestamo';
import { AuthService } from 'src/app/services/auth/auth.service';
import { TokenService } from 'src/app/services/token/token.service';
import { UsuariosService } from 'src/app/services/usuarios/usuario.service';

@Component({
  selector: 'app-tipoprestamos',
  templateUrl: './tipoprestamos.component.html',
  styleUrls: ['./tipoprestamos.component.scss']
})
export class TipoprestamosComponent {

  usuarios: TipoPrestamo[] = [];
  pageSize = 5;
  currentPage = 1;
  constructor(
    private usuariosService: UsuariosService,
    private toastr: ToastrService,
    private tokenService: TokenService,
    private authService: AuthService,
  ) { }
  ngOnInit() {
    this.cargarUsuarios();
  }
 
  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
    }
  }

  get totalItems(): number {
    return this.usuarios.length;
  }

  get totalPages(): number {
    return Math.ceil(this.totalItems / this.pageSize);
  }
  nuevoUsuario: TipoPrestamo;
  cantidad: string;
  descripcion: string;
  email: string;
  estado: string;
  apellido: string;
  password: string;
  errMsj: string;

  get pages(): number[] {
    return Array.from({ length: this.totalPages }, (_, i) => i + 1);
  }
  cargarUsuarios(): void {
    this.authService.listaTipoPrestamo().subscribe(
      (response: GenericResponseDto<TipoPrestamo[]>) => {
        this.usuarios = response.data;
      },
      err => {
        console.log(err);
      }
    );
  }

}
