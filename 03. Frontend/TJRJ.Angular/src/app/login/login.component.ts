import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  standalone: false,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  login = {
    email: '',
    senha: '',
  };

  errorMessage = '';
  successMessage = '';
  isLoading = false; 

  ngOnInit(): void {
    localStorage.removeItem('token');
  }

  constructor(private authService: AuthService, private router: Router) {
  }

  onSubmit(): void {
    this.errorMessage = '';
    this.successMessage = '';
    console.log(this.login);
    if (this.login.email && this.login.senha) {
      this.isLoading = true; 
      this.authService.login(this.login).subscribe(
        (response) => {
          this.isLoading = false; 
          this.successMessage = 'Login realizado com sucesso!';
          localStorage.setItem('token', response.token);

          setTimeout(() => {
            this.router.navigate(['/livros']);
          }, 1000);
        },
        (error) => {
          this.isLoading = false; 
          this.errorMessage = 'Credenciais inválidas. Tente novamente.';
          console.error(error);
        }
      );
    }
  }
}
