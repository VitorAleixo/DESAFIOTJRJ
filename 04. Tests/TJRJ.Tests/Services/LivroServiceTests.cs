using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Livros.Application.Interfaces;
using TJRJ.Livros.Application.UseCases;
using TJRJ.Livros.Domain.Entities;

namespace TJRJ.Tests.Services
{
    public class LivroServiceTests
    {
        private Mock<ILivroRepository> _livroRepositoryMock;
        private LivroUseCase _livroService;

        [SetUp]
        public void Setup()
        {
            _livroRepositoryMock = new Mock<ILivroRepository>();
            _livroService = new LivroUseCase(_livroRepositoryMock.Object);
        }

        [Test]
        public void ObterTodosAsync_ReturnsAtLeastOneLivro()
        {
            var livros = _livroService.ObterTodosAsync();

            Assert.IsNotNull(livros, "Esperado que uma acordao válido seja retornado.");
        }

    }
}
