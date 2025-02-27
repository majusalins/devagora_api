﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPABD.DTOs
{
    public class PostDTO
    {
        [Required]
        public int ID_Usuario { get; set; }
        [Required]
        public string? Tipo_Post { get; set; }
        public int? Post_Pai_ID {  get; set; }
        public string? Conteudo {  get; set; }

        [JsonIgnore]
        public DateTime Data_Publicacao = DateTime.Now;

    }
}
