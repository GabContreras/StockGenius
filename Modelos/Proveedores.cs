using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Proveedores
    {
        private int id_Proveedor;
        private string nombre;
        private string direccion;
        private string telefono;

        public int Id_Proveedor { get => id_Proveedor; set => id_Proveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }

        public static DataTable CargarProveedores()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Proveedor;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
    }
}
