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
            string comando = "SELECT Producto.Id_Producto, Producto.Nombre AS Nombre_Producto, Producto.Descripcion, Producto.Stock, Proveedor.Nombre AS Nombre_Proveedor\r\nFROM Producto\r\n" +
                "INNER JOIN Proveedor ON Producto.Id_Proveedor = Proveedor.Id_Proveedor;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

        public bool InsertarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Producto(Nombre, Descripcion, Stock, Id_Proveedor) values \r\n(@nombre, @descripcion, @stock, @id_Proveedor)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@stock", stock);
            cmd.Parameters.AddWithValue("@id_Proveedor", id_Proveedor);

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
            string comando = "update Producto \r\nset nombre = @nombre,Descripcion=@descripcion, Stock=@stock, Id_Proveedor= @id_Proveedor WHERE Id_Producto = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@stock", stock);
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
