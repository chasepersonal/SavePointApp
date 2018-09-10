import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );

  constructor(private breakpointObserver: BreakpointObserver, private authService: AuthService,
    private alertify: AlertifyService, private router: Router) {}

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    // Remove token from local storage
    localStorage.removeItem('token');
    // Give logout message before routing back to the home page
    this.alertify.message('Logged Out');
    this.router.navigate(['/home']);
  }

  }
