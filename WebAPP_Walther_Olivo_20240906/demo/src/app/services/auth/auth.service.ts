import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NuevoUsuario } from '../../models/nuevo-usuario';
import { Observable } from 'rxjs';
import { LoginUsuario } from '../../models/login-usuario';
import { JwtDTO } from '../../models/jwt-dto';
import { environment } from 'src/assets/environments/environment';
import { User } from 'src/app/models/user';
import { LoginDto } from 'src/app/models/LoginDto';
import { GenericResponseDto } from 'src/app/models/geenericResponseDto';
import { Prestamo } from 'src/app/models/prestamos';
import { TipoPrestamo } from 'src/app/models/tipoprestamo';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  authURL = environment.api
  constructor(private httpClient: HttpClient) { }

  public nuevo(nuevoUsuario: NuevoUsuario): Observable<any> {
    return this.httpClient.post<any>(this.authURL + 'nuevo', nuevoUsuario);
  }

  public login(loginUsuario: LoginUsuario): Observable<JwtDTO> {
    return this.httpClient.post<JwtDTO>(this.authURL + 'login', loginUsuario);
  }

  public refresh(dto: JwtDTO): Observable<JwtDTO> {
    return this.httpClient.post<JwtDTO>(this.authURL + 'refresh', dto);
  }

  public loggin(loginDto: LoginDto): Observable<LoginDto> {
    return this.httpClient.post<LoginDto>(this.authURL + 'User/Login', loginDto);
  }

  public lista(): Observable<GenericResponseDto<User[]>> {
    return this.httpClient.get<GenericResponseDto<User[]>>(this.authURL + 'User');
  }

  public listaPrestamos(): Observable<GenericResponseDto<Prestamo[]>> {
    return this.httpClient.get<GenericResponseDto<Prestamo[]>>(this.authURL + 'Prestamo');
  }

  public listaTipoPrestamo(): Observable<GenericResponseDto<TipoPrestamo[]>> {
    return this.httpClient.get<GenericResponseDto<TipoPrestamo[]>>(this.authURL + 'TipoPrestamo');
  }
}
