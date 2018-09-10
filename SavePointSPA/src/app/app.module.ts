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
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      LoginComponent,
      RegisterComponent,
      HomeComponent,
      GamesComponent
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
      MatInputModule,
      RouterModule.forRoot(appRoutes),
      HttpClientModule,
   ],
   providers: [
     /* For error handling with forms */
     {provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher},
     ErrorInterceptor,
     AuthService,
     AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
