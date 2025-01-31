using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.Models
{
    [Table("Perfil")]
    public class Perfil
    {
        //a entidade Perfil possui relacionamento um para um com 
        //Usuario, uma vez que um usuário pode ter apenas um perfil.

        [Column("ID_Perfil")]
        [Key]
        public int ID_Perfil { get; set; }

        [Column("bio")]
        public string? Bio { get; set; }

        [Column("foto_perfil")]
        public string? Foto_Perfil { get; set; }

        [Column("habilidades")]
        public string? Habilidades { get; set; }

        [Column("experiencias")]
        public string? Experiencias { get; set; }

        [ForeignKey("ID_Usuario")]
        public int Usuario_ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
