import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';
import { $ } from 'protractor';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  public username: string;
  public password: string;
  public siging: boolean;

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    if (this.authService.isAuthorized()) {
      alert('Usuário já logado');
      this.router.navigate(['/home']);
    }
  }

  public signin(): void {
    this.authService.sigin(this.username, this.password)
      .subscribe((result) => {
        if ( result.status === 1) {
          this.authService.saveToken(result.value.token, result.value.fullname);
          this.router.navigate(['/airplanes']);
        } else {
          alert(result.message);
        }
      }, (error) => {
         console.log(error);
         alert(error.error);
      });
  }
}
