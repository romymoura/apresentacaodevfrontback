import { AuthService } from './../auth/auth.service';
import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  //@Input() username: string;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
     //this.username = this.authService.getUsername();
  }

  public sigOut(): void {
    if ( this.authService.isAuthorized() ) {
      alert('sair');
      this.authService.sigOut();
      this.router.navigate(['/home']);
    }
  }
}