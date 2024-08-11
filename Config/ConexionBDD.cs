using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Tienda.Config
{
    internal class ConexionBDD
    {
        private SqlConnection con = new SqlConnection("Server=ALEXIA\\SQLEXPRESS;database=Cuarto;uid=sa;pwd=2023022");

        public SqlConnection AbrirConexion()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            return con;
        }

        public SqlConnection CerrarConexion()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            return con;
        }

    }
}
