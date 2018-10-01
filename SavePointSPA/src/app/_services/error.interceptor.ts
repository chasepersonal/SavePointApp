import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpRequest, HttpHandler, HttpErrorResponse, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()

// Will create a custom HttpInterceptor for error handling
export class ErrorInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(error => {
        // If errors arise from API, send an error message as a header back
        if (error instanceof HttpErrorResponse) {
          // If HTTP returns a 401 response, add an error with status text
          if (error.status === 401) {
            return throwError(error.statusText);
          }
          const applicationError = error.headers.get('Application-Error');
          if (applicationError) {
            return throwError(applicationError);
          }
          // create constant variable to hold server error that is an error object of error
          const serverError = error.error;
          // set error state message to blank message
          let modalStateErrors = '';
          // If a server error occurs and it has an object error, loop through server error object
          if (serverError && typeof serverError === 'object') {
            // for each variable returned in server error, add it to the modalStateError
            // also add a new line after each variable to make it readable
            for (const key in serverError) {
              if (serverError[key]) {
                modalStateErrors += serverError[key] + '\n';
              }
            }
          }
          // Throw different types of errors depending on requirements above
          return throwError(modalStateErrors || serverError || 'Server Error');
        }
      })
    );
  }
}

// Will add to array of existing interceptors
export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ErrorInterceptor,
  multi: true
};
