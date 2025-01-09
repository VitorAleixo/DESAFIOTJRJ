import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { LivrosComponent } from './livros/livros.component';
import { AssuntosComponent } from './assuntos/assuntos.component';
import { AutoresComponent } from './autores/autores.component';
import { TipoVendasComponent } from './tipovendas/tipovendas.component';
import { AuthGuard } from './interceptor/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent }, 
  { path: 'livros', component: LivrosComponent, canActivate: [AuthGuard] }, 
  { path: 'assuntos', component: AssuntosComponent, canActivate: [AuthGuard] },
  { path: 'autores', component: AutoresComponent, canActivate: [AuthGuard] }, 
  { path: 'tipovendas', component: TipoVendasComponent, canActivate: [AuthGuard] }, 
  { path: '', redirectTo: '/login', pathMatch: 'full' }, 
  { path: '**', redirectTo: '/login' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
