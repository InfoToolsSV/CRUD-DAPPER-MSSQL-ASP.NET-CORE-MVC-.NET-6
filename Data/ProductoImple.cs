using System.Data;
using Dapper;
using MVC_Dapper.Models;

namespace MVC_Dapper.Data
{
    public class ProductoImple : IProducto
    {
        private readonly Conexion _conexion;

        public ProductoImple(Conexion conexion)
        {
            _conexion = conexion;
        }
        public void ActualizarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", producto.Id, DbType.Int32);
                parametros.Add("@Nombre", producto.Nombre, DbType.String);
                parametros.Add("@Precio", producto.Precio, DbType.Decimal);
                conexion.Execute("ActualizarProducto", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void EliminarProducto(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);
                conexion.Execute("EliminarProducto", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertarProducto(Producto producto)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Nombre", producto.Nombre, DbType.String);
                parametros.Add("@Precio", producto.Precio, DbType.Decimal);
                conexion.Execute("InsertarProducto", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public Producto ObtenerProductoPorId(int id)
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id, DbType.Int32);
                return conexion.QueryFirstOrDefault<Producto>("ObtenerProductoPorId", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Producto> ObtenerProductos()
        {
            using (var conexion = _conexion.ObtenerConexion())
            {
                return conexion.Query<Producto>("ObtenerProductos", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}