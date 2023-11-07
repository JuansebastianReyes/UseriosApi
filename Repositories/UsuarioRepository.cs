using MediatR;
using UsuariosApi.Models;
using UsuariosApi.Models.Interfaces;
using UsuariosApi.Data;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DBConection _context;
        private readonly IPersonaRepository _personaRepository;

        public UsuarioRepository(
            DBConection context,
            IPersonaRepository personaRepository)
        {
            _context = context;
            _personaRepository = personaRepository;
        }

        public async Task<Unit> CreateUsuario(UsuarioRegister userRegister)
        {
            Persona persona = new Persona();
            try
            {
                persona = await CrearPersona(userRegister);
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }

            Usuario user = new Usuario{
                User = userRegister.User,
                Pass = userRegister.Pass,
                FechaCreacion = DateTime.UtcNow,
                PersonaId = persona.Id
            };

            _context.Usuarios.Add(user);
            var valor = await _context.SaveChangesAsync();

            if (valor > 0)
            {
                return Unit.Value;;
            }

            throw new Exception("Error en la inserción de la persona en la base de datos");
        }

        public async Task<bool> Login(UserLogin userLogin)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.User == userLogin.Usuario);

            if (user != null)
            {
                if (VerificarContraseña(userLogin.Password, user.Pass))
                {
                    return true;
                }
            }

            throw new Exception("Error en usuario o contraseña");
        }

        private bool VerificarContraseña(string contraseña, string contraseñaAlmacenada)
        {
            return contraseña == contraseñaAlmacenada;
        }

        private async Task<Persona> CrearPersona(UsuarioRegister userRegister)
        {
            try
            {
                Persona persona = new Persona{
                    Nombres = userRegister.Nombres,
                    Apellidos = userRegister.Apellidos,
                    NumeroIdentificacion = userRegister.NumeroIdentificacion,
                    Email = userRegister.Email,
                    TipoIdentificacion = userRegister.TipoIdentificacion,
                    FechaCreacion = DateTime.UtcNow
                };

                persona = await _personaRepository.CreatePersona(persona);

                return persona;
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }

        }

        public async Task<int> CountUser()
        {
            var count = await _context.Usuarios.CountAsync();
            return count;
        }
    }
}