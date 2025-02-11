using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjetoPABD.Models
{
    [Table("Post")]
    public class Post
    {
        //post possui relacionamento um para muitos com Usuario, pois
        //um usuário pode publicar vários posts.

        //também possui um relacionamento auto-referenciado, pois um post é 
        //uma superclasse que pode ser tanto uma pergunta como uma resposta

        [Key]
        [Column("ID_Post")]
        public int ID_Post { get; set; }

        [Column("tipo_post")]
        public string? Tipo_Post { get; set; }

        [Column("data_publicacao")]
        public DateTime Data_Publicacao { get; set; } = DateTime.Now;

        [ForeignKey("Usuario")]
        public int Usuario_ID_Usuario { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Post_Pai")]
        public int? Post_Pai_ID { get; set; }
        public Post? Post_Pai { get; set; }

        [JsonIgnore]
        public ICollection<Post> Respostas { get; set; } = new List<Post>();
    }
}
