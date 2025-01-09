import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoVenda } from '../models/tipovenda.model';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TipoVendaService {
  private apiUrl = 'https://localhost:7190'; 

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<TipoVenda[]> {
    return this.http.get<TipoVenda[]>(this.apiUrl + "/getAllTipoVenda");
  }

  adicionar(tipoVenda: TipoVenda): Observable<void> {

    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    console.log(tipoVenda);
    return this.http.post<void>(`${this.apiUrl}/createTipoVendaLivro`, tipoVenda).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(() => error);
      })
    );
  }

  excluir(tipoVenda_CodI: number): Observable<void> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.put<void>(`${this.apiUrl}/deleteTipoVenda?TipoVenda_CodI=${tipoVenda_CodI}`, null, { headers });
  }

  removerTipoVenda(codI: number, tipoVendaCodI: number): Observable<void> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    const payload = {
      codI: codI,
      tipoVenda_CodI: tipoVendaCodI
    };

    return this.http.post<void>(`${this.apiUrl}/deleteTipoVendaLivro`, payload, { headers }).pipe(
      catchError((error: HttpErrorResponse) => {
        return throwError(() => error);
      })
    );
  }

 

  obterPorLivro(CodI: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getTipoVendaLivro?CodI=${CodI}`);
  }

}
