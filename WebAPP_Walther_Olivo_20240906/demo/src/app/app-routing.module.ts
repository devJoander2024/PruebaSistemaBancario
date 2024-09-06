import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './index/index.component';
import { LoginComponent } from './auth/components/login/login.component';
import { RegistroComponent } from './auth/components/registro/registro.component';
import { ProdGuardService as guard } from './services/guards/prod-guard.service';
import { ListaUsuariosComponent } from './usuarios/components/lista-usuarios/lista-usuarios.component';
import { DetalleUsuariosComponent } from './usuarios/components/detalle-usuarios/detalle-usuarios.component';
import { EditarUsuariosComponent } from './usuarios/components/editar-usuarios/editar-usuarios.component';
import { NuevoUsuarioComponent } from './usuarios/components/nuevo-usuario/nuevo-usuario.component';
import { ResetPasswordComponent } from './usuarios/components/reset-password/reset-password.component';
import { PerfilComponent } from './usuarios/components/perfil/perfil.component';
import { PrestamosComponent } from './prestamos/components/prestamos/prestamos.component';
import { TipoprestamosComponent } from './tipoprestamos/components/tipoprestamos/tipoprestamos.component';


const routes: Routes = [
  { path: '', component: IndexComponent },
  { path: 'login', component: LoginComponent },
  { path: 'registro', component: RegistroComponent },
  { path: 'listar-tipo-prestamos', component: TipoprestamosComponent },
  { path: 'listar-prestamos', component: PrestamosComponent },
  { path: 'listar-usuarios', component: ListaUsuariosComponent },
  { path: 'detalleUser/:id', component: DetalleUsuariosComponent, canActivate: [guard], data: { expectedRol: ['admin', 'user'] } },
  { path: 'detalleUser/:id', component: PerfilComponent, canActivate: [guard], data: { expectedRol: ['admin', 'user'] } },
  { path: 'editarUser/:id', component: EditarUsuariosComponent, canActivate: [guard], data: { expectedRol: ['admin'] } },
  { path: 'nuevoUser', component: NuevoUsuarioComponent, canActivate: [guard], data: { expectedRol: ['admin'] } },

  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
