import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Games } from '../_models/games';
import { environment } from '../../environments/environment';

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
export class GamesService {

  // Import a base url from the environments
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  // Need array in order to return multiple users
  getGames(): Observable<Games[]> {
      return this.http.get<Games[]>(this.baseUrl + 'games', httpOptions);
  }

  getGame(id: number): Observable<Games> {
      return this.http.get<Games>(this.baseUrl + `games/${id}`, httpOptions);
  }
}