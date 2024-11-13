using System.Data;
using MySql.Data.MySqlClient;

namespace devagora_api.Database
{
    public class ConnectionMysql
    {

        private static readonly string host = "localhost";

        private static readonly string port = "3306";

        private static readonly string user = "root";

        private static readonly string password = "root";

        private static readonly string dbname = "DevAgora";

        private static MySqlConnection? _connection;

        private static MySqlCommand? _command;

        public ConnectionMysql()
        {
            try
            {
                _connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password}");
                _connection.Open();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public MySqlCommand Query()
        {
            try
            {
                _command = _connection.CreateCommand();
                _command.CommandType = CommandType.Text;

                return _command;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Close()
        {
            _connection.Close();
        }
    }
}