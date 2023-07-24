using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Factura
    {
        private int id_Factura;
        private int id_Pedido;
        private double totalFinal;

        public int Id_Factura { get => id_Factura; set => id_Factura = value; }
        public int Id_Pedido { get => id_Pedido; set => id_Pedido = value; }
        public double TotalFinal { get => totalFinal; set => totalFinal = value; }

        public static DataTable CargarFactura()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select * from Factura;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
    }
}
