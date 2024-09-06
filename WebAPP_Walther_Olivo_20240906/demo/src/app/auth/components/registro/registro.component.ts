import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NuevoUsuario } from 'src/app/models/nuevo-usuario';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.scss']
})
export class RegistroComponent implements OnInit {

  nuevoUsuario: NuevoUsuario;
  nombre: string;
  nombreUsuario: string;
  email: string;
  estado: string;
  apellido: string;
  password: string;
  errMsj: string;

  constructor(
     private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
  }

  onRegister(): void {
    this.nuevoUsuario = new NuevoUsuario(this.nombre,  this.apellido,  this.nombreUsuario, this.estado, this.email, this.password);
    this.authService.nuevo(this.nuevoUsuario).subscribe(
      data => {
        this.toastr.success(data.mensaje, 'OK', {
          timeOut: 3000, positionClass: 'toast-top-center'
        });
        this.router.navigate(['/login']);
      },
      err => {
        this.toastr.error('Ingresa datos válidos', 'Error', {
          timeOut: 2000, positionClass: 'toast-top-center'
        });
      }
    );
  }

}