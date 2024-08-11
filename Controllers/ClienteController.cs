using _04Tienda.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _04Tienda.Models;

namespace _04Tienda.Controllers
{
    public class ClienteController
    {
        private ConexionBDD conexion = new ConexionBDD();
        private SqlCommand comando = new SqlCommand();

        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "INSERT INTO Clientes (Nombres, Apellidos, Direccion, Telefono, Correo) VALUES (@Nombres, @Apellidos, @Direccion, @Telefono, @Correo)";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@Correo", cliente.Correo);

                int filasAfectadas = comando.ExecuteNonQuery();

                comando.Parameters.Clear();

                conexion.CerrarConexion();

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar cliente: " + ex.Message);
                conexion.CerrarConexion();
                return false;
            }
        }

        public bool ModificarCliente(Cliente cliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "UPDATE Clientes SET Nombres = @Nombres, Apellidos = @Apellidos, Direccion = @Direccion, Telefono = @Telefono, Correo = @Correo WHERE IdCliente = @IdCliente";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                comando.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                comando.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@Correo", cliente.Correo);

                int filasAfectadas = comando.ExecuteNonQuery();

                comando.Parameters.Clear();

                conexion.CerrarConexion();

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
     
                MessageBox.Show("Error al modificar cliente: " + ex.Message);
                conexion.CerrarConexion();
                return false;
            }
        }
        public bool EliminarCliente(int idCliente)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                int filasAfectadas = comando.ExecuteNonQuery();

                comando.Parameters.Clear();

                conexion.CerrarConexion();

                return filasAfectadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                conexion.CerrarConexion();
                return false;
            }
        }
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SELECT IdCliente, Nombres, Apellidos, Direccion, Telefono, Correo FROM Clientes";
                comando.CommandType = CommandType.Text;

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        IdCliente = reader.GetInt32(0),
                        Nombres = reader.GetString(1),
                        Apellidos = reader.GetString(2),
                        Direccion = reader.GetString(3),
                        Telefono = reader.GetString(4),
                        Correo = reader.GetString(5)
                    };
                    listaClientes.Add(cliente);
                }

                reader.Close();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener clientes: " + ex.Message);
                conexion.CerrarConexion();
            }

            return listaClientes;
        }

    }
}
