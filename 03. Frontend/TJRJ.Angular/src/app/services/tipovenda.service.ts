import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

  excluir(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/TipoVenda_CodI?"${id}`);
  }
}
