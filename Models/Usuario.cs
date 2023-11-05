namespace UsuariosApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; } = string.Empty;
        public string Pass { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public int PersonaId { get; set; }
    }
}