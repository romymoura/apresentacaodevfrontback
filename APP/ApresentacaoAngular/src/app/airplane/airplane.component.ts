import { AuthService } from './../auth/auth.service';
import { AirplaneService } from './../airplane.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-airplane',
  templateUrl: './airplane.component.html',
  styleUrls: ['./airplane.component.css']
})

export class AirplaneComponent implements OnInit {

  constructor(private airplaneService: AirplaneService, private authService: AuthService, private router: Router) {
  }

  ngOnInit() {
    if (!this.authService.isAuthorized()) {
      alert('Usuário precisa estar logado!');
      this.router.navigate(['/home']);
      return;
    } else {
      this.airplaneService.getAll();
    }
  }

}
