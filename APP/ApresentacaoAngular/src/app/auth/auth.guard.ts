import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';


@Injectable()
export class AuthGuard implements CanActivate {

    constructor(
        private authService: AuthService,
        private router: Router
    ) {

    }
    canActivate(): boolean {
        const authorized = this.authService.isAuthorized();
        if (authorized)
            return true;
        else
           this.router.navigate(['/sign-in']);

    }
}