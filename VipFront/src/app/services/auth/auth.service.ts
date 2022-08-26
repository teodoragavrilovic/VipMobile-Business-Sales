import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly baseUrl = ``;

  constructor(
    private http: HttpClient,
    private router: Router
    ) { }

  getToken(): string {
    return localStorage.getItem('token') || '';
  }

  // login(params: { email: string, password: string }): Observable<User> {
  login(params: { email: string, password: string }) {
    const url = `${this.baseUrl}/login`
    return this.http.post(url, params);
    // return this.http.post<User>(url, params);
  }

  loggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/auth']);
  }
}
