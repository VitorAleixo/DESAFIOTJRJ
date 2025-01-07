namespace WorkGoal.Alunos.Application.DTOs.Sub
{
    public class UsuarioCreateDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
