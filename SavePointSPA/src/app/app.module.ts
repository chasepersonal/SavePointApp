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

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      LoginComponent
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
      RouterModule.forRoot(appRoutes)
   ],
   providers: [
     /* For error handling with forms */
     {provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher}
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
