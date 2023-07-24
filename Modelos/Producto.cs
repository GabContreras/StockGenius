using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Producto
    {
        private int id_Producto;
        private string nombre;
        private string descripcion;
        private int stock;
        private int id_Proveedor;

        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Id_Proveedor { get => id_Proveedor; set => id_Proveedor = value; }

        public static DataTable CargarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Producto;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
    }
}
