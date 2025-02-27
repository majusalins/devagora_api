﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("ID_Usuario")]
        [Key]
        public int ID_Usuario { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("senha")]
        public string? Senha { get; set; }

        [Column("data_cadastro")]
        public DateTime Data_Cadastro { get; set; } = DateTime.Now;

        [Column("tipo_usuario")]
        public bool Tipo_Usuario { get; set; }

        //relacionamento one-to-one
        public Perfil Perfil { get; set; }

        //relacionamento one-to-many
        public ICollection<Rascunho> Rascunhos { get; set; } = new List<Rascunho>();
        public ICollection<Denuncia> Denuncias { get; set; } = new List<Denuncia>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
