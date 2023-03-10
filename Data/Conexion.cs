using System.Data.SqlClient;

namespace MVC_Dapper.Data
{
    public class Conexion
    {
        private readonly string _connectionString;

        public Conexion(string valor)
        {
            _connectionString = valor;
        }

        public SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}