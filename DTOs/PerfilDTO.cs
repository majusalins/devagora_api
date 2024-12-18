using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.DTOs
{
    public class PerfilDTO
    {
        public int ID_Perfil { get; set; }
        public string? Bio { get; set; }
        public string? Habilidades { get; set; }
        public string? Experiencias { get; set; }
        public int ID_Usuario { get; set; }
    }
}
