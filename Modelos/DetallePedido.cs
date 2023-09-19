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
            string comando = $"SELECT DP.Id_Detalle, DP.Id_Pedido, DP.Id_Producto, P.Nombre AS Producto, DP.Cantidad, P.Precio_Unitario AS Precio, PD.Estado AS" +
                $" \"Estado\"\r\n" +
                $"FROM Detalle_Pedido DP\r\n" +
                $"INNER JOIN Pedido PD ON DP.Id_Pedido = PD.Id_Pedido\r\n" +
                $"INNER JOIN Producto P ON DP.Id_Producto = P.Id_Producto\r\n" +
                $"WHERE DP.Id_Pedido = @id;";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@id", id_pedido);

            //El comando se agrega al SqlDataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            ad.Fill(dt);

            return dt;
        }
        public DataTable CargarFactura()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT DP.ID_Producto, P.nombre, sum(DP.cantidad) as Cantidad,  P.Precio_Unitario\r\n" +
                $"FROM Detalle_Pedido DP\r\n" +
                $"inner join producto P on P.id_Producto = DP.id_Producto\r\n" +
                $"where id_pedido = @id\r\n" +
                $"group by P.nombre, DP.id_producto,DP.Id_Pedido, P.Precio_Unitario";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@id", id_pedido);

            //El comando se agrega al SqlDataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            ad.Fill(dt);

            return dt;
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
                    return true;
                }
                else
                {
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
                return true;
            }
            else
            {
                return false;
            }
        }
        


    }
}
