using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.Models
{
    [Table("Tag")]
    public class Tag
    {
        [Column("ID_Tag")]
        [Key]
        public int ID_Tag { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }
    }
}
