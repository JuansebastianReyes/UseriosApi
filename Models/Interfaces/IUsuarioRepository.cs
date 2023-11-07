using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UsuariosApi.Models.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Unit> CreateUsuario(UsuarioRegister userRegister);
        Task<bool> Login(UserLogin userLogin);
    }
}