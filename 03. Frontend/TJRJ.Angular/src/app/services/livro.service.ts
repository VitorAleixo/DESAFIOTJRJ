import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Livro } from '../models/livro.model';

@Injectable({
  providedIn: 'root',
})
export class LivroService {
  private apiUrl = 'https://localhost:7190';

  constructor(private http: HttpClient) { }

  obterTodos(): Observable<Livro[]> {
    return this.http.get<Livro[]>(this.apiUrl + "/getAlllivros");
  }

  obterLivro(codI: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/getLivro?CodI=${codI}`);
  }


  adicionar(livro: Livro): Observable<void> {
    const livroParaEnviar = {
      codI: livro.codI,
      titulo: livro.titulo,
      editora: livro.editora,
      anoPublicacao: livro.anoPublicacao,
      // Assuntos e autores conforme a seleção
      autores: livro.autores,
      assuntos: livro.assuntos
    };

    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')

    return this.http.post<void>(`${this.apiUrl}/createLivro`, livro);
  }

  editar(id: number, livro: Livro): Observable<Livro> {
    console.log(livro);
    return this.http.put<Livro>(`${this.apiUrl}/updateLivro?CodI=${livro.codI}`, livro);
  }

  excluir(codI: number): Observable<void> {
    const headers = new HttpHeaders().set('Content-Type', 'application/json');

    return this.http.put<void>(`${this.apiUrl}/deleteLivro?CodI=${codI}`, null, { headers });
  }
}
