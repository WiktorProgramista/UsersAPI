using MySql.Data.MySqlClient;

namespace UserAPI.Application.Interfaces
{
    public interface IDbConnector
    {
        public bool OpenConnection();
        public bool CloseConnection();
        public MySqlDataReader ExecuteQuery(string query);
    }
}
