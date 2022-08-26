import { Injectable } from '@angular/core';
import { HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { AuthService } from 'src/app/services/auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const token = this.authService.getToken();
    console.log(token);
    const tokenizedRequest = req.clone({ headers: req.headers.set('Authorization', `Bearer ${token}`) });
    return next.handle(tokenizedRequest);
  }
}
