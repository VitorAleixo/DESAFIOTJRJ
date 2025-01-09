import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service'; // Certifique-se de que o seu serviço de autenticação esteja implementado

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    // Verifica se o usuário está autenticado
    if (this.authService.isAuthenticated()) {
      return true;  // Permite o acesso
    } else {
      this.router.navigate(['/login']); // Redireciona para a página de login se não autenticado
      return false; // Bloqueia o acesso à rota
    }
  }
}
