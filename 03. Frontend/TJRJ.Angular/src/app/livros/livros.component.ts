import { Component, OnInit } from '@angular/core';
import { LivroService } from '../services/livro.service';
import { AutorService } from '../services/autor.service';
import { AssuntoService } from '../services/assunto.service';
import { TipoVendaService } from '../services/tipovenda.service';
import { Livro } from '../models/livro.model';
import { Autor } from '../models/autor.model';
import { Assunto } from '../models/assunto.model';
import { TipoVenda } from '../models/tipovenda.model';

@Component({
  standalone: false,
  selector: 'app-livros',
  templateUrl: './livros.component.html',
  styleUrls: ['./livros.component.css'],
})
export class LivrosComponent implements OnInit {
  livros: Livro[] = [];
  autores: Autor[] = [];
  assuntos: Assunto[] = [];
  tiposvenda: TipoVenda[] = [];
  livro: Livro = new Livro();
  venda: TipoVenda = new TipoVenda();

  livroSelecionado!: Livro;

  mostrarFormularioAdicionar: boolean = false;

  novoLivro: Livro = {
    codI: 0,
    autores: [],
    assuntos: [],
    titulo: '',
    editora: '',
    edicao: 0,
    anoPublicacao: '',
  };

  constructor(
    private livroService: LivroService,
    private autorService: AutorService,
    private assuntoService: AssuntoService,
    private tipovendaService : TipoVendaService
  ) { }

  ngOnInit(): void {
    this.carregarLivros();
    this.carregarAutores();
    this.carregarAssuntos();
  }

  carregarLivros() {
    this.livroService.obterTodos().subscribe({
      next: (res) => this.livros = res,
      error: (err) => console.error('Erro ao carregar livros:', err)
    });
  }

  carregarAutores() {
    this.autorService.obterTodos().subscribe({
      next: (res) => this.autores = res,
      error: (err) => console.error('Erro ao carregar autores:', err)
    });
  }

  carregarAssuntos() {
    this.assuntoService.obterTodos().subscribe({
      next: (res) => this.assuntos = res,
      error: (err) => console.error('Erro ao carregar assuntos:', err)
    });
  }

  carregarTipoVenda() {
    this.tipovendaService.obterTodos().subscribe({
      next: (res) => this.tiposvenda = res,
      error: (err) => console.error('Erro ao carregar Tipos de Venda:', err)
    });
  }

  confirmarVenda() {
    this.tipovendaService.adicionar(this.venda).subscribe({
      next: () => {
        alert('Venda confirmada com sucesso!');
        // Você pode adicionar ações adicionais aqui, como limpar campos ou atualizar o estado
      },
      error: (err) => console.error('Erro ao confirmar venda', err),
    });
  }

  abriVendaLivro(livro: Livro) {
    alert(`Funcionalidade de editar o livro "${livro.titulo}" ainda não implementada.`);
  }

  adicionarLivro() {
    const livroParaEnviar = {
      codI: 0,
      titulo: this.novoLivro.titulo,
      editora: this.novoLivro.editora,
      edicao: this.novoLivro.edicao,
      anoPublicacao: this.novoLivro.anoPublicacao.toString(),
      autores: this.novoLivro.autores,  
      assuntos: this.novoLivro.assuntos,  
    };


    this.livroService.adicionar(livroParaEnviar).subscribe({
      next: () => {
        alert('Livro adicionado com sucesso!');
        this.carregarLivros();
        this.resetarNovoLivro();
      },
      error: (err) => console.error('Erro ao adicionar livro:', err),
    });
  }

  resetarNovoLivro() {
    this.novoLivro = {
      codI: 0,
      autores: [],
      assuntos: [],
      titulo: '',
      editora: '',
      edicao: 0,
      anoPublicacao: '',
    };
  }

  abrirModalVenda(livro: Livro) {
    this.carregarTipoVenda();
    this.livroSelecionado = livro; // Salva o livro selecionado
  }

  abrirEditarLivro(livro: Livro) {
    alert(`Funcionalidade de editar o livro "${livro.titulo}" ainda não implementada.`);
  }


  excluirLivro(id: number) {
    this.livroService.excluir(id).subscribe({
      next: () => {
        alert('Livro excluído com sucesso!');
        this.carregarLivros();
      },
      error: (err) => console.error('Erro ao excluir livro:', err),
    });
  }
}
