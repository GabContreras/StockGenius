using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modelos
{
    public class Proveedores
    {
        private int id_Proveedor;
        private string nombre;
        private string direccion;
        private string telefono;
        private string estado;

        public int Id_Proveedor { get => id_Proveedor; set => id_Proveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Estado { get => estado; set => estado = value; }

        public static DataTable CargarProveedores()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT P.Id_Proveedor AS \"Código de proveedor\", " +
                             "p.Nombre, p.Dirección, P.Telefono " +
                             "FROM Proveedor P " +
                             "WHERE Estado = 'Activo';";

            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }


        public static DataTable Buscar(string termino)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT P.Id_Proveedor as \"Código de proveedor\"," +
                $"p.Nombre, p.Dirección, P.Telefono\r\nFROM proveedor P" +
                $"\r\nWHERE Nombre LIKE '%{termino}%' AND Estado = 'Activo';";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

            public bool InsertarProovedores()
        {
           
                SqlConnection con = Conexion.Conectar();
                string comando = "Insert into proveedor(nombre,dirección,telefono,Estado)" + "values(@nombre,@dirección,@telefono,@Estado);";
                SqlCommand cmd = new SqlCommand(comando, con);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@dirección", direccion);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@Estado", estado);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            
        }
        public bool EliminarProveedores(int id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update proveedor set Estado= 'Inactivo' where Id_Proveedor=@id_proveedor";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@id_proveedor", id); 
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  bool ActualizarProveedores()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update proveedor \r\nset nombre = @nombre, dirección = @dirección, telefono= @telefono WHERE Id_Proveedor = @id_proveedor";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@dirección", direccion);
            cmd.Parameters.AddWithValue("@telefono", telefono);
            cmd.Parameters.AddWithValue("@id_proveedor", Id_Proveedor);

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
