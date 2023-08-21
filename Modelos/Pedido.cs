using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
            string comando = "SELECT P.Id_Pedido, C.Nombre AS Nombre_Cliente, E.Nombre AS Nombre_Empleado, P.Fecha_Pedido\r\nFROM Pedido P\r\n" +
                "INNER JOIN Cliente C ON P.Id_Cliente = C.Id_Cliente\r\nINNER JOIN Empleado E ON P.Id_Empleado = E.Id_Empleado;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

        public bool InsertarPedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Pedido(Id_Cliente, Id_Empleado, Fecha_Pedido) values \r\n" +
                "(@id_cliente, @id_empleado, @fecha_pedido)";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id_cliente", id_Cliente);
            cmd.Parameters.AddWithValue("@id_empleado", id_Empleado);
            cmd.Parameters.AddWithValue("@fecha_pedido", fecha_Pedido);
 

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        public bool EliminarPedido(int id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Pedido WHERE Id_Pedido = @id_pedido";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id_pedido", id);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActualizarPedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Pedido \r\nset Id_Cliente= @id_cliente, Id_Empleado= id_empleado, Fecha_Pedido= fecha_pedido  WHERE Id_Pedido = @id";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id_cliente", id_Cliente);
            cmd.Parameters.AddWithValue("@id_empleado", id_Empleado);
            cmd.Parameters.AddWithValue("@fecha_pedido", fecha_Pedido);
            cmd.Parameters.AddWithValue("@id", id_Pedido);


            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
