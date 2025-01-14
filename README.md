Esse projeto foi criado em C# (ASP .NET CORE 8) e Angular 19.

Demais frameworks / utilidades no projeto:
- Token JWT para autenticação de usuário
- SQLServer
- Entity Framework para a criação das tabelas e manipulação de dados no sistema.
- RDLC (Report Viewer)
- Projeto de testes (TDD)
- Bootstrap + CSS

Foi utilizado a arquitetura SOLID com microsserviços no projeto, para garantir que o sistema funcione de uma forma eficaz.

Arquitetura do Projeto:
00. Core
- TJRJ.Shared (Tudo o que pode ser compartilhado entre os microsserviços)
01. Microsservicos (Backend da Aplicação em C#)
  - TJRJ.Livros.API (Onde fica todo o backend dos livros, assuntos, autores e tipos de venda)
  - TJRJ.Usuarios.API (Onde fica o backend do usuário, login)
02. Infra
    TJRJ.Infrastructure (Camada de infraestrutura que pode ser compartilhada entre o projeto)
03. Frontend 
    - TJRJ.Angular (Projeto Front-End feito com Angular)
04. Tests
  - TJRJ.Tests (Projeto de TDD, testes unitários)


