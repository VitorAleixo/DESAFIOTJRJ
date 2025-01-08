import { Component, OnInit } from '@angular/core';
import { TipoVendaService } from '../services/tipovenda.service';
import { TipoVenda } from '../models/tipovenda.model';

@Component({
  standalone: false,
  selector: 'app-tipovendas',
  templateUrl: './tipovendas.component.html',
  styleUrls: ['./tipovendas.component.css'],
})
export class TipoVendasComponent implements OnInit {
  tipovendas: TipoVenda[] = [];
  tipovenda: TipoVenda = new TipoVenda();

  mostrarFormularioAdicionar: boolean = false;

  novoTipoVenda: TipoVenda = {
    tipoVenda_CodI: 0,
    codI: 0,
    descricao: '',
  };

  constructor(
    private tipovendaService: TipoVendaService,
  ) { }

  ngOnInit(): void {
    this.carregarTipoVendas();
  }

  carregarTipoVendas() {
    this.tipovendaService.obterTodos().subscribe({
      next: (res) => this.tipovendas = res,
      error: (err) => console.error('Erro ao carregar tipovendas:', err)
    });
  }

  adicionarTipoVenda() {
    const tipovendaParaEnviar = {
      codI: 0,
      tipoVenda_CodI: 0,
      descricao: this.novoTipoVenda.descricao,
    };


    this.tipovendaService.adicionar(tipovendaParaEnviar).subscribe({
      next: () => {
        alert('TipoVenda adicionado com sucesso!');
        this.carregarTipoVendas();
        this.resetarNovoTipoVenda();
      },
      error: (err) => console.error('Erro ao adicionar tipovenda:', err),
    });
  }

  resetarNovoTipoVenda() {
    this.novoTipoVenda = {
      tipoVenda_CodI: 0,
      codI: 0,
      descricao: '',
    };
  }

  excluirTipoVenda(id: number) {
    this.tipovendaService.excluir(id).subscribe({
      next: () => {
        alert('TipoVenda excluído com sucesso!');
        this.carregarTipoVendas();
      },
      error: (err) => console.error('Erro ao excluir livro:', err),
    });
  }
}
