import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('token'); // Obter o token do localStorage

    if (token) {
      // Clonar a requisição e adicionar o cabeçalho Authorization
      const authRequest = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
      return next.handle(authRequest);
    }

    // Continuar sem modificar a requisição se o token não estiver disponível
    return next.handle(request);
  }
}
