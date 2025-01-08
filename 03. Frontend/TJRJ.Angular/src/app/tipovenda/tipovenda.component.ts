import { Component, OnInit } from '@angular/core';
import { TipoVendaService } from '../services/tipovenda.service';
import { TipoVenda } from '../models/tipovenda.model';

@Component({
  standalone: false,
  selector: 'app-tipovenda',
  templateUrl: './tipovenda.component.html',
  styleUrls: ['./tipovenda.component.css'],
})
export class TipoVendaComponent implements OnInit {
  tiposvenda: TipoVenda[] = [];
  tipovenda: TipoVenda = new TipoVenda();

  tipovendaSelecionado!: TipoVenda;

  mostrarFormularioAdicionar: boolean = false;

  novoTipoVenda: TipoVenda = {
    tipovenda_codI: 0,
    descricao: '',
  };

  constructor(
    private tipovendaService : TipoVendaService
  ) { }

  ngOnInit(): void {
    this.carregarTipoVenda();
  }

  carregarTipoVenda() {
    this.tipovendaService.obterTodos().subscribe({
      next: (res) => this.tiposvenda = res,
      error: (err) => console.error('Erro ao carregar Tipos de Venda:', err)
    });
  }

  adicionarTipoVenda() {
    const tipoVendaParaEnviar = {
      tipovenda_codI: 0,
      descricao: this.novoTipoVenda.descricao,
    };


    this.tipovendaService.adicionar(tipoVendaParaEnviar).subscribe({
      next: () => {
        alert('Tipo de Venda adicionado com sucesso!');
        this.carregarTipoVenda();
        this.resetarNovoTipoVenda();
      },
      error: (err) => console.error('Erro ao adicionar livro:', err),
    });
  }

  resetarNovoTipoVenda() {
    this.novoTipoVenda= {
      codI: 0,
      descricao: '',
    };
  }

  abrirModalVenda(tipoVenda: TipoVenda) {
    this.carregarTipoVenda();
    this.tipovendaSelecionado = tipoVenda; // Salva o livro selecionado
  }

  excluirTipoVenda(id: number) {
    this.tipovendaService.excluir(id).subscribe({
      next: () => {
        alert('Tipo de Venda excluído com sucesso!');
        this.carregarTipoVenda();
      },
      error: (err) => console.error('Erro ao excluir livro:', err),
    });
  }
}
