using MediatR;
using UsuariosApi.Data;
using UsuariosApi.Models;
using UsuariosApi.Models.Interfaces;

namespace UsuariosApi.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {

        private readonly DBConection _context;

        public PersonaRepository(DBConection context){
            _context = context;
        }

        public async Task<Persona> CreatePersona(Persona persona)
        {
            _context.Personas.Add(persona);
            var valor = await _context.SaveChangesAsync();

            if (valor > 0)
            {
                return persona;
            }

            throw new Exception("Error en la inserción de la persona en la base de datos");        
        }
    }
}