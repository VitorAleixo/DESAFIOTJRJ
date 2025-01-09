import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RelatorioService {
  private apiUrl = 'https://localhost:7190';

  constructor(private http: HttpClient) { }

  gerarRelatorioLivros() {
    return this.http.get(`${this.apiUrl}/relatorioLivros`, {
      responseType: 'blob', 
    });
  }
}
