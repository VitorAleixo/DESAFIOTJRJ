export class Livro {
  codI: number;
  titulo: string;
  editora: string;
  edicao: number;
  anoPublicacao: string;
  autores: number[] = []; 
  assuntos: number[] = [];  

  constructor() {
    this.codI = 0;
    this.titulo = '';
    this.editora = '';
    this.edicao = 0;
    this.anoPublicacao = '';
    this.autores = [];
    this.assuntos = [];
  }
}
