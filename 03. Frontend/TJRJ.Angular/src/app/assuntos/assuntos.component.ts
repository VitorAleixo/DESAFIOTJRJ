import { Component, OnInit } from '@angular/core';
import { AssuntoService } from '../services/assunto.service';
import { Assunto } from '../models/assunto.model';

@Component({
  standalone: false,
  selector: 'app-assuntos',
  templateUrl: './assuntos.component.html',
  styleUrls: ['./assuntos.component.css'],
})
export class AssuntosComponent implements OnInit {
  assuntos: Assunto[] = [];
  assunto: Assunto = new Assunto();

  mostrarFormularioAdicionar: boolean = false;

  novoAssunto: Assunto = {
    codAs: 0,
    descricao: '',
  };

  constructor(
    private assuntoService: AssuntoService,
  ) { }

  ngOnInit(): void {
    this.carregarAssuntos();
  }

  carregarAssuntos() {
    this.assuntoService.obterTodos().subscribe({
      next: (res) => this.assuntos = res,
      error: (err) => console.error('Erro ao carregar assuntos:', err)
    });
  }

  adicionarAssunto() {
    const assuntoParaEnviar = {
      codAs: 0,
      descricao: this.novoAssunto.descricao,
    };


    this.assuntoService.adicionar(assuntoParaEnviar).subscribe({
      next: () => {
        alert('Assunto adicionado com sucesso!');
        this.carregarAssuntos();
        this.resetarNovoAssunto();
      },
      error: (err) => console.error('Erro ao adicionar assunto:', err),
    });
  }

  resetarNovoAssunto() {
    this.novoAssunto = {
      codAs: 0,
      descricao: '',
    };
  }

  excluirAssunto(id: number) {
    this.assuntoService.excluir(id).subscribe({
      next: () => {
        alert('Assunto excluído com sucesso!');
        this.carregarAssuntos();
      },
      error: (err) => console.error('Erro ao excluir livro:', err),
    });
  }
}
