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
        private double precioUnitario;

        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Id_Proveedor { get => id_Proveedor; set => id_Proveedor = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }

        public static DataTable CargarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Producto.Id_Producto, Producto.Nombre AS Nombre_Producto, Producto.Descripcion, Producto.Stock, Producto.PrecioUnitario, Proveedor.Nombre AS Nombre_Proveedor\r\n" +
                "FROM Producto\r\nINNER JOIN Proveedor ON Producto.Id_Proveedor = Proveedor.Id_Proveedor;\r\n\r\n";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public static DataTable CargarStock()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Producto.Id_Producto, Producto.Nombre AS Nombre_Producto, Producto.Stock, Producto.PrecioUnitario, Proveedor.Nombre AS Nombre_Proveedor\r\n" +
                "FROM Producto\r\nINNER JOIN Proveedor ON Producto.Id_Proveedor = Proveedor.Id_Proveedor;\r\n\r\n";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public bool InsertarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Producto(Nombre, Descripcion, Stock, Id_Proveedor, PrecioUnitario) values \r\n" +
                "(@nombre, @descripcion, @stock, @id_Proveedor, @precioUnitario)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@id_Proveedor", id_Proveedor);
            cmd.Parameters.AddWithValue("@precioUnitario", precioUnitario);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }

            else
            {
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
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ActualizarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update Producto \r\n set nombre = @nombre,Descripcion=@descripcion, Stock=@stock, Id_Proveedor= @id_Proveedor, PrecioUnitario= @precioUnitario WHERE Id_Producto = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@precioUnitario", precioUnitario);
            cmd.Parameters.AddWithValue("@id_Proveedor", id_Proveedor);
            cmd.Parameters.AddWithValue("@id", id_Producto);


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
