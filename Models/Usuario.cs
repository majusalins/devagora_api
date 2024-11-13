namespace ProjetoPABD.Models
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        private string Senha { get; set; }
        public DateTime Data_Cadastro { get; set; } = DateTime.Now;
        public bool Tipo_Usuario;
    }
}
