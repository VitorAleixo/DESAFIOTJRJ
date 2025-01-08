import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  excluir(codAs: number): Observable<void> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.put<void>(`${this.apiUrl}/deleteAssunto?CodA=${codAs}`, null, { headers });
  }
}
