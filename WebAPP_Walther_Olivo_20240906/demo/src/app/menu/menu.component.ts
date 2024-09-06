import { Component, OnInit } from '@angular/core';
import { TokenService } from '../services/token/token.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  isLogged = false;
  isAdmin = false;

  constructor(private tokenService: TokenService) { }

  ngOnInit() {
   this.isLogged = this.tokenService.isLogged();
   this.isAdmin = this.tokenService.isAdmin();
   this.nombreUsuario = this.tokenService.getUserName();
  }

  onLogOut(): void {
    this.tokenService.logOut();
  }

  nombreUsuario: string;

  
   
 

}
