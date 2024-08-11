using _04Tienda.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04Tienda.Models;
namespace _04Tienda.Controllers
{
    public class ProveedorController
    {
        private ConexionBDD conexion = new ConexionBDD();
        private SqlCommand comando = new SqlCommand();

        public bool AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "INSERT INTO Proveedores (Nombre, Codigo_barras) VALUES (@Nombre, @CodigoBarras)";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                comando.Parameters.AddWithValue("@CodigoBarras", proveedor.CodigoBarras);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                conexion.CerrarConexion();
                return false;
            }
        }

        public bool EliminarProveedor(int idProveedor)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "DELETE FROM Proveedores WHERE IdProveedor = @IdProveedor";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@IdProveedor", idProveedor);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                conexion.CerrarConexion();
                return false;
            }
        }

        public bool ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "UPDATE Proveedores SET Nombre = @Nombre, Codigo_barras = @CodigoBarras WHERE IdProveedor = @IdProveedor";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                comando.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                comando.Parameters.AddWithValue("@CodigoBarras", proveedor.CodigoBarras);
                comando.ExecuteNonQuery();
                comando.Parameters.Clear();
                conexion.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                conexion.CerrarConexion();
                return false;
            }
        }

    }
}
