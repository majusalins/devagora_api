using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.Models
{
    [Table("Rascunho")]
    public class Rascunho
    {
        //a entidade Rascunho faz parte de um relacionamento um para muitos com
        //Usuario, uma vez que um usuário pode guardar vários rascunhos e um rascunho
        //deve pertencer a um usuário apenas

        [Column("ID_Rascunho")]
        [Key]
        public int ID_Rascunho { get; set; }

        [Column("conteudo")]
        public string? Conteudo { get; set; }

        [Column("data_criacao")]
        public DateTime Data_Criacao { get; set; } = DateTime.Now;

        [Column("data_edicao")]
        public DateTime Data_Edicao { get; set; }
        
        [ForeignKey("ID_Usuario")]
        public int Usuario_ID_Usuario { get; set; }
        public Usuario Usuario { get; set; } = null!;
    }
}
