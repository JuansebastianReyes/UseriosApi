using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Models.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Persona> CreateUsuario(Persona persona);
        Task<bool> Login(string usuario, string password);
    }
}