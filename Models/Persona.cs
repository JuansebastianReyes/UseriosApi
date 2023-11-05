namespace UsuariosApi.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string NumeroIdentificacion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string TipoIdentificacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string IdentificacionConcatenada => TipoIdentificacion + NumeroIdentificacion;
        public string NombresApellidosConcatenados => Nombres + " " + Apellidos;
    }
}