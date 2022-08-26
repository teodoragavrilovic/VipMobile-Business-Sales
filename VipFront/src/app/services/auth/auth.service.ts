import { HttpClient } from '@angular/common/http';
import { Injectable, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly baseUrl = "https://localhost:44315/api/Authentication";



  constructor(
    private http: HttpClient,
    private router: Router
    ) { }

  getToken(): string {
    return localStorage.getItem('token') || '';
  }


  login(params: { username: string, password: string }): Observable<{token:string}> {
    const url = this.baseUrl;
    //return this.http.post(url, params);
    //console.log("TU");
    return this.http.post<{token:string}>(url, params);
  }

  loggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/home']);
  }
}
