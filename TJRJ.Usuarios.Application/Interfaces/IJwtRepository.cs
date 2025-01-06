using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TJRJ.Usuarios.Application.Interfaces
{
    public interface IJwtRepository
    {
        string GerarToken(Guid userId);
        ClaimsPrincipal ValidarToken(string token);
    }
}
