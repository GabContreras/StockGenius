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
    public class Empleado : Roles
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
            string comando = "SELECT  E.Id_Empleado, U.id_Rol,U.id_usuario,R.Nombre as Rol,E.Nombre AS Nombre,\r\n" +
                " E.Apellido AS Apellido, E.Teléfono AS Telefono, E.DUI AS Dui, E.Correo AS Correo, U.NombreUsuario AS Usuario, U.contraseña AS Contraseña,E.Cargo AS Cargo  \r\n" +
                "FROM Empleado E \r\n" +
                "INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario\r\n" +
                "INNER JOIN Rol R on U.id_Rol= R.id_Rol";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

        public static DataTable CargarEmpleados2()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT E.Id_Empleado, E.Nombre, E.Apellido, E.DUI, R.Nombre\r\n" +
                "FROM Empleado E\r\nINNER JOIN Usuario U ON E.Id_Usuario = U.Id_usuario\r\n" +
                "inner join Rol R on U.id_Rol= R.id_Rol\r\n" +
                "where R.Nombre= 'Vendedor'";
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
            string comando = $"SELECT  E.Id_Empleado, U.id_Rol,U.id_usuario,R.Nombre as Rol,E.Nombre AS Nombre,\r\n " +
                $"E.Apellido AS Apellido, E.Teléfono AS Telefono, E.DUI AS Dui, E.Correo AS Correo, U.NombreUsuario AS Usuario, U.contraseña AS Contraseña,E.Cargo AS Cargo\r\n" +
                $"FROM Empleado E \r\n" +
                $"INNER JOIN Usuario U ON E.id_Usuario = U.id_Usuario\r\n" +
                $"INNER JOIN Rol R on U.id_Rol= R.id_Rol\r\n" +
                $"where E.nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }

        public static DataTable Buscar2(string termino)
        {
            SqlConnection con = Conexion.Conectar();
            string comando = $"SELECT E.Id_Empleado, E.Nombre, E.Apellido, E.DUI, R.Nombre\r\n" +
                $"FROM Empleado E\r\n" +
                $"INNER JOIN Usuario U ON E.Id_Usuario = U.Id_usuario\r\n" +
                $"INNER JOIN Rol R on U.id_Rol= R.id_Rol\r\n" +
                $"where R.Nombre= 'Vendedor' and E.nombre like '%{termino}%'";
            SqlDataAdapter ad = new SqlDataAdapter(comando, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;

        }
        public Empleado ObtenerInfo()
        {
            SqlConnection con = Conexion.Conectar();
            string comando = "SELECT E.Id_Empleado,E.Nombre, E.Correo, U.NombreUsuario, e.id_Usuario\r\n" +
                "FROM Empleado E \r\n" +
                "inner join Usuario U on E.id_Usuario= U.Id_Usuario\r\n" +
                "where e.id_Usuario= @id;";
            SqlCommand cmd = new SqlCommand(comando, con);

            //Enviamos el valor del nombre de usuario para que pueda usarse en el WHERE
            cmd.Parameters.AddWithValue("@id", Id_Usuario);

            //Ejecutamos el lector
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                //Si se obtuvo una coincidencia, creamos un Empleado y le asignamos valores a sus atributos. Los valores se asignan a partir del Lector y la información que recogió
                Empleado emp = new Empleado();
                Usuario u = new Usuario();
                emp.Id_empleado = (int)rd[0];
                emp.Nombre = (string)rd[1];
                emp.Correo = (string)rd[2];
                u.NombreUsuario = (string)rd[3];
                emp.id_Usuario = (int)rd[4];

                //Retornamos el Empleado con sus valores ya asignados
                return emp;
            }
            else
            {
                //Si no hubo coincidencia, retornamos Null
                return null;
            }

        }
    }
}
