namespace devagora_api.Models
{
    public class UsuarioDAO
    {
        private static ConnectionMysql _conn;

        public UsuarioDAO()
        {
            _conn = new ConnectionMysql();
        }
    }
}
