namespace ProjetoPABD.DTOs
{
    public class PostDTO
    {
        public int ID_Usuario;
        public DateTime Data_Publicacao = DateTime.Now;
        public string? Tipo_Post { get; set; }
    }
}
