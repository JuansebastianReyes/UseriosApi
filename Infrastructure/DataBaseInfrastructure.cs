using UsuariosApi.Models.Interfaces;
using UsuariosApi.Repositories;

namespace UsuariosApi.Infrastructure
{
    public static class DataBaseInfrastructure
    {
        public static IServiceCollection AddDataBaseInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddTransient<IUsuarioRepository, UsuarioRepository>()
                .AddTransient<IPersonaRepository, PersonaRepository>();
        }
    }
}