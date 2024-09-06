import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './index/index.component';
import { MenuComponent } from './menu/menu.component';
   import { LoginComponent } from './auth/components/login/login.component';
import { RegistroComponent } from './auth/components/registro/registro.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { interceptorProvider } from './services/interceptor/prod-interceptor.service';
import { FooterComponent } from './footer/footer.component';
import { ListaUsuariosComponent } from './usuarios/components/lista-usuarios/lista-usuarios.component';
import { DetalleUsuariosComponent } from './usuarios/components/detalle-usuarios/detalle-usuarios.component';
import { EditarUsuariosComponent } from './usuarios/components/editar-usuarios/editar-usuarios.component';
import { NuevoUsuarioComponent } from './usuarios/components/nuevo-usuario/nuevo-usuario.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { ResetPasswordComponent } from './usuarios/components/reset-password/reset-password.component';
import { PerfilComponent } from './usuarios/components/perfil/perfil.component';
import { PrestamosComponent } from './prestamos/components/prestamos/prestamos.component';
import { TipoprestamosComponent } from './tipoprestamos/components/tipoprestamos/tipoprestamos.component';
 
@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    MenuComponent,
       LoginComponent, RegistroComponent, FooterComponent, ListaUsuariosComponent, DetalleUsuariosComponent, EditarUsuariosComponent, NuevoUsuarioComponent, ResetPasswordComponent, PerfilComponent, PrestamosComponent, TipoprestamosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,  BrowserAnimationsModule,
    ToastrModule.forRoot(), NgxPaginationModule,
    HttpClientModule ,
    FormsModule
  ],
  providers: [interceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
