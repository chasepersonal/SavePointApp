import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

// Create a variable to add JWT token to the HTTP headers
const httpOptions = {
    headers: new HttpHeaders({
        // Space needed after bearer so that token doesn't merge with bearer causing an error
        'Authorization': 'Bearer ' + localStorage.getItem('token')
    })
};

@Injectable({
    providedIn: 'root'
})
export class UserService {

    // Import a base url from the environments
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    // Need array in order to return multiple users
    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl + 'users', httpOptions);
    }

    getUser(id): Observable<User> {
        return this.http.get<User>(this.baseUrl + `users/${id}` + httpOptions);
    }
}
