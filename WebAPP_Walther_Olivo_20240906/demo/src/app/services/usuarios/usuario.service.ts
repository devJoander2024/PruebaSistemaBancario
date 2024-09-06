import { Injectable } from '@angular/core';
import { environment } from 'src/assets/environments/environment';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from 'src/app/models/usuario';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  usuarioURL = environment.usuarioURL;
  authURL = environment.authURL;


  constructor(private httpClient: HttpClient) { }


  public lista(): Observable<Usuario[]> {
    return this.httpClient.get<Usuario[]>(this.usuarioURL + 'listar-usuarios');
  }

  createUsuario(usuario:Usuario): Observable<Object>{
    return this.httpClient.post(this.authURL + 'nuevo', usuario );
  }

  deleteUsuario(id:number,  usuario:Usuario  ): Observable<Object>{
    return  this.httpClient.put(this.usuarioURL +  `delete/${id}`, usuario)
    
  }

  getUsuarioById(id:number): Observable<Usuario>{
    return  this.httpClient.get<Usuario>( this.usuarioURL  +  `detail/${id}`);
  }

  updateUsuario(id:number,  usuario:Usuario): Observable<Object>{
    return  this.httpClient.put(this.usuarioURL +  `update/${id}`, usuario);
  }



}
