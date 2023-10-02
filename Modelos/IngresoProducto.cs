using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class IngresoProducto
    {
        private int id_ingreso;
        private DateTime fecha_ingreso;
        private int id_producto;
        private int cantidad;

        public int Id_ingreso { get => id_ingreso; set => id_ingreso = value; }
        public DateTime Fecha_ingreso { get => fecha_ingreso; set => fecha_ingreso = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public bool ingresarProducto()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "INSERT INTO Ingreso_Producto (fecha_Ingreso, Id_Producto, cantidad)\r\n" +
                "VALUES \r\n" +
                "(@fecha, @id_producto, @cantidad)";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@fecha", fecha_ingreso);
            cmd.Parameters.AddWithValue("@id_producto", id_producto);
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

        public string ObtenerEstadoProveedor(int idProveedor)
        {
            string estado = ""; // Declarar la variable para almacenar el estado del proveedor
            SqlConnection con = Conexion.Conectar();
            string query = "SELECT Estado FROM proveedor WHERE Id_Proveedor = @id_proveedor;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id_proveedor", idProveedor);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read()) // Verificar si se obtuvo un resultado no nulo
                {
                    estado = reader["Estado"].ToString(); // Obtener el estado del resultado y asignarlo a la variable estado
                }
            }

            con.Close();
            return estado; // Devolver el estado del proveedor
        }

    }
}
