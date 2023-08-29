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
    public class Empleados:Roles
    {
        private int id_empleado;
        private string nombre_Empleado;
        private string apellido;
        private string telefono;
        private string dui;
        private string correo;
        private string cargo;
        private int id_Usuario;

      

        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Dui { get => dui; set => dui = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Nombre_Empleado { get => nombre_Empleado; set => nombre_Empleado = value; }
        public int Id_empleado { get => id_empleado; set => id_empleado = value; }

        public static DataTable CargarEmpleados()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT  E.Id_Empleado, U.id_Rol,R.Nombre as Rol, U.NombreUsuario AS Usuario, U.contraseña AS Contraseña,E.Cargo AS Cargo, E.Nombre AS Nombre, E.Apellido AS Apellido," +
                " E.Teléfono AS Telefono, E.DUI AS Dui, E.Correo AS Correo\r\n" +
                "FROM Empleado E\r\nINNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario\r\nINNER JOIN Rol R on U.id_Rol= R.id_Rol;";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public static DataTable CargarEmpleados2()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT Id_Empleado ,concat (Nombre,' ', Apellido, ', ', DUI ) as 'Empleado' from Empleado;\r\n";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }


        public bool InsertarEmpleado()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "insert into Empleado(Nombre, Apellido, Teléfono, DUI, Correo, Cargo, id_Usuario)\r\n" +
                " values \r\n" +
                "(@nombre, @apellido, @teléfono, @dui, @correo, @cargo, @id_Usuario)";

            SqlCommand cmd = new SqlCommand(comando, con);
  
            cmd.Parameters.AddWithValue("@nombre", Nombre_Empleado);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@teléfono", telefono);
            cmd.Parameters.AddWithValue("@dui", dui);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@id_Usuario", id_Usuario);

            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool EliminarEmpleado(int id)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "DELETE FROM Empleado WHERE Id_Empleado = @Id_Empleado";
            SqlCommand cmd = new SqlCommand(comando, con);
            cmd.Parameters.AddWithValue("@Id_Empleado", id);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ActualizarEmpleado()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "update empleado" +
                " \r\n set Nombre=@nombre, Apellido=@apellido, Teléfono=@teléfono, DUI=@dui, Correo=@correo, " +
                "Cargo=@cargo, id_Usuario=@id_Usuario" +
                "  WHERE Id_Empleado = @id";
            SqlCommand cmd = new SqlCommand(comando, con);

            cmd.Parameters.AddWithValue("@nombre", Nombre_Empleado);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@teléfono", telefono);
            cmd.Parameters.AddWithValue("@dui", dui);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@cargo", cargo);
            cmd.Parameters.AddWithValue("@id_Usuario", id_Usuario);
            cmd.Parameters.AddWithValue("@id", id_empleado);


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
            string comando = $"SELECT  E.Id_Empleado, U.id_Rol,R.Nombre as Rol, U.NombreUsuario AS Usuario, U.contraseña AS Contraseña,E.Cargo AS Cargo, E.Nombre AS Nombre, E.Apellido AS Apellido," +
               $"E.Teléfono AS Telefono, E.DUI AS Dui, E.Correo AS Correo \r\n" +
               $"FROM Empleado E \r\n INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario\r\n " +
               $"INNER JOIN Rol R on U.id_Rol= R.id_Rol\r\n\t\t\t\twhere E.nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
           
        }

    }
}
