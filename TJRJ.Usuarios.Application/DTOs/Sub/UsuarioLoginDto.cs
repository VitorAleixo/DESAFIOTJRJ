using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Usuarios.Application.DTOs.Sub
{
    public class UsuarioLoginDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
