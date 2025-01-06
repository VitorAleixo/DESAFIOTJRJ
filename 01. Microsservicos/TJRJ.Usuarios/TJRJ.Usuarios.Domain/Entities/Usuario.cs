using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Usuarios.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public int CalcularIdade()
        {
            var today = DateTime.Today;
            int idade = today.Year - DataNascimento.Year;

            if (DataNascimento.Date > today.AddYears(-idade)) idade--;
            return idade;
        }

        public void SetSenha(string senha)
        {
            this.Senha = BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public bool VerificarSenha(string senha)
        {
            return BCrypt.Net.BCrypt.Verify(senha, this.Senha);
        }
    }
}
