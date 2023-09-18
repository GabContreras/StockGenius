using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace Modelos
{
    public class Pedido
    {
        private int id_Pedido;
        private int id_Cliente;
        private int id_Empleado;
        private DateTime fecha_Pedido;
        private string estado;

        public int Id_Pedido { get => id_Pedido; set => id_Pedido = value; }
        public int Id_Cliente { get => id_Cliente; set => id_Cliente = value; }
        public int Id_Empleado { get => id_Empleado; set => id_Empleado = value; }
        public DateTime Fecha_Pedido { get => fecha_Pedido; set => fecha_Pedido = value; }
        public string Estado { get => estado; set => estado = value; }

        public static DataTable CargarPedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT P.Id_Pedido, C.Nombre AS Cliente, E.Nombre AS Empleado, P.Fecha_Pedido as Fecha, p.Estado, C.Tipo_Cliente as \"Tipo De Cliente\"\r\n" +
                "FROM Pedido P\r\n" +
                "INNER JOIN Cliente C ON P.Id_Cliente = C.Id_Cliente\r\n" +
                "INNER JOIN Empleado E ON P.Id_Empleado = E.Id_Empleado;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

        public static DataTable CargarPedidoOculto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT P.Id_Pedido, p.Estado\r\n" +
                "FROM Pedido P";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

        public bool InsertarPedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Pedido(Id_Cliente, Id_Empleado, Fecha_Pedido,Estado) values \r\n" +
                "(@id_cliente, @id_empleado, @fecha_pedido, @Estado)";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id_cliente", id_Cliente);
            cmd.Parameters.AddWithValue("@id_empleado", id_Empleado);
            cmd.Parameters.AddWithValue("@fecha_pedido", fecha_Pedido);
            cmd.Parameters.AddWithValue("@Estado", estado);


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
            string comando = "update Pedido \r\n" +
                             "set Id_Cliente = @id_cliente, Id_Empleado = @id_empleado\r\n" +
                             "WHERE Id_Pedido = @id";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id_cliente", Id_Cliente);
            cmd.Parameters.AddWithValue("@id_empleado", Id_Empleado);
            cmd.Parameters.AddWithValue("@id", Id_Pedido);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ActualizarEstadoAlgenerarFactura()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update pedido \r\n" +
                "set Estado= @estado \r\n" +
                "where id_pedido= @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@estado", estado);
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
        public static DataTable Buscar(string termino)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT P.Id_Pedido, C.Nombre AS Cliente, E.Nombre AS Empleado, P.Fecha_Pedido as Fecha, p.Estado, C.Tipo_Cliente as \"Tipo De Cliente\"\r\n  " +
                $"FROM Pedido P\r\n" +
                $"INNER JOIN Cliente C ON P.Id_Cliente = C.Id_Cliente\r\n" +
                $"INNER JOIN Empleado E ON P.Id_Empleado = E.Id_Empleado\r\n" +
                $"where C.Nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
