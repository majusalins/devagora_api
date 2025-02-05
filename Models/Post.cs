using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.Models
{
    [Table("Post")]
    public class Post
    {
        //post possui relacionamento um para muitos com Usuario, pois
        //um usuário pode publicar vários posts.

        [Column("ID_Post")]
        [Key]
        public int ID_Post { get; set; }

        [Column("tipo_post")]
        public string? Tipo_Post { get; set; }

        [Column("data_publicacao")]
        public DateTime Data_Publicacao = DateTime.Now;

        [ForeignKey("ID_Usuario")]
        public int Usuario_ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
