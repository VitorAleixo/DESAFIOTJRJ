import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent }, // Rota para login
  { path: '', redirectTo: '/login', pathMatch: 'full' }, // Redireciona para 'login' por padrão
  { path: '**', redirectTo: '/login' } // Redireciona para login em rotas inválidas
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
