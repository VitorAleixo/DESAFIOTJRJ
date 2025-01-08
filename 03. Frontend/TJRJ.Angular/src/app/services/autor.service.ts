import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
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

  excluir(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/deleteAutor?"${id}`);
  }
}
