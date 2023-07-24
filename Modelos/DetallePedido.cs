using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetallePedido
    {
        private int id_Detalle;
        private int id_pedido;
        private int id_Producto;
        private int cantidad;
        private double total;

        public int Id_Detalle { get => id_Detalle; set => id_Detalle = value; }
        public int Id_pedido { get => id_pedido; set => id_pedido = value; }
        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Total { get => total; set => total = value; }

        public static DataTable CargarDetallePedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Detalle_Pedido;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

    }
}
