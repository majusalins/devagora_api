using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.DTOs
{
    public class PerfilDTO
    {
        public int ID_Usuario;
        public string? Bio { get; set; }
        public string? Habilidades { get; set; }
        public string? Experiencias { get; set; }
    }
}
