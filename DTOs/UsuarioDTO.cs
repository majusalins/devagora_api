namespace devagora_api.DTOs
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório ter no mínimo 5 caracteres!")]

        [DefaultValue(false)]
        public bool Tipo_Usuario { get; set; } = false;
    }
}
