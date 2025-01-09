CREATE VIEW vwLivros  AS SELECT Nome as NomeAutor, Titulo, Editora, AnoPublicacao, Edicao, e.Descricao as Assunto FROM Autor a (NOLOCK) INNER JOIN LivroAutor b (NOLOCK) ON a.CodAu = b.Autor_CodAu INNER JOIN Livro c (NOLOCK)  ON c.CodI = b.Livro_CodI INNER
 JOIN LivroAssunto d (NOLOCK) ON d.Livro_CodI = c.CodI INNER JOIN Assunto e(NOLOCK) ON d.Assunto_codAs = e.codAs
