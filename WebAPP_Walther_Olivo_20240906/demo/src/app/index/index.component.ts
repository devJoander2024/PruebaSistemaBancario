import { Component, OnInit } from '@angular/core';
import { TokenService } from '../services/token/token.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent  implements OnInit {

  nombreUsuario: string;
   isLogged = false
  constructor(private tokenService: TokenService) { }

  ngOnInit() {
   
      this.nombreUsuario = this.tokenService.getUserName();
      this.isLogged = this.tokenService.isLogged();
      
  }

}
