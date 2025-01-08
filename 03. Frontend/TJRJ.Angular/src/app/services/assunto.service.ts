import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Assunto } from '../models/assunto.model';

@Injectable({
  providedIn: 'root'
})
export class AssuntoService {
  private apiUrl = 'https://localhost:7190'; 
  constructor(private http: HttpClient) { }

  obterTodos(): Observable<Assunto[]> {
    return this.http.get<Assunto[]>(this.apiUrl + "/getAllassuntos");
  }

  adicionar(assunto: Assunto): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/createAssunto`, assunto);
  }

  excluir(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteAssunto?"${id}`);
  }
}
