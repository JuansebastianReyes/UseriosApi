using MediatR;
using UsuariosApi.Models;
using UsuariosApi.Models.Interfaces;

namespace UsuariosApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<Unit> CreateUsuario(Persona persona)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(string usuario, string password)
        {
            throw new NotImplementedException();
        }
    }
}