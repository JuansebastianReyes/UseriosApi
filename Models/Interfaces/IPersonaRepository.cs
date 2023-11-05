namespace UsuariosApi.Models.Interfaces
{
    public interface IPersonaRepository
    {
        Task<Persona> CreatePersona(Persona persona);
    }
}