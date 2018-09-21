import { LoginComponent } from './login/login.component';
import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { GamesComponent } from './games/games.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'games', component: GamesComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
