using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Pedido
    {
        private int id_Pedido;
        private int id_Cliente;
        private int id_Empleado;
        private DateTime fecha_Pedido;

        public int Id_Pedido { get => id_Pedido; set => id_Pedido = value; }
        public int Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public int Id_Empleado { get => id_Empleado; set => id_Empleado = value; }
        public DateTime Fecha_Pedido { get => fecha_Pedido; set => fecha_Pedido = value; }

        public static DataTable CargarPedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Pedido;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
    }
}
