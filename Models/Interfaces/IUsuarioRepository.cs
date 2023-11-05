using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace UsuariosApi.Models.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Unit> CreateUsuario(Persona persona);
        Task<bool> Login(string usuario, string password);
    }
}