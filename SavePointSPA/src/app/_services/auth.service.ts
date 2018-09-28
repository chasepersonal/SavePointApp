import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


    constructor(private http: HttpClient) {}
    // Call API location for authorization
    baseUrl = environment.apiUrl;

    // Store decoded user token for parsing purposes
    decodedToken: any;

    jwtHelper: JwtHelperService = new JwtHelperService();

    // Call login method
    // Pass username and password through model as type any
    login(model: any) {
        // Return the reference of the Http post
        // Will contain information for the baseUrl with the login method, model data, and any options needed for authorization
        // Will be returned as an observable as type response (token object)
        // Will need to transform response into data that can be read by the browser (done with .map() operator)
        // Pass Headers through reference by calling this.requestOptions()
        return this.http.post(this.baseUrl + 'login', model).pipe(map((response: any)  => {
            const user = response;

            if (user) {
                localStorage.setItem('token', user.tokenString);
                this.decodedToken = this.jwtHelper.decodeToken(user.tokenString);
                console.log(this.decodedToken);
            }
        // Catch any errors that might arise from logging in
        }));
    }

    // Check if users token is expired when logging in
    // Done in auth services so that the work is not done in the login component
    // Push back to the login component once the token is checked
    loggedIn() {

        const token = localStorage.getItem('token');
        return !this.jwtHelper.isTokenExpired(token);
    }

    register(model: any) {

        // Return the reference of the HTTP post that will contain the registration information
        // Catch any errors that might arise from any errors to the register page
        return this.http.post(this.baseUrl + 'register', model);
    }
}
