import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoVenda } from '../models/tipovenda.model';

@Injectable({
  providedIn: 'root'
})
export class TipoVendaService {
  private apiUrl = 'https://localhost:7190'; 

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<TipoVenda[]> {
    return this.http.get<TipoVenda[]>(this.apiUrl + "/getAllTipoVenda");
  }

  adicionar(autor: TipoVenda): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/createTipoVenda`, autor);
  }

  excluir(tipoVenda_CodI: number): Observable<void> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.put<void>(`${this.apiUrl}/deleteTipoVenda?TipoVenda_CodI=${tipoVenda_CodI}`, null, { headers });
  }
}
