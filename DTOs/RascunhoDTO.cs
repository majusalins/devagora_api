﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoPABD.DTOs
{
    public class RascunhoDTO
    {
        public int ID_Usuario;
        public string? Conteudo { get; set; }
        public DateTime Data_Edicao = DateTime.Now;

    }
}
