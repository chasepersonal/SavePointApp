import { LoginComponent } from './login/login.component';
import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { GamesComponent } from './games/games.component';
import { UserListComponent } from './users/user-list/user-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { GamesDetailsComponent } from './games-details/games-details.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';

export const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  // Guard routes for all logged in routes
    // Done through this custom route instead of adding canActivate: [AuthGuard] to each
    // Avoids DRY
    {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
          { path: 'user-list', component: UserListComponent },
          { path: 'user-list/:id', component: UserDetailComponent },
          { path: 'games', component: GamesComponent },
          { path: 'games/:id', component: GamesDetailsComponent }
      ]
  },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },
];
