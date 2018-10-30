import { AlertifyService } from './_services/alertify.service';
import { GamesComponent } from './games/games.component';
import { HomeComponent } from './home/home.component';
import { appRoutes } from './routes';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule,
  MatIconModule, MatListModule, MatCardModule, MatInputModule, ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthService } from './_services/auth.service';
import { ErrorInterceptor } from './_services/error.interceptor';
import { RegisterComponent } from './register/register.component';
import { HttpClientModule } from '@angular/common/http';
import { GamesDetailsComponent } from './games-details/games-details.component';
import { GamesService } from './_services/games.service';
import { UserService } from './_services/user.service';
import { UserListComponent } from './users/user-list/user-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserCardComponent } from './users/user-card/user-card.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      LoginComponent,
      RegisterComponent,
      HomeComponent,
      GamesComponent,
      GamesDetailsComponent,
      UserListComponent,
      UserCardComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      LayoutModule,
      MatToolbarModule,
      MatButtonModule,
      MatSidenavModule,
      MatIconModule,
      MatListModule,
      MatCardModule,
      FormsModule,
      MatIconModule,
      MatInputModule,
      RouterModule.forRoot(appRoutes),
      HttpClientModule
   ],
   providers: [
      AuthService,
      AlertifyService,
      GamesService,
      UserService,
      ErrorInterceptor,
      AuthGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
