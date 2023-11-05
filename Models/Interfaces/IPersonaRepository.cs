using MediatR;

namespace UsuariosApi.Models.Interfaces
{
    public interface IPersonaRepository
    {
        Task<Unit> CreatePersona(Persona persona);
    }
}