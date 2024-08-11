using _04Tienda.Controllers;
using _04Tienda.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _04Tienda
{
    public partial class Form1 : Form
    {
        private ClienteController clienteController;
        private ProveedorController proveedorController = new ProveedorController();
        public Form1()
        {
            InitializeComponent();
            clienteController = new ClienteController();
            CargarClientes();
        }
        private void CargarClientes()
        {
            List<Cliente> clientes = clienteController.ObtenerClientes();
            lstClientes.Items.Clear(); 
            foreach (Cliente cliente in clientes)
            {
                lstClientes.Items.Add($"{cliente.IdCliente}: {cliente.Nombres} {cliente.Apellidos}");
            }
        }


        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombres = txtNombresCliente.Text,
                Apellidos = txtApellidosCliente.Text,
                Direccion = txtDireccionCliente.Text,
                Telefono = txtTelefonoCliente.Text,
                Correo = txtCorreoCliente.Text
            };

            if (clienteController.AgregarCliente(cliente))
            {
                MessageBox.Show("Cliente agregado con éxito");
                CargarClientes(); 
            }
            else
            {
                MessageBox.Show("Error al agregar cliente");
            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCliente.Text, out int idCliente))
            {
                if (clienteController.EliminarCliente(idCliente))
                {
                    MessageBox.Show("Cliente eliminado con éxito");
                    CargarClientes(); 
                }
                else
                {
                    MessageBox.Show("Error al eliminar cliente");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID de cliente válido.");
            }
        }
        private void btnModificarCliente_Click(object sender, EventArgs e)
            {
            if (int.TryParse(txtIdCliente.Text, out int idCliente))
            {
                Cliente cliente = new Cliente
                {
                    IdCliente = idCliente,
                    Nombres = txtNombresCliente.Text,
                    Apellidos = txtApellidosCliente.Text,
                    Direccion = txtDireccionCliente.Text,
                    Telefono = txtTelefonoCliente.Text,
                    Correo = txtCorreoCliente.Text
                };

                if (clienteController.ModificarCliente(cliente))
                {
                    MessageBox.Show("Cliente modificado con éxito");
                    CargarClientes(); 
                }
                else
                {
                    MessageBox.Show("Error al modificar cliente");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID de cliente válido.");
            }
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor
            {
                Nombre = txtNombreProveedor.Text,
                CodigoBarras = txtCodigoBarrasProveedor.Text
            };

            if (proveedorController.AgregarProveedor(proveedor))
                MessageBox.Show("Proveedor agregado con éxito");
            else
                MessageBox.Show("Error al agregar proveedor");
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            int idProveedor = int.Parse(txtIdProveedor.Text);
            if (proveedorController.EliminarProveedor(idProveedor))
                MessageBox.Show("Proveedor eliminado con éxito");
            else
                MessageBox.Show("Error al eliminar proveedor");
        }

        private void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor
            {
                IdProveedor = int.Parse(txtIdProveedor.Text),
                Nombre = txtNombreProveedor.Text,
                CodigoBarras = txtCodigoBarrasProveedor.Text
            };

            if (proveedorController.ModificarProveedor(proveedor))
                MessageBox.Show("Proveedor modificado con éxito");
            else
                MessageBox.Show("Error al modificar proveedor");
        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}