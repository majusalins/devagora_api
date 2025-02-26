using System.ComponentModel.DataAnnotations;

namespace ProjetoPABD.DTOs
{
    public class TagDTO
    {
        [Required]
        public string Nome { get; set; }
    }
}
