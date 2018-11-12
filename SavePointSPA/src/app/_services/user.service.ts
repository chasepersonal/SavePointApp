import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../_models/user';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    // Import a base url from the environments
    baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) { }

    // Need array in order to return multiple users
    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl + 'users');
    }

    getUser(id): Observable<User> {
        return this.http.get<User>(this.baseUrl + `users/${id}`);
    }
}
