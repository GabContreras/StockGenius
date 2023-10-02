using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Modelos
{
    public class Producto
    {
        private int id_Producto;
        private string nombre;
        private string descripcion;
        private int stock;
        private int id_Proveedor;
        private double precioUnitario;
        private string imagen;

        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Id_Proveedor { get => id_Proveedor; set => id_Proveedor = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public string Imagen { get => imagen; set => imagen = value; }

        public static DataTable CargarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT P.Id_Producto as \"Código de producto\"," +
                "P.Nombre , P.Descripcion as Descripción, P.Stock, P.Precio_Unitario as Precio,\r\n" +
                "Pr.Nombre AS Proveedor, P.imagen as imagen, Pr.Id_Proveedor \r\n" +
                "FROM Producto P\r\n" +
                "INNER JOIN Proveedor Pr ON P.Id_Proveedor = Pr.Id_Proveedor";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GenerarInformeInventario(DateTime fechaInicio, DateTime fechaFin)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = @"WITH Ingresos AS (
    SELECT
        IP.Id_Producto,
        SUM(IP.cantidad) AS Ingresos
    FROM
        Ingreso_Producto IP
    WHERE
        IP.fecha_Ingreso >= @FechaInicio AND IP.fecha_Ingreso <= @FechaFin
    GROUP BY
        IP.Id_Producto
),
Salidas AS (
    SELECT
        DP.Id_Producto,
        SUM(DP.Cantidad) AS Salidas
    FROM
        Detalle_Pedido DP
    INNER JOIN
        Pedido Pd ON DP.Id_Pedido = Pd.Id_Pedido
    WHERE
        Pd.Estado = 'Completado'
        AND Pd.fecha_Pedido >= @FechaInicio AND Pd.fecha_Pedido <= @FechaFin
    GROUP BY
        DP.Id_Producto
),
StockInicial AS (
    SELECT
        IP.Id_Producto,
        SUM(IP.cantidad) AS StockInicial
    FROM
        Ingreso_Producto IP
    WHERE
        IP.fecha_Ingreso < @FechaInicio
    GROUP BY
        IP.Id_Producto
)
SELECT
    P.Id_Producto,
    P.Nombre AS Producto,
    @FechaInicio AS FechaInicio,
    @FechaFin AS FechaFin,
    ISNULL(SI.StockInicial, 0) AS StockInicial,
    ISNULL(I.Ingresos, 0) AS Ingresos,
    ISNULL(S.Salidas, 0) AS Salidas,
    P.Stock AS StockFinal
FROM
    Producto P
LEFT JOIN
    StockInicial SI ON P.Id_Producto = SI.Id_Producto
LEFT JOIN
    Ingresos I ON P.Id_Producto = I.Id_Producto
LEFT JOIN
    Salidas S ON P.Id_Producto = S.Id_Producto
ORDER BY
    P.Id_Producto;
    ";

            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

            // El comando se agrega al SqlDataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            ad.Fill(dt);

            con.Close();
            return dt;
        }


        public static DataTable BuscarEnDetallePedido(string termino)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"select P.Id_Producto, P.Nombre as Producto\r\n" +
                $"from producto P\r\n" +
                $"inner join proveedor PV on P.Id_Proveedor = PV.Id_Proveedor\r\n" +
                $"where P.Nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;

        }
       
        public static DataTable CargarProductoEnDetallePedido()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "select P.Id_Producto, P.Nombre as Producto\r\n" +
                "from producto P\r\n" +
                "inner join proveedor PV on P.Id_Proveedor = PV.Id_Proveedor\r\n" +
                "where PV.Estado= 'Activo'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;
        }

       
        public static DataTable CargarStock()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Producto.Id_Producto, Producto.Nombre AS Nombre_Producto, Producto.Stock, Producto.Precio_Unitario, Proveedor.Nombre AS Nombre_Proveedor\r\n" +
                "FROM Producto\r\nINNER JOIN Proveedor ON Producto.Id_Proveedor = Proveedor.Id_Proveedor;\r\n\r\n";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;
        }
        public int ObtenerStockProducto(int idProducto)
        {

            // se agrega la consulta para sabe cuanto hay en stock
            int stock = 0;
            SqlConnection con = Conexion.Conectar();
            string query = "SELECT Stock FROM Producto WHERE Id_Producto = @Id_Producto";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id_Producto", idProducto);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    stock = Convert.ToInt32(reader["Stock"]);
                }
            }
            con.Close();
            return stock;
        }

       

        public bool InsertarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Producto(Nombre, Descripcion, Stock, Id_Proveedor, Precio_Unitario,imagen) values \r\n" +
                "(@nombre, @descripcion, @stock, @id_Proveedor, @Precio_Unitario,@imagen)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@id_Proveedor", id_Proveedor);
            cmd.Parameters.AddWithValue("@Precio_Unitario", precioUnitario);
            cmd.Parameters.AddWithValue("@imagen", imagen);

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
        public bool EliminarProducto(int id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Producto WHERE Id_Producto = @id_Producto";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id_producto", id);
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
        public bool ActualizarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Producto \r\n " +
                "set nombre = @nombre,Descripcion=@descripcion, " +
                "Id_Proveedor= @id_Proveedor," +
                " Precio_Unitario= @Precio_Unitario, imagen=@imagen WHERE Id_Producto = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@Precio_Unitario", precioUnitario);
            cmd.Parameters.AddWithValue("@id_Proveedor", id_Proveedor);
            cmd.Parameters.AddWithValue("@id", id_Producto);
            cmd.Parameters.AddWithValue("@imagen", imagen);


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
        public bool ActualizarProducto2()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Producto set stock= @stock\r\n" +
                "where Id_Producto=@id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@id", id_Producto);

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
        public static DataTable Buscar(string termino)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT P.Id_Producto as \"Código de producto\"," +
                "P.Nombre , P.Descripcion as Descripción, P.Stock, P.Precio_Unitario as Precio,\r\n" +
                "Pr.Nombre AS Proveedor, P.imagen as imagen, Pr.Id_Proveedor \r\n" +
                "FROM Producto P\r\n" +
                $"INNER JOIN Proveedor Pr ON P.Id_Proveedor = Pr.Id_Proveedor\r\n" +
                $"where P.nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();
            return dt;
        }

    }
}
