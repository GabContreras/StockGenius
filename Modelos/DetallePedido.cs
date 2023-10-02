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
    public class DetallePedido
    {
        private int id_Detalle;
        private int id_pedido;
        private int id_Producto;
        private int cantidad;
     

        public int Id_Detalle { get => id_Detalle; set => id_Detalle = value; }
        public int Id_pedido { get => id_pedido; set => id_pedido = value; }
        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }


            //Este método no es estático porque lleva un WHERE, y ahí se colocarán valores que pueden variar (parámetros)
        public DataTable CargarDetallePedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT DP.Id_Detalle, DP.Id_Pedido as \"Número de pedido\", DP.Id_Producto as \"Código de producto\"," +
                $" P.Nombre AS Producto, DP.Cantidad, P.Precio_Unitario AS Precio\r\n" +
                $"FROM Detalle_Pedido DP\r\n" +
                $"INNER JOIN Producto P ON DP.Id_Producto = P.Id_Producto\r\n" +
                $"where Id_Pedido=@id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@id", id_pedido);

            //El comando se agrega al SqlDataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            ad.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable CargarFactura()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT DP.ID_Producto, P.nombre, SUM(DP.cantidad) AS Cantidad, P.Precio_Unitario,\r\n" +
                $"PP.Fecha_Pedido, C.Nombre AS Nombre_Cliente, E.Nombre AS Nombre_Empleado\r\n" +
                $"FROM Detalle_Pedido DP\r\n" +
                $"INNER JOIN Producto P ON P.id_Producto = DP.id_Producto\r\n" +
                $"INNER JOIN Pedido PP ON DP.Id_Pedido = PP.Id_Pedido\r\n" +
                $"INNER JOIN Cliente C ON PP.Id_Cliente = C.Id_Cliente\r\n" +
                $"INNER JOIN Empleado E ON PP.Id_Empleado = E.Id_Empleado\r\n" +
                $"WHERE DP.Id_Pedido = @id\r\n" +
                $"GROUP BY P.nombre, DP.id_producto, DP.Id_Pedido, P.Precio_Unitario, PP.Fecha_Pedido, C.Nombre, E.Nombre;\r\n";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@id", id_pedido);

            //El comando se agrega al SqlDataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            ad.Fill(dt);

            con.Close();
            return dt;
        }
      
        public bool ExisteDetallePedido(int idPedido)
        {
            bool existeDetalle = false;

            SqlConnection con = Conexion.Conectar();
            string query = "SELECT COUNT(*) FROM Detalle_Pedido WHERE Id_Pedido = @Id_pedido;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id_pedido", idPedido);

                int count = (int)cmd.ExecuteScalar(); // Obtener el resultado de la consulta como un entero

                if (count > 0)
                {
                    existeDetalle = true;
                }

            con.Close();
            return existeDetalle;
        }

        public bool InsertarDpedido()
        {
                SqlConnection con = Conexion.Conectar();
                string comando = "INSERT INTO Detalle_Pedido(Id_Pedido, Id_Producto, cantidad) VALUES (@Id_Pedido, @Id_Producto," +
                "@cantidad)";
                SqlCommand cmd = new SqlCommand(comando, con);

                cmd.Parameters.AddWithValue("@Id_Pedido", id_pedido);
                cmd.Parameters.AddWithValue("@Id_Producto", id_Producto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
       
                if (cmd.ExecuteNonQuery() > 0)
                {
                con.Close();
                return true;
                }
                else
                {
                con.Close();
                return false;
                }
          
        }
        public bool EliminarDetallePedido(int Id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Detalle_Pedido WHERE Id_Detalle = @Id_Detalle";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@Id_Detalle", Id);

            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return true;

            }
            else
            {
                con.Close();
                return false;
            }
        }
        


    }
}
