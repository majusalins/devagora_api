using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.DTOs
{
    public class PerfilDTO
    {
        [Required]
        public int ID_Usuario { get; set; }
        public string? Bio { get; set; }
        public string? Habilidades { get; set; }
        public string? Experiencias { get; set; }
    }
}
