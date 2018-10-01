import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(private authService: AuthService, private router: Router, private alertify: AlertifyService) { }

    // Return booleans indicating if a user can access a particular page or not
    canActivate(): Observable<boolean> | Promise<boolean> | boolean {
        // If user is logged in, allow them to access their pages
        if (this.authService.loggedIn()) {
            return true;
        }

        // If user is not logged in, return an error when they try to access a page for logged in users
        this.alertify.error('You need to be logged in to access this area');
        // After displaying the error, reroute the user back to the home page
        this.router.navigate(['/home']);
        return false;
    }
}