using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.Models
{
    [Table("Denuncia")]
    public class Denuncia
    {
        [Column("ID_Denuncia")]
        [Key]
        public int ID_Denuncia { get; set; }

        [Column("data_denuncia")]
        public DateTime Data_Denuncia { get; set; } = DateTime.Now;

        [Column("motivo")]
        public string? Motivo { get; set; }

        [ForeignKey("ID_Usuario")]
        public int Usuario_ID_Usuario { get; set; }
        public Usuario? Usuario { get; set; }

        [ForeignKey("ID_Post")]
        public int Post_ID_Post { get; set; }
        public Post? Post { get; set; }
    }
}
