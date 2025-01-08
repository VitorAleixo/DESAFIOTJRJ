import { Component, OnInit } from '@angular/core';
import { AutorService } from '../services/autor.service';
import { Autor } from '../models/autor.model';

@Component({
  standalone: false,
  selector: 'app-autores',
  templateUrl: './autores.component.html',
  styleUrls: ['./autores.component.css'],
})
export class AutoresComponent implements OnInit {
  autores: Autor[] = [];
  autore: Autor = new Autor();

  autorSelecionado!: Autor;

  mostrarFormularioAdicionar: boolean = false;

  novoAutor: Autor = {
    codAu: 0,
    nome: '',
  };

  constructor(
    private autorService: AutorService,
  ) { }

  ngOnInit(): void {
    this.carregarAutores();
  }

  carregarAutores() {
    this.autorService.obterTodos().subscribe({
      next: (res) => this.autores = res,
      error: (err) => console.error('Erro ao carregar autores:', err)
    });
  }

  adicionarAutor() {
    const autorParaEnviar = {
      codAu: 0,
      nome: this.novoAutor.nome,
    };


    this.autorService.adicionar(autorParaEnviar).subscribe({
      next: () => {
        alert('Autor adicionado com sucesso!');
        this.carregarAutores();
        this.resetarNovoAutor();
      },
      error: (err) => console.error('Erro ao adicionar autor:', err),
    });
  }

  resetarNovoAutor() {
    this.novoAutor = {
      codAu: 0,
      nome: '',
    };
  }

  excluirAutor(id: number) {
    this.autorService.excluir(id).subscribe({
      next: () => {
        alert('Autor excluído com sucesso!');
        this.carregarAutores();
      },
      error: (err) => console.error('Erro ao excluir livro:', err),
    });
  }
}
