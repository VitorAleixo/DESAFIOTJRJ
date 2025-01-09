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

  livroSelecionado: Livro = {
    titulo: '',
    autores: [],
    anoPublicacao: '',
    editora: '',
    codI: 0,
    assuntos: [],
    edicao: 0
  }

  livroEditado: Livro = {
    titulo: '',
    autores: [],
    anoPublicacao: '',
    editora: '',
    codI: 0,
    assuntos: [],
    edicao: 0
  }

  listaAutores: any[] = [];  
  listaAssuntos: any[] = []; 

  mostrarFormularioAdicionar: boolean = false;

  tiposVendaCadastrados: any[] = [];


  carregarTiposVendaPorLivro(codI: number) {
    this.tipovendaService.obterPorLivro(codI).subscribe({
      next: (res) => this.tiposVendaCadastrados = res,
      error: (err) => console.error('Erro ao carregar tipos de venda cadastrados:', err),
    });
  }

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
  listaAutoresSelecionados: any[] = [];
  listaAssuntosSelecionados: any[] = [];

  carregarAutoresEAssuntos(codI: number) {
    this.autorService.obterTodos().subscribe(
      (data: any[]) => {
        this.listaAutores = data; // Lista de todos os autores
     

        // Agora carrega o livro para selecionar os autores associados
        this.livroService.obterLivro(codI).subscribe(
          (livroData: { codI: number, titulo: string, editora: string, edicao: number, anoPublicacao: string, autores: number[], assuntos: number[] }) => {
            this.livroEditado = livroData;
            // Filtra os autores que estão relacionados ao livro com base no ID
            this.listaAutoresSelecionados = this.listaAutores.filter(autor => this.livroEditado.autores.includes(autor.codAu));
           
          },
          error => {
            console.error('Erro ao carregar livro', error);
          }
        );
      },
      error => {
        console.error('Erro ao carregar autores', error);
      }
    );

    this.assuntoService.obterTodos().subscribe(
      (data: any[]) => {
        this.listaAssuntos = data; // Lista de todos os autores

        // Agora carrega o livro para selecionar os autores associados
        this.livroService.obterLivro(codI).subscribe(
          (livroData: { codI: number, titulo: string, editora: string, edicao: number, anoPublicacao: string, autores: number[], assuntos: number[] }) => {
            this.livroEditado = livroData;
        
            // Filtra os autores que estão relacionados ao livro com base no ID
            this.listaAssuntosSelecionados = this.listaAssuntos.filter(assunto => this.livroEditado.assuntos.includes(assunto.codAs));

          },
          error => {
            console.error('Erro ao carregar livro', error);
          }
        );
      },
      error => {
        console.error('Erro ao carregar autores', error);
      }
    );
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

  confirmarEdicao(codI: number): void {
    this.livroService.editar(codI, this.livroEditado).subscribe({
      next: () => {
        alert('Livro atualizado com sucesso!');
        this.carregarLivros(); 
      },
      error: (err) => {
        console.error('Erro ao editar livro:', err);
        alert('Erro ao editar livro.');
      },
    });
   }

  confirmarVenda() {
    this.tipovendaService.adicionar(this.venda).subscribe({
      next: () => {
        alert('Venda confirmada com sucesso!');
        this.carregarTiposVendaPorLivro(this.livroSelecionado.codI); 
      },
      error: (err) => {
        if (err.error) {
          alert(err.error);
        } else {
          console.error('Erro inesperado:', err);
          alert('Ocorreu um erro inesperado. Tente novamente.');
        }
      }
    });
  }

  removerTipoVenda(codI: number, tipoVendaCodI: number) {
    if (confirm('Tem certeza que deseja remover este tipo de venda?')) {
      this.tipovendaService.removerTipoVenda(codI, tipoVendaCodI).subscribe({
        next: () => {
          alert('Tipo de venda removido com sucesso!');
          this.carregarTiposVendaPorLivro(this.livroSelecionado.codI); 
        },
        error: (err) => console.error('Erro ao remover tipo de venda:', err),
      });
    }
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
    this.livroSelecionado = livro;
    this.venda = {
      codI: livro.codI, 
      tipoVenda_CodI: 0,
      valor: 0,
      descricao: '',
    };

    this.carregarTiposVendaPorLivro(livro.codI);
  }

  abrirModalEditar(livro: Livro) {
    this.livroEditado = {...livro}
    this.carregarAutoresEAssuntos(livro.codI);
  }


  excluirLivro(id: number) {
    if (confirm('Tem certeza que deseja remover esse livro?')) {
    this.livroService.excluir(id).subscribe({
      next: () => {
        alert('Livro excluído com sucesso!');
        this.carregarLivros();
      },
      error: (err) => console.error('Erro ao excluir livro:', err),
    });
    }
  }
}
