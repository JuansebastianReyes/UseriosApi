using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class DBConection : DbContext
    {

        public DBConection(DbContextOptions<DBConection> options): base(options)
        {

        }

        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();        
    }
}