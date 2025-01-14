CREATE VIEW vwLivros  AS 

SELECT Nome as NomeAutor
     , Titulo
     , Editora
     , AnoPublicacao
     , Edicao
     , STUFF((SELECT ',' + Descricao FROM Assunto x (NOLOCK) INNER JOIN LivroAssunto y (NOLOCK) on x.codAs = y.Assunto_codAs AND y.Livro_CodI = c.CodI FOR XML PATH ('')), 1, 1, '') as Assunto 
  FROM Autor a (NOLOCK) 
 INNER JOIN LivroAutor b (NOLOCK) ON a.CodAu = b.Autor_CodAu 
 INNER JOIN Livro c (NOLOCK)  ON c.CodI = b.Livro_CodI 
