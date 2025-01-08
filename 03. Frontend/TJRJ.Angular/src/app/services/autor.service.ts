import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Autor } from '../models/autor.model';

@Injectable({
  providedIn: 'root'
})
export class AutorService {
  private apiUrl = 'https://localhost:7190'; 

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<Autor[]> {
    return this.http.get<Autor[]>(this.apiUrl + "/getAllautor");
  }

  adicionar(autor: Autor): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/createAutor`, autor);
  }

  excluir(codAu: number): Observable<void> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.put<void>(`${this.apiUrl}/deleteAutor?CodAu=${codAu}`, null, { headers });
  }
}
