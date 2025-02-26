using System.ComponentModel.DataAnnotations;

namespace ProjetoPABD.DTOs
{
    public class DenunciaDTO
    {
        [Required]
        public int ID_Usuario { get; set; }
        [Required]
        public string? Motivo { get; set; }
        public int Post_ID_Post { get; set; }
    }
}
